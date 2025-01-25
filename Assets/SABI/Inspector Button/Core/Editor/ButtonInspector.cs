using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace SABI
{
    [CustomEditor(typeof(Object), true)]
    public class ButtonInspector : Editor
    {
        // Dictionary to store parameter values for each method
        private Dictionary<string, object[]> methodParameters = new Dictionary<string, object[]>();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var methods = target
                .GetType()
                .GetMethods(
                    BindingFlags.Instance
                        | BindingFlags.Static
                        | BindingFlags.Public
                        | BindingFlags.NonPublic
                );

            foreach (var method in methods)
            {
                ButtonAttribute buttonAttribute = method.GetCustomAttribute<ButtonAttribute>();
                if (buttonAttribute != null)
                {
                    GUILayout.Space(buttonAttribute.margin);
                    GUI.backgroundColor = buttonAttribute.buttonColor;
                    GUI.contentColor = buttonAttribute.textColor;

                    // Get method parameters
                    var parameters = method.GetParameters();

                    // Initialize parameter values if not already present
                    if (!methodParameters.ContainsKey(method.Name))
                    {
                        methodParameters[method.Name] = new object[parameters.Length];
                    }

                    // Draw parameter fields
                    if (parameters.Length > 0)
                    {
                        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            var param = parameters[i];
                            methodParameters[method.Name][i] = DrawParameterField(
                                param,
                                methodParameters[method.Name][i]
                            );
                        }
                        EditorGUILayout.EndVertical();
                    }

                    // Draw the button
                    bool clicked =
                        buttonAttribute.width > 0
                            ? GUILayout.Button(
                                buttonAttribute.customName ?? method.Name,
                                GUILayout.Width(buttonAttribute.width.Value),
                                GUILayout.Height(buttonAttribute.height)
                            )
                            : GUILayout.Button(
                                buttonAttribute.customName ?? method.Name,
                                GUILayout.Height(buttonAttribute.height)
                            );

                    if (clicked)
                    {
                        method.Invoke(target, methodParameters[method.Name]);
                    }

                    GUI.backgroundColor = Color.white;
                    GUI.contentColor = Color.black;
                    GUILayout.Space(buttonAttribute.margin);
                }
            }
        }

        private object DrawParameterField(ParameterInfo param, object currentValue)
        {
            var paramType = param.ParameterType;
            var label = ObjectNames.NicifyVariableName(param.Name);

            // Handle different parameter types
            if (paramType == typeof(int))
            {
                return EditorGUILayout.IntField(
                    label,
                    currentValue != null ? (int)currentValue : 0
                );
            }
            if (paramType == typeof(float))
            {
                return EditorGUILayout.FloatField(
                    label,
                    currentValue != null ? (float)currentValue : 0f
                );
            }
            if (paramType == typeof(string))
            {
                return EditorGUILayout.TextField(label, (string)currentValue ?? "");
            }
            if (paramType == typeof(bool))
            {
                return EditorGUILayout.Toggle(
                    label,
                    currentValue != null ? (bool)currentValue : false
                );
            }
            if (paramType == typeof(Vector2))
            {
                return EditorGUILayout.Vector2Field(
                    label,
                    currentValue != null ? (Vector2)currentValue : Vector2.zero
                );
            }
            if (paramType == typeof(Vector3))
            {
                return EditorGUILayout.Vector3Field(
                    label,
                    currentValue != null ? (Vector3)currentValue : Vector3.zero
                );
            }
            if (paramType == typeof(Color))
            {
                return EditorGUILayout.ColorField(
                    label,
                    currentValue != null ? (Color)currentValue : Color.white
                );
            }
            if (typeof(UnityEngine.Object).IsAssignableFrom(paramType))
            {
                return EditorGUILayout.ObjectField(
                    label,
                    (UnityEngine.Object)currentValue,
                    paramType,
                    true
                );
            }

            // For unsupported types, show a warning and return null
            EditorGUILayout.HelpBox(
                $"Parameter type {paramType} is not supported",
                MessageType.Warning
            );
            return null;
        }
    }
}

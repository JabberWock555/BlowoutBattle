using UnityEngine;

namespace SABI
{
    public class ExampleOfInspectorButton : MonoBehaviour
    {
        [Button()]
        private void Button() => Debug.Log($" Button ");
        [Button("Button with custom name")]
        private void ButtonnWithName() => Debug.Log($" Button with custon name ");

        [Button()]
        private void Button_WithIntArgument(int intArgument) => Debug.Log($" Button intArgument:{intArgument}  ");
        [Button()]
        private void Button_WithIntAndStringArgument(int intArgument, string stringArgument) => Debug.Log($" Button intArgument:{intArgument} stringArgument:{stringArgument} ");


        [Button(bgColor: "#FFFF00")]
        private void ButtonWithColor() => Debug.Log($" Button ");

        [Button(height: 70)]
        private void ButtonWithCustomHeight() => Debug.Log($" ButtonWithCustomHeight ");

        [Button(width: 150)]
        private void ButtonWithCustomWidth() => Debug.Log($" ButtonWithCustomWidth ");

        [Button(text: "Custom Button with properties", height: 100, bgColor: "#FF0000", textColor: "#FFFFFF")]
        private void ButtonWithProperties() => Debug.Log($" Button With properties ");
    }
}

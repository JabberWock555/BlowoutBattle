using System.Linq;
using UnityEngine;

namespace SABI
{
    public static class ObjectExtensions
    {
        public static void DestroyGameObject(this Object value, float delay = 0)
        {
            if (value == null)
                return;
            if (value is MonoBehaviour monoBehaviour)
                value = monoBehaviour.gameObject;
            if (value is Transform transform)
                value = transform.gameObject;
            Object.Destroy(value, delay);
        }

        /// <summary>
        /// Checks if the object equals to any of the provided objects.
        /// </summary>
        public static bool EqualsToAny(this object obj, params object[] objects) =>
            objects.Any(o => o.Equals(obj));
    }
}

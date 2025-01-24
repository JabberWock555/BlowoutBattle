using System;
using UnityEngine;

namespace SABI
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ButtonAttribute : Attribute
    {
        public string customName;
        public float? width;
        public float height;
        public Color buttonColor;
        public Color textColor;
        public float margin;

        public ButtonAttribute(
            string text = null,
            float width = -1,
            float height = 30,
            string bgColor = "#FFFFFF",
            string textColor = "#FFFFFF",
            float margin = 5
        )
        {
            this.customName = text;
            this.width = width;
            this.height = height;
            this.buttonColor = ColorUtility.TryParseHtmlString(bgColor, out var parsedButtonColor)
                ? parsedButtonColor
                : Color.white;
            this.textColor = ColorUtility.TryParseHtmlString(textColor, out var parsedTextColor)
                ? parsedTextColor
                : Color.black;
            this.margin = margin;
        }
    }
}

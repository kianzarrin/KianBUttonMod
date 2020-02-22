using ColossalFramework.UI;
using UnityEngine;
using ColossalFramework;
using static Kian.ShortCuts;

namespace Kian.UI
{
    public class ToolButton : UIButton
    {
        public override void Start() {
            base.Start();
            // Set the text to show on the
            text = "Click Me!";
            name = "ToolActivateButton";

            // Set the button dimensions.
            width = 100;
            height = 30;

            // Style the button to look like a menu
            normalBgSprite = "ButtonMenu";
            disabledBgSprite = "ButtonMenuDisabled";
            hoveredBgSprite = "ButtonMenuHovered";
            focusedBgSprite = normalBgSprite;// "ButtonMenuFocused";
            pressedBgSprite = "ButtonMenuPressed";
            textColor = new Color32(255, 255, 255, 255);
            disabledTextColor = new Color32(7, 7, 7, 255);
            hoveredTextColor = new Color32(7, 132, 255, 255);
            focusedTextColor = textColor;// new Color32(255, 255, 255, 255);
            pressedTextColor = new Color32(30, 30, 44, 255);

            // Enable button sounds.
            playAudioEvents = true;

            eventClicked += OnClick;
        }

        public override void OnDestroy() {
            Log("ToolButton OnDestroy() called");
            eventClicked -= OnClick;
            base.OnDestroy();
        }

        public static ToolButton Create() { 
            var uiView = UIView.GetAView();
            var button = (ToolButton)uiView.AddUIComponent(typeof(ToolButton));
            // Place the button
            button.transformPosition = new Vector3(-1.65f, 0.97f);

            return button;

        }

        public static void Release() {
            var uiView = UIView.GetAView();
            var button = (ToolButton)uiView.FindUIComponent<ToolButton>("ToolActivateButton");
            Destroy(button);
        }

        public static void OnClick(UIComponent component, UIMouseEventParameter eventParam) {
            Log("ToolButton:OnClick() called");
            Destroy(component, 1f);

        }
    }

}

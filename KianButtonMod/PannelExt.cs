namespace Kian
{
    using UI;
    using System.Collections.Generic;
    using ColossalFramework.UI;
    using UnityEngine;
    using static ShortCuts;
    public class PanelExt2 : UIPanel
    {
        /// list of buttons contained in this panel.
        public IList<UIButton> buttons;

        public override void Start()
        {
            Log("PanelExt Start() called");
            this.backgroundSprite = "GenericPanel";
            this.color = new Color32(255, 0, 0, 100);
            this.width = 500; 
            this.height = 100;
            this.transformPosition = new Vector3(-1.65f, 0.97f);

            autoLayout = true;
            autoLayoutDirection = LayoutDirection.Horizontal;
            buttons = new List<UIButton>();
            buttons.Add(AddUIComponent<ToolButton>());
            buttons.Add(AddUIComponent<ToolButton>());
            buttons.Add(AddUIComponent<ToolButton>());
            int i = 0;
            foreach (var button in buttons)
            {
                button.text = "button" + i;
                button.name = "button" + i;
                button.Invalidate();
                i++; 
            } 
        }
    } // end class PanelExt
}
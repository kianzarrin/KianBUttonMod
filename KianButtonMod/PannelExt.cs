namespace Kian
{
    using System.Collections.Generic;
    using ColossalFramework.UI;
    using UnityEngine;
    using static ShortCuts;
    public class PanelExt : UIPanel
    {
        /// list of buttons contained in this panel.
        //public IList<UIButton> buttons;

        public override void Start()
        {
            Log("PanelExt Start() called");
            backgroundSprite = "GenericPanel";
            color = new Color32(255, 0, 0, 100);
            width = 100;
            height = 200;

            //autoLayout = true;
            //autoLayoutDirection = LayoutDirection.Horizontal;
            //buttons = new List<UIButton>();
        }

        //public override void OnDestroy()
        //{
        //    if (buttons != null)
        //    {
        //        foreach (UIButton button in buttons)
        //        {
        //            if (button != null)
        //            {
        //                Destroy(button);
        //            }
        //        }
        //        buttons.Clear();
        //        buttons = null;
        //    }
        //    base.OnDestroy();
        //}
    } // end class PanelExt
}
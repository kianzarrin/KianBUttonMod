namespace Kian
{
    using ColossalFramework.UI;
    using System.Collections.Generic;
    using UnityEngine;
    using static ShortCuts;
    using UI;

    public class MonoTest : MonoBehaviour
    {
        PanelExt panel;
        public void Start()
        {
            Log("MonoTest.Start() called");
            panel =  UIView.GetAView().AddUIComponent(typeof(PanelExt)) as PanelExt;
        }
        public void OnDestroy()
        {
            if (panel != null)
            {
                Destroy(panel.gameObject);
            }
        }
        public class PanelExt : UIPanel
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
            }
        } // end class PanelExt
        /// <summary>
        /// Panel container for the Road selection UI. Multiple instances are allowed.
        /// </summary>
    } // end MonoTest
} //end namesapce

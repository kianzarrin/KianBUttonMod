namespace Kian
{
    using ColossalFramework.UI;
    using UnityEngine;
    using static ShortCuts;

    public class MonoTest : MonoBehaviour
    {

        PanelExt panel;
        public void OnDestroy()
        {
            if (panel != null)
            { 
                Destroy(panel);
            }
        }

        public void Start()
        {
            Log("MonoTest.Start() called");
            panel =  UIView.GetAView().AddUIComponent(typeof(PanelExt)) as PanelExt;

        }

        /// <summary>
        /// Panel container for the Road selection UI. Multiple instances are allowed.
        /// </summary>

    } // end MonoTest
} //end namesapce

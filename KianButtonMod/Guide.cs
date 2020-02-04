using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ColossalFramework;
using ColossalFramework.Globalization;
using ICities;
using UnityEngine;
using static Kian.Mod.ShortCuts;

namespace Kian.Util
{
    public class GuidePair
    {
        public GenericGuide m_guide = new GenericGuide();
        public GuideInfo m_info;
        public void Activate()
        {
            if (m_info != null)
                m_guide?.Activate(m_info);
        }
        public void Deactivate() => m_guide?.Deactivate();

        public GuidePair()
        {
            m_info = new GuideInfo();
            m_info.m_delayType = GuideInfo.Delay.OccurrenceCount;
            m_info.m_displayDelay = 1;
            m_info.m_tag = "Generic";
            m_info.m_icon = "ToolbarIconRoads";
        }

        public static GuidePair example = new GuidePair()
        {
            m_info = {
                //TMPE_TUTORIAL_HEAD_LaneArrowTool
                //TMPE_TUTORIAL_BODY_LaneArrowTool
                // TUTORIAL_ADVISER_TITLE
                // TUTORIAL_ADVISER
                m_name = "TMPE_TUTORIAL_BODY_LaneArrowTool",
                //m_tag = "TUTORIAL_ADVISER",
            }
        };

        //public void AddStrings() {
        //    var locale = (Locale)typeof(LocaleManager)
        //             .GetField(
        //                 "m_Locale",
        //                 BindingFlags.Instance | BindingFlags.NonPublic)
        //             ?.GetValue(SingletonLite<LocaleManager>.instance);
        //    var key = new Locale.Key() {
        //        m_Identifier = "identifier",
        //        m_Key = "key"
        //    };
        //    string value = "";
        //    locale.AddLocalizedString(key, value);
        //    // see Translation.ReloadTutorialTranslations
        //}
    }


    public static class Test
    {
        public static NetInfo GetInfo() {
            int n = PrefabCollection<NetInfo>.LoadedCount();
            for (uint i= 0; i < n; ++i){
                NetInfo info = PrefabCollection<NetInfo>.GetLoaded(i);
                if (info.m_netAI is RoadAI && info.name == "Basic Road")
                {
                    return info;
                }
            }
            return null;
        }
        
        public static  void Run()
        {
            Log("KIAN DEBUG: Test.Run() called");
            NetInfo info = GetInfo();
            RoadAI ai = info.m_netAI as RoadAI;
            Log("KIAN DEBUG: executing ai.UpgradeFailed(); ...");
            ai.UpgradeFailed();
            //GuidePair.example.Activate();
        }

    }

    public class TestThread : ThreadingExtensionBase
    {
        public override void on
    }
}

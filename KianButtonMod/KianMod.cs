using ICities;
using ColossalFramework;
using UnityEngine;
using System;

using Kian.UI;
using System.Diagnostics;

namespace Kian.Mod
{
    public class KianModInfo : IUserMod {
        public string Name => "kian button mod";
        public string Description => "simple test mod with a button to activate test";

        public void OnEnabled() {
            System.IO.File.WriteAllText(ShortCuts.filename, ""); //clear file
            ShortCuts.Log("IUserMod.OnEnabled"); 

            if (ShortCuts.InGame)
                LoadTool.Load();
        }

        public void OnDisabled() {
            ShortCuts.Log("IUserMod.OnDisabled");
            LoadTool.Release();
        }
    }

    public static class LoadTool {
        public static void Load() {
            ToolButton.Create();
            ShortCuts.Log("LoadTool:Created kian tool.");
        }
        public static void Release() {
            ToolButton.Release();
            ShortCuts.Log("LoadTool:Removed kian tool.");
        }
    }

    public class LoadingExtention : LoadingExtensionBase {

        public override void OnLevelLoaded(LoadMode mode) {
            ShortCuts.Log("LoadingExtention.OnLevelLoaded");
            if (mode == LoadMode.LoadGame || mode == LoadMode.NewGame)
                LoadTool.Load();
        }

        public override void OnLevelUnloading() {
            ShortCuts.Log("LoadingExtention.OnLevelUnloading");
            LoadTool.Release();
        }
    }
} // end namesapce

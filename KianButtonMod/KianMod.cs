using ICities;
using ColossalFramework;
using UnityEngine;
using System;

using Kian.UI;
using System.Diagnostics;
using KianButtonMod.Util;
namespace Kian.Mod
{   
    public class KianModInfo : IUserMod {
        public string Name => "kian button mod";
        public string Description => "simple test mod with a button to activate test";

        public void OnEnabled() {
            System.IO.File.WriteAllText("mod.debug.log", ""); //clear file
            Extensions.Log("IUserMod.OnEnabled"); 

            if (Extensions.InGame)
                LoadTool.Load();
        }

        public void OnDisabled() {
            Extensions.Log("IUserMod.OnDisabled");
            LoadTool.Release();
        }
    }

    public static class LoadTool {
        public static void Load() {
            ToolButton.Create();
            Extensions.Log("LoadTool:Created kian tool.");
        }
        public static void Release() {
            ToolButton.Release();
            Extensions.Log("LoadTool:Removed kian tool.");
        }
    }

    public class LoadingExtention : LoadingExtensionBase {

        public override void OnLevelLoaded(LoadMode mode) {
            Extensions.Log("LoadingExtention.OnLevelLoaded");
            if (mode == LoadMode.LoadGame || mode == LoadMode.NewGame)
                LoadTool.Load();
        }

        public override void OnLevelUnloading() {
            Extensions.Log("LoadingExtention.OnLevelUnloading");
            LoadTool.Release();
        }
    }
} // end namesapce

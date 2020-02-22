using ICities;
using ColossalFramework;
using UnityEngine;
using System;

using ColossalFramework.UI;

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
            //UIView.GetAView().gameObject.AddComponent<PanelExt>();
        }
        public static void Release() {
            var viewGameObject = UIView.GetAView().gameObject;

            void Destroy<T>()
                where T : MonoBehaviour
            {
                T obj = viewGameObject.GetComponent<T>();
                if (obj != null)
                {
                    UnityEngine.Object.Destroy(obj, 10f);
                }
            }

            //Destroy<PanelExt>();
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

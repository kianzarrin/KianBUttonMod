using ICities;
using UnityEngine;
using ColossalFramework.UI;

namespace Kian.Mod
{
    using static ShortCuts;
    public class KianModInfo : IUserMod {
        public string Name => "mono test";
        public string Description => "simple test mod to experiment on lifecyle of monobehaviour objects";

        public void OnEnabled() {
            //System.IO.File.WriteAllText(ShortCuts.filename, ""); //clear file
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
            UIView.GetAView().gameObject.AddComponent<MonoTest>();
        }

        public static void Release() {
            var viewGameObject = UIView.GetAView().gameObject;
            void Destroy<T>()
                where T : MonoBehaviour
            {
                T obj = viewGameObject.GetComponent<T>();
                if (obj != null)
                {
                    Log($"Destroy({obj}, 1f);");
                    UnityEngine.Object.Destroy(obj, 1f);
                }
            }

            Destroy<MonoTest>();
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

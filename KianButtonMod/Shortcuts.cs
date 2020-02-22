using System.Diagnostics;
using ColossalFramework;
using ICities;

namespace Kian
{
    public static class ShortCuts
    {
        public static string filename = "mod.debug.log";
        internal static ref NetNode ToNode(this ushort ID) => ref Singleton<NetManager>.instance.m_nodes.m_buffer[ID];
        internal static ref NetSegment ToSegment(this ushort ID) => ref Singleton<NetManager>.instance.m_segments.m_buffer[ID];
        internal static NetManager netMan => Singleton<NetManager>.instance;

        internal static void Log(string m)
        {
            //var st = System.Environment.StackTrace;
            //m  = st + " : \n" + m;
            UnityEngine.Debug.Log(m);
            System.IO.File.AppendAllText(filename, m + "\n\n");
        }

        static Stopwatch ticks = null;
        internal static void LogWait(string m)
        {
            if (ticks == null)
            {
                Log(m);
                ticks = Stopwatch.StartNew();
            }
            else if (ticks.Elapsed.TotalSeconds > .5)
            {
                Log(m);
                ticks.Reset();
                ticks.Start();
            }
        }


        internal static AppMode currentMode => SimulationManager.instance.m_ManagersWrapper.loading.currentMode;
        internal static bool CheckGameMode(AppMode mode) => CheckGameMode(new[] { mode });
        internal static bool CheckGameMode(AppMode[] modes)
        {
            try
            {
                foreach (var mode in modes)
                {
                    if (currentMode == mode)
                        return true;
                }
            }
            catch { }
            return false;
        }
        internal static bool InGame => CheckGameMode(AppMode.Game);
        internal static bool InAssetEditor => CheckGameMode(AppMode.AssetEditor);
    }
}

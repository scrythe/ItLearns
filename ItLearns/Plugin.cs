using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using ItLearns.Patches;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

namespace ItLearns
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class ItLearns : BaseUnityPlugin
    {
        private const string modGUID = "scrythe.ItLearns";
        private const string modName = "It Learns";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static ItLearns instance;

        internal static new ManualLogSource Log;

        void Awake()
        {
            if (instance == null)
            {
                instance = new ItLearns();
            }

            //Harmony.DEBUG = true;

            Log = base.Logger;

            Log.LogInfo("Mod has awaken");

            Time.timeScale = 100;
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 1;
            harmony.PatchAll(typeof(ItLearns));
            harmony.PatchAll(typeof(MusicPatch));
            harmony.PatchAll(typeof(FPsPatch));
            harmony.PatchAll(typeof(SteamPatch));

            SceneManager.LoadSceneAsync("SampleScene");
        }

        void Update()
        {
            Log.LogInfo(1 / Time.unscaledDeltaTime);
        }
    }
}

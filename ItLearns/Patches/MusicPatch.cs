using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace ItLearns.Patches
{
    [HarmonyPatch(typeof(UIScript))]
    internal class MusicPatch
    {
        [HarmonyPatch("PlayMenuMusic")]
        [HarmonyPostfix]
        static void musicPatch(ref AudioSource ___menuSound)
        {
            ___menuSound.mute = true;
        }
    }
}

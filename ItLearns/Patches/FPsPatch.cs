using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace ItLearns.Patches
{
    [HarmonyPatch(typeof(MouseLook))]
    internal class FPsPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void FpsPatch(ref Camera ___mainCamera)
        {
            Application.targetFrameRate = 1;
            ___mainCamera.enabled = false;
        }
    }
}

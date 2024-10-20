using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace ItLearns.Patches
{
    //[HarmonyPatch(typeof(SteamManager), "Initialize")]
    [HarmonyPatch(typeof(SteamManager))]
    internal class SteamPatch
    {
        //[HarmonyPatch("Awake", MethodType.Normal)]
        //[HarmonyPrefix]
        //static bool AwakePatch(SteamManager __instance)
        //{
        //    var type = __instance.GetType();
        //    var baseType = type.BaseType;

        //    ItLearns.Log.LogInfo($"Class Type: {type.FullName}");
        //    ItLearns.Log.LogInfo($"Base Class Type: {baseType?.FullName}");
        //    ItLearns.Log.LogInfo("Test");
        //    return false;
        //}

        [HarmonyPatch("Awake")]
        [HarmonyTranspiler]
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            ItLearns.Log.LogInfo("Test");
            // Create a list of instructions to modify
            var codes = new List<CodeInstruction>(instructions);
            codes.Insert(0, new CodeInstruction(OpCodes.Ret));
            //ItLearns.Log.LogInfo(codes[0]);
            for (int i = 0; i < codes.Count; i++)
            {
                ItLearns.Log.LogInfo(codes[i]);
                //// Find where the comparison `s_instance != null` is made
                //if (codes[i].opcode == OpCodes.Ldsfld && codes[i + 1].opcode == OpCodes.Brfalse)
                //{
                //    // Insert an early return (ret) before the comparison is made
                //    codes.Insert(i, new CodeInstruction(OpCodes.Ret));
                //    break;
                //}
            }
            return codes.AsEnumerable();
        }
    }
}

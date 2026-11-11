using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;

[HarmonyPatch(typeof(JUnitAvatar), "Update")]
public static class SepiriaMpPatch
{
    [HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        
        var injectCodes = new List<CodeInstruction>
        {
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Call, AccessTools.PropertyGetter(typeof(Time), nameof(Time.frameCount))),
            new CodeInstruction(OpCodes.Ldc_I4, 22),
            new CodeInstruction(OpCodes.Rem),
            new CodeInstruction(OpCodes.Brtrue_S, codes[codes.Count - 1]),

            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(JUnitAvatar), "mp")),
            new CodeInstruction(OpCodes.Ldc_I4_1),
            new CodeInstruction(OpCodes.Add),
            new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(JUnitAvatar), "mp"))
        };

        codes.InsertRange(codes.Count - 1, injectCodes);
        
        return codes;
    }
}

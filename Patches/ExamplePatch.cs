using HarmonyLib;
using Lamb.UI;
using System;
using System.Collections.Generic;
using System.Text;
using MMTools;

namespace NoHitMod.Patches
{
    [HarmonyPatch]
    internal class PlayerControllerPatch
    {
        [HarmonyPatch(typeof(PlayerController), methodName: "OnHit")]
        [HarmonyPostfix]
        public static void PlayerController_OnHit()
        {
            SimulationManager.Pause();
            FollowerManager.Reset();
            StructureManager.Reset();
            UIDynamicNotificationCenter.Reset();
            GameManager.GoG_Initialised = false;
            TwitchManager.Abort();
            SaveAndLoad.DeleteSaveSlot(SaveAndLoad.SAVE_SLOT);
            MMTransition.Play(MMTransition.TransitionType.ChangeSceneAutoResume, MMTransition.Effect.BlackFade, "Main Menu", 0.5f, "", null);
        }
    }
}

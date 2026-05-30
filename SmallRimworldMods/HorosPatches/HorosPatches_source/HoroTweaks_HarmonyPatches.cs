using HarmonyLib;
using RimWorld;
using SandWormLib;
using System.Collections.Generic;
using Verse;

namespace HoroTweaks
{
    public class HoroTweaks_HarmonyPatches
    {
        public HoroTweaks_HarmonyPatches()
        {
            Log.Message("[HoroTweaks] Constructing Patches");
            return;
        }


        [StaticConstructorOnStartup]
        public static class HarmonyInit
        {
            static HarmonyInit()
            {
                HarmonyInit.harmonyInstance.PatchAll();
            }

            public static Harmony harmonyInstance = new Harmony("HoroTweaks.HoroTweaks_HarmonyPatches");
        }


    }
    #region Patches
    [HarmonyPatch(typeof(SandWormQuestUtility), nameof(SandWormQuestUtility.TryDropLuciferiumReward))]
    class SanndWormRewardsPatch
    {
        static bool Prefix(ref bool __result)
        {
            Map anyPlayerHomeMap = Find.AnyPlayerHomeMap;
            bool flag = anyPlayerHomeMap == null;
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                Thing thing = ThingMaker.MakeThing(ThingDefOf.Luciferium, null);
                thing.stackCount = 40;
                Thing thingTwo = ThingMaker.MakeThing(ThingDefOf.ComponentSpacer, null);
                thingTwo.stackCount = 33;
                Thing thingThree = ThingMaker.MakeThing(ThingDefOf.Gold, null);
                thingThree.stackCount = 1000;
                Thing thingFour = ThingMaker.MakeThing(ThingDefOf.MedicineUltratech, null);
                thingFour.stackCount = 55;

                IntVec3 intVec = DropCellFinder.TradeDropSpot(anyPlayerHomeMap);
                DropPodUtility.DropThingsNear(intVec, anyPlayerHomeMap, new List<Thing> { thing, thingTwo,thingThree,thingFour }, 110, false, false, true, true, true, null);
                Find.LetterStack.ReceiveLetter(Translator.Translate("SandWorm_Quest_LuciferiumReward_Label"), Translator.Translate("SandWorm_Quest_LuciferiumReward_Text"), LetterDefOf.PositiveEvent, new TargetInfo(intVec, anyPlayerHomeMap, false), null, null, null, null, 0, true);
                flag2 = true;
                
            }

            __result = flag2;
            // make sure you only skip if really necessary
            //Returning a bool as well as setting a result is necessary https://harmony.pardeike.net/articles/patching-prefix.html
            return false; 
        }
    }
    #endregion
}

using System;
using RimWorld;
using UnityEngine;
using Verse;

namespace FoxOverhaul
{
    public class IncidentWorker_FoxPassing_Shell : IncidentWorker
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            Map map = (Map)parms.target;
            IntVec3 cell;
            return !map.gameConditionManager.ConditionIsActive(GameConditionDefOf.ToxicFallout) && map.mapTemperature.SeasonAndOutdoorTemperatureAcceptableFor(ThingDef.Named("NBF_Fox_ShellRace"), 0f) && this.TryFindEntryCell(map, out cell);
        }

        // Token: 0x06000002 RID: 2 RVA: 0x000020A8 File Offset: 0x000002A8
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = (Map)parms.target;
            IntVec3 cell;
            bool flag = !this.TryFindEntryCell(map, out cell);
            bool flag2;
            if (flag)
            {
                flag2 = false;
            }
            else
            {
                PawnKindDef pawnKindDef = PawnKindDef.Named("NBF_Fox_Shell");
                int num = GenMath.RoundRandom(StorytellerUtility.DefaultThreatPointsNow(map) / pawnKindDef.combatPower);
                int num2 = Rand.RangeInclusive(3, 6);
                num = Mathf.Clamp(num, 2, num2);
                int num3 = Rand.RangeInclusive(90000, 150000);
                IntVec3 result = IntVec3.Invalid;
                bool flag3 = !RCellFinder.TryFindRandomCellOutsideColonyNearTheCenterOfTheMap(cell, map, 10f, out result);
                if (flag3)
                {
                    result = IntVec3.Invalid;
                }
                int num4 = 0;
                bool flag4 = num4 < num;
                if (flag4)
                {
                    IntVec3 intVec = CellFinder.RandomClosewalkCellNear(cell, map, 10, null);
                    Pawn pawn = PawnGenerator.GeneratePawn(pawnKindDef, null);
                    GenSpawn.Spawn(pawn, intVec, map, Rot4.Random, 0, false, false);
                    pawn.mindState.exitMapAfterTick = Find.TickManager.TicksGame + num3;
                    bool isValid = result.IsValid;
                    if (isValid)
                    {
                        pawn.mindState.forcedGotoPosition = CellFinder.RandomClosewalkCellNear(result, map, 10, null);
                    }
                    base.SendStandardLetter(TranslatorFormattedStringExtensions.Translate("LetterLabelShellFoxPassing", pawnKindDef.label).CapitalizeFirst(), TranslatorFormattedStringExtensions.Translate("LetterShellFoxPassing", pawnKindDef.label), LetterDefOf.PositiveEvent, parms, pawn, Array.Empty<NamedArgument>());
                    flag2 = true;
                }
                else
                {
                    flag2 = true;
                }
            }
            return flag2;
        }

        private bool TryFindEntryCell(Map map, out IntVec3 cell)
        {
            return RCellFinder.TryFindRandomPawnEntryCell(out cell, map, CellFinder.EdgeRoadChance_Animal + 0.2f, false, null);
        }
    }
}

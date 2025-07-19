using LavaPower;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace RimWorld
{
    public class PlaceWorker_LavaGenerator : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null, Thing thing = null)
        {
            using (IEnumerator<IntVec3> enumerator = CompPowerPlantLava.GroundCells(loc, rot).GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (!enumerator.Current.GetAffordances(map).Contains(TerrainAffordanceDefOf.Heavy))
                    {
                        return new AcceptanceReport("TerrainCannotSupport_TerrainAffordance".Translate(checkingDef, TerrainAffordanceDefOf.Heavy));
                    }
                }
            }
            if (!this.MagmaCellsPresent(loc, rot, map))
            {
                return new AcceptanceReport("MustBeOnMagmaMessage".Translate());
            }
            return true;
        }

        private bool MagmaCellsPresent(IntVec3 loc, Rot4 rot, Map map)
        {
            if (!loc.InBounds(map) || !loc.GetTerrain(map).HasTag("Lava"))
            {
                return false;
            }
            return true;
        }

        public override void DrawGhost(ThingDef def, IntVec3 loc, Rot4 rot, Color ghostCol, Thing thing = null)
        {
            GenDraw.DrawFieldEdges(CompPowerPlantLava.GroundCells(loc, rot).ToList<IntVec3>(), Color.white, null, null, 2900);
            Color color = (this.MagmaCellsPresent(loc, rot, Find.CurrentMap) ? Designator_Place.CanPlaceColor.ToOpaque() : Designator_Place.CannotPlaceColor.ToOpaque());
            GenDraw.DrawFieldEdges(CompPowerPlantLava.MagmaCells(loc, rot).ToList<IntVec3>(), color, null, null, 2900);
        }

        public override IEnumerable<TerrainAffordanceDef> DisplayAffordances()
        {
            yield return TerrainAffordanceDefOf.Heavy;
            yield break;
        }

    }
}

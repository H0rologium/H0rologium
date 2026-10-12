using RimWorld;
using System.Collections.Generic;
using Verse;

namespace LavaPower
{
    [StaticConstructorOnStartup]
    public class CompPowerPlantLava : CompPowerPlant
    {
        private int stBPG;
        public CompPowerPlantLava()
        {
            stBPG = LoadedModManager.GetMod<LavaPower>().GetSettings<LavaSettings>().basePower;
        }

        protected override float DesiredPowerOutput
        {
            get
            {
                return (stBPG == 4000 || stBPG == base.DesiredPowerOutput) ? base.DesiredPowerOutput : stBPG;
            }
        }


        public IEnumerable<IntVec3> MagmaCells()
        {
            return MagmaCells(parent.Position, parent.Rotation);
        }

        public static IEnumerable<IntVec3> MagmaCells(IntVec3 loc, Rot4 rot)
        {
            IntVec3 perpOffset = rot.Rotated(RotationDirection.Counterclockwise).FacingCell;
            yield return loc + rot.FacingCell * 3;
            yield return loc + rot.FacingCell * 3 - perpOffset * 2;
            yield return loc + rot.FacingCell * 3 - perpOffset;
            yield return loc + rot.FacingCell * 3 + perpOffset * 2;
            yield return loc + rot.FacingCell * 3 + perpOffset;
            yield return loc + rot.FacingCell * 4;
            yield return loc + rot.FacingCell * 4 - perpOffset * 2;
            yield return loc + rot.FacingCell * 4 - perpOffset;
            yield return loc + rot.FacingCell * 4 + perpOffset * 2;
            yield return loc + rot.FacingCell * 4 + perpOffset;
        }


        public IEnumerable<IntVec3> GroundCells()
        {
            return GroundCells(parent.Position, parent.Rotation);
        }

        public static IEnumerable<IntVec3> GroundCells(IntVec3 loc, Rot4 rot)
        {
            IntVec3 perpOffset = rot.Rotated(RotationDirection.Counterclockwise).FacingCell;
            yield return loc - rot.FacingCell * 2;
            yield return loc - rot.FacingCell * 2 - perpOffset;
            yield return loc - rot.FacingCell * 2 + perpOffset;
            yield return loc - rot.FacingCell;
            yield return loc - rot.FacingCell - perpOffset;
            yield return loc - rot.FacingCell + perpOffset;
        }
    }

}

using UnityEngine;
using Verse;

namespace LavaPower
{
    public class LavaSettings : ModSettings
    {
        public int basePower = 4000;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref basePower, "basePower", 4000);
            base.ExposeData();
        }
    }

    public class LavaPower : Mod
    {
        LavaSettings settings;
        private float power_slider_val = 4000f;

        public LavaPower(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<LavaSettings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard lst = new Listing_Standard();
            power_slider_val = (float)settings.basePower;

            lst.Begin(inRect);

            lst.Label("Requires a game restart to apply\n");
            lst.Label($"\nPower generation per generator: {settings.basePower}");
            settings.basePower = Mathf.RoundToInt(lst.Slider(power_slider_val,2000f,8000f));

            if(lst.ButtonText("Default",null,0.1f))
            {
                power_slider_val = 4000f;
                settings.basePower = 4000;
            }

            lst.End();
            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "Lava Power";
        }
    }

}


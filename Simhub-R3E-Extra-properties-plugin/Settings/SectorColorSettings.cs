using ColorHelper;

namespace Simhub_R3E_Extra_properties_plugin.Settings
{
    public class SectorColorSettings
    {
        public SectorColorSettings()
        {
            HSV bgNotRun = new HSV(150, 12, 7);
            HSV bgSlow = new HSV(50,100,100);
            HSV bgpersonalBest = new HSV(120,71,85);
            HSV bgOverallBest = new HSV(288,81,82);
            Colors background = new Colors(bgNotRun,bgSlow,bgpersonalBest, bgOverallBest);

            HSV fontNotRun = new HSV(0, 0, 100);
            HSV fontSlow = new HSV(150, 12, 7);
            HSV fontpersonalBest = new HSV(150, 12, 7);
            HSV fontOverallBest = new HSV(150, 12, 7);
            Colors font = new Colors(fontNotRun, fontSlow, fontpersonalBest, fontOverallBest);

            this.Sector = new SectorColor(font, background);
        }
        public SectorColor Sector { get; set; }
        public class SectorColor
        {
            public SectorColor() { }
            public SectorColor(Colors font, Colors background)
            {
                Font = font;
                Background = background;
            }

            public Colors Font { get; set; }
            public Colors Background { get; set; }
        }
        public class Colors
        {
            public Colors() { }
            public Colors(HSV notRun, HSV slow, HSV personalBest, HSV overallBest)
            {
                NotRun = notRun;
                Slow = slow;
                PersonalBest = personalBest;
                OverallBest = overallBest;
            }

            public HSV NotRun { get; set; }
            public HSV Slow { get; set; }
            public HSV PersonalBest { get; set; }
            public HSV OverallBest { get; set; }
        }
    }
}

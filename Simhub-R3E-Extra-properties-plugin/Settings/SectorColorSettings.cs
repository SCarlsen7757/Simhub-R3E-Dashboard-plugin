using System.Windows.Media;

namespace Simhub_R3E_Extra_properties_plugin.Settings
{
    public class SectorColorSettings
    {
        public SectorColorSettings()
        {
            Color bgNotRun = new Color() {A = 255, R = 16, G = 18, B = 17 };
            Color bgSlow = new Color() { A = 255, R = 255, G = 213, B = 0 };
            Color bgpersonalBest = new Color() {A = 255, R = 63, G = 217, B = 63 };
            Color bgOverallBest = new Color() {A = 255, R = 175, G = 40, B = 209 };
            Colors background = new Colors(bgNotRun, bgSlow, bgpersonalBest, bgOverallBest);

            Color fontNotRun = new Color() {A = 255, R = 255, G = 255, B = 255 };
            Color fontSlow = new Color() {A = 255, R = 16, G = 18, B = 17 };
            Color fontpersonalBest = new Color() {A = 255, R = 16, G = 18, B = 17 };
            Color fontOverallBest = new Color() {A = 255, R = 16, G = 18, B = 17 };
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
            public Colors(Color notRun, Color slow, Color personalBest, Color overallBest)
            {
                NotRun.Color = notRun;
                Slow.Color = slow;
                PersonalBest.Color = personalBest;
                OverallBest.Color = overallBest;
            }

            public Models.Color.ExtendedColor NotRun { get; set; } = new Models.Color.ExtendedColor();
            public Models.Color.ExtendedColor Slow { get; set; } = new Models.Color.ExtendedColor();
            public Models.Color.ExtendedColor PersonalBest { get; set; } = new Models.Color.ExtendedColor();
            public Models.Color.ExtendedColor OverallBest { get; set; } = new Models.Color.ExtendedColor();
        }
    }
}

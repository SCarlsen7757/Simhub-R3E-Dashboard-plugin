using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Dashboard_plugin.Models.Sector
{
    public class Sector : Prefix
    {
        public Sector() : base() { }
        public Sector(string prefix) : base(prefix)
        {
            this.Color = new R3ESectorColor(_prefix);
        }
        public Sector(List<string> prefixList) : base(prefixList)
        {
            this.Color = new R3ESectorColor(_prefix);
        }
        public Sector(List<string> prefixList, string prefix) : base(prefixList, prefix)
        {
            this.Color = new R3ESectorColor(_prefix);
        }

        public R3ESectorColor Color { get; set; }

        public SectorTime Time { get; set; }
        public class SectorTime
        {
            public SectorTime() { }
            public SectorTime(float? @new, float last, float overallBest, float personalBest)
            {
                New = @new;
                Last = last;
                OverallBest = overallBest;
                PersonalBest = personalBest;
            }

            public float? New { get; set; } = null;
            public float Last { get; set; } = 0;
            public float OverallBest { get; set; } = 0;
            public float PersonalBest { get; set; } = 0;
        }
    }
}

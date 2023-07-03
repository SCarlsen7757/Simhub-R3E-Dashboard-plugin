using Simhub_R3E_Tyre_and_brake_color_plugin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Tyre_and_brake_color_plugin.Models
{
    public class TyresInformation : ISetTemperature
    {
        public TyresInformation() { }
        public LeftRightSet<OMITemperatureInformation> Front { get; set; } = new LeftRightSet<OMITemperatureInformation>();
        public LeftRightSet<OMITemperatureInformation> Rear { get; set; } = new LeftRightSet<OMITemperatureInformation>();

        public double OptimalTemperature
        {
            set
            {
                Front.Left.Outer.Optimal.Value = value;
                Front.Right.Outer.Optimal.Value = value;
                Rear.Left.Outer.Optimal.Value = value;
                Rear.Right.Outer.Optimal.Value = value;

                Front.Left.Middle.Optimal.Value = value;
                Front.Right.Middle.Optimal.Value = value;
                Rear.Left.Middle.Optimal.Value = value;
                Rear.Right.Middle.Optimal.Value = value;

                Front.Left.Inner.Optimal.Value = value;
                Front.Right.Inner.Optimal.Value = value;
                Rear.Left.Inner.Optimal.Value = value;
                Rear.Right.Inner.Optimal.Value = value;
            }
        }

        public Range OptimalRange
        {
            set
            {
                Front.Left.Outer.Optimal.Range = value;
                Front.Right.Outer.Optimal.Range = value;
                Rear.Left.Outer.Optimal.Range = value;
                Rear.Right.Outer.Optimal.Range = value;

                Front.Left.Middle.Optimal.Range = value;
                Front.Right.Middle.Optimal.Range = value;
                Rear.Left.Middle.Optimal.Range = value;
                Rear.Right.Middle.Optimal.Range = value;

                Front.Left.Inner.Optimal.Range = value;
                Front.Right.Inner.Optimal.Range = value;
                Rear.Left.Inner.Optimal.Range = value;
                Rear.Right.Inner.Optimal.Range = value;
            }
        }
        public double Max
        {
            set
            {
                Front.Left.Outer.Max = value;
                Front.Right.Outer.Max = value;
                Rear.Left.Outer.Max = value;
                Rear.Right.Outer.Max = value;

                Front.Left.Middle.Max = value;
                Front.Right.Middle.Max = value;
                Rear.Left.Middle.Max = value;
                Rear.Right.Middle.Max = value;

                Front.Left.Inner.Max = value;
                Front.Right.Inner.Max = value;
                Rear.Left.Inner.Max = value;
                Rear.Right.Inner.Max = value;
            }
        }
        public double Min
        {
            set
            {
                Front.Left.Outer.Min = value;
                Front.Right.Outer.Min = value;
                Rear.Left.Outer.Min = value;
                Rear.Right.Outer.Min = value;

                Front.Left.Middle.Min = value;
                Front.Right.Middle.Min = value;
                Rear.Left.Middle.Min = value;
                Rear.Right.Middle.Min = value;

                Front.Left.Inner.Min = value;
                Front.Right.Inner.Min = value;
                Rear.Left.Inner.Min = value;
                Rear.Right.Inner.Min = value;
            }
        }
    }
}

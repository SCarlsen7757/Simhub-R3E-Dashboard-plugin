using GameReaderCommon;
using Simhub_R3E_Tyre_and_brake_color_plugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Tyre_and_brake_color_plugin.Model
{
    public class BrakesInformation : ISetTemperature
    {
        public LeftRightSet<ComponentTemperatureInformation> Front { get; set; } = new LeftRightSet<ComponentTemperatureInformation>();
        public LeftRightSet<ComponentTemperatureInformation> Rear { get; set; } = new LeftRightSet<ComponentTemperatureInformation>();
        public void SetTemperature(StatusDataBase data)
        {
            Front.Left.Temperature = data.BrakeTemperatureFrontLeft;
            Front.Right.Temperature = data.BrakeTemperatureFrontRight;
            Rear.Left.Temperature = data.BrakeTemperatureRearLeft;
            Rear.Right.Temperature = data.BrakeTemperatureRearRight;
        }
        public double OptimalTemperature
        {
            set
            {
                Front.Left.Optimal.Value = value;
                Front.Right.Optimal.Value = value;
                Rear.Left.Optimal.Value = value;
                Rear.Right.Optimal.Value = value;
            }
        }
        public Range OptimalRange
        {
            set
            {
                Front.Left.Optimal.Range = value;
                Front.Right.Optimal.Range = value;
                Rear.Left.Optimal.Range = value;
                Rear.Right.Optimal.Range = value;
            }
        }
        public double Max
        {
            set
            {
                Front.Left.Max = value;
                Front.Right.Max = value;
                Rear.Left.Max = value;
                Rear.Right.Max = value;
            }
        }
        public double Min
        {
            set
            {
                Front.Left.Min = value;
                Front.Right.Min = value;
                Rear.Left.Min = value;
                Rear.Right.Min = value;
            }
        }
    }

    
}

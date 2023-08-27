using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Simhub_R3E_Extra_properties_plugin.Settings.UI
{
    /// <summary>
    /// Interaction logic for R3EExtraPropertiesUI.xaml
    /// </summary>
    public partial class R3EExtraPropertiesUI : UserControl
    {
        public R3EExtraPropertiesUI()
        {
            InitializeComponent();
            SectorColorSettingsUI.DataContext = R3EExtraProperties.SectorColorSettings;
            TyreAndBrakeColorSettingsUI.DataContext = R3EExtraProperties.TyreAndBrakeColorSettings;
        }
    }
}

using System.Windows.Controls;

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

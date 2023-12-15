using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace Simhub_R3E_Extra_properties_plugin.Settings.UI
{
    /// <summary>
    /// Interaction logic for TyreAndBrakeColorSettingsUI.xaml
    /// </summary>
    public partial class TyreAndBrakeColorSettingsUI : UserControl
    {
        public TyreAndBrakeColorSettingsUI()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

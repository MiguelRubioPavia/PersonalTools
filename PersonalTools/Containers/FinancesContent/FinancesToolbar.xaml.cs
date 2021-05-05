using PersonalToolsDesktop.Containers;
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

namespace PersonalTools.Panels.FinancesContent
{
    /// <summary>
    /// Lógica de interacción para FinancesToolbar.xaml
    /// </summary>
    public partial class FinancesToolbar : UserControl
    {
        public event EventHandler OnListSelected;
        public event EventHandler OnConfigurationSelected;

        public FinancesToolbar()
        {
            InitializeComponent();
        }

        private void OpenList_Click(object sender, RoutedEventArgs e) => OnListSelected?.Invoke(this, EventArgs.Empty);

        private void OpenConfiguration_Click(object sender, RoutedEventArgs e) => OnConfigurationSelected?.Invoke(this, EventArgs.Empty);
    }
}

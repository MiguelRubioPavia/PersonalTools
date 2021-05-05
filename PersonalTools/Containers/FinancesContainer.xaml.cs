using PersonalTools.Containers.FinancesContent;
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

namespace PersonalToolsDesktop.Containers
{
    /// <summary>
    /// Lógica de interacción para FinancesPanel.xaml
    /// </summary>
    public partial class FinancesContainer : UserControl
    {
        private Type _currentControlType;

        public FinancesContainer()
        {
            InitializeComponent();

            ChangePanel(typeof(FinancesList));
        }

        private void FinancesToolbar_OnListSelected(object sender, EventArgs e)
        {
            ChangePanel(typeof(FinancesList));
        }

        private void FinancesToolbar_OnConfigurationSelected(object sender, EventArgs e)
        {
            ChangePanel(typeof(FinancesCreation));
        }

        private void ChangePanel(Type target)
        {
            if (_currentControlType != target.UnderlyingSystemType)
            {
                _currentControlType = target;
                contentControl.Content = target.GetConstructor(new Type[0]).Invoke(new object[0]);
            }
        }
    }
}

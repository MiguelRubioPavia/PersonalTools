using Model;
using PersonalTools.Views.FinancesContent;
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
        private DataContext _dataContext;

        public FinancesContainer()
        {
            InitializeComponent();

            _dataContext = new DataContext();

            _currentControlType = typeof(FinancesList);
            contentControl.Content = new FinancesList();
        }

        private void FinancesToolbar_OnListSelected(object sender, EventArgs e)
        {
            contentControl.Content = new FinancesList();
        }

        private void FinancesToolbar_OnConfigurationSelected(object sender, EventArgs e)
        {
            contentControl.Content = new FinancesCreationView(_dataContext);
        }

        //private bool IsCurrentPanel(Type target)
        //{
        //    _currentControlType = target;
        //    return (_currentControlType != target.UnderlyingSystemType)
        //    {
        //        contentControl.Content = target.GetConstructor(new Type[0]).Invoke(new object[0]);
        //    }
        //}
    }
}

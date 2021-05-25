using Model;
using Model.Entities;
using PersonalTools.ViewModels.FinancesContent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace PersonalTools.Views.FinancesContent
{
    /// <summary>
    /// Lógica de interacción para FinancesCreation.xaml
    /// </summary>
    public partial class FinancesCreationView : UserControl
    {
        public FinancesCreationView(FinancesCreationViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}

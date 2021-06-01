using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PersonalTools
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SetUpLanguage();
        }

        private void SetUpLanguage()
        {
            switch (Thread.CurrentThread.CurrentCulture.ToString())
            {
                case "es-ES":
                    Language.Common.Culture = new System.Globalization.CultureInfo("es-ES");
                    break;

                default:
                    Language.Common.Culture = new System.Globalization.CultureInfo("en");
                    break;
            }
        }
    }
}

using EasyHunt.HMI.Main;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EasyHunt
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainViewModel MainViewModelInstance { get; set; }

        public App()
        {
            MainViewModelInstance = new MainViewModel();
        }
    }
}

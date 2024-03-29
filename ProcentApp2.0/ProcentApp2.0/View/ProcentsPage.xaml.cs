﻿using ProcentApp2._0.Models;
using ProcentApp2._0.ViewModels;
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

namespace ProcentApp2._0.View
{
    /// <summary>
    /// Логика взаимодействия для ProcentsPage.xaml
    /// </summary>
    public partial class ProcentsPage : Page
    {
        public ProcentsPage()
        {
            InitializeComponent();
        }

        public ProcentsPage(MainPageModel model)
        {
            InitializeComponent();

            DataContext = new ProcentsVM(model);
        }
    }
}

﻿using ProcentApp2._0.Models;
using ProcentApp2._0.View;
using ProcentApp2._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace ProcentApp2._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Обычный конструктор
        public MainWindow()
        {
            InitializeComponent();

            myframe.Content = new MainPage();

        }

        public MainWindow(MainPageModel model)
        {
            InitializeComponent();

            myframe.Content = new ProcentsPage(model);
        }



    }
}

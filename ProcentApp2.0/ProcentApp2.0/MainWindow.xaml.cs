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
        private DateTime dmb = new DateTime(2020, 7, 9, 6, 30, 0); // Дата дембеля 9 июля 2020 года
        private DateTime datearmy = new DateTime(2019, 7, 9, 6, 30, 0); // Дата отправки в армию

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();

            datepick.DisplayDateStart = DateTime.Now;

            //var date = dmb - DateTime.Now; // До дембеля осталось
            //var exp = DateTime.Now - datearmy; // Прошло времени
            
            //dateexp.Content = $"Время службы: {exp.Days} дней {exp.Hours} часов {exp.Minutes} минут {exp.Seconds} секунд";
            //dmbtimelb.Content = $"До дембеля: {date.Days} дней {date.Hours} часов {date.Minutes} минут {date.Seconds} секунд";



            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Tick += new EventHandler(dmbtick);
            //timer.Interval = new TimeSpan(0, 0, 1);
            //timer.Start();
        }


        // Метод, который делает тик таймера
        private void dmbtick(object sender, EventArgs e)
        {

            var date = dmb - DateTime.Now; // До дембеля осталось
            var exp = DateTime.Now - datearmy; // Прошло времени

            dateexp.Content = $"Время службы: {exp.Days} дней {exp.Hours} часов {exp.Minutes} минут {exp.Seconds} секунд";
            dmbtimelb.Content = $"До дембеля: {date.Days} дней {date.Hours} часов {date.Minutes} минут {date.Seconds} секунд";

        }




        #region События

        // Событие которое принимает только цифры при вводе в текст бокс
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!int.TryParse(e.Text, out val))
            {
                e.Handled = true; // отклоняем ввод
            }
        }


        private void TextBox_PreviewTextInput2(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!int.TryParse(e.Text, out val) && e.Text != ",")
            {
                e.Handled = true; // отклоняем ввод
            }
        }

        #endregion
    }
}

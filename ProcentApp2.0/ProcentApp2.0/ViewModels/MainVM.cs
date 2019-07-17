using ProcentApp2._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ProcentApp2._0.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {

        #region Свойства

        private string _text; // Для вывода времени
        private long _StartSum; // Начальная сумма инвестиций
        private string _Procent; // Процент суммирования (В стринге т.к. проблемы с приемкой запятой в привязке)
        private DateTime _EndDate; // Дата конца инвестиций
        private string _Summarize; // Сумма реинвестирования
        private string _PutOff; // Докладываем с внешних источников каждый месяц (зп)

        public string text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged("text");
            }
        }
        public long StartSum
        {
            get => _StartSum;
            set
            {
                _StartSum = value;                
                OnPropertyChanged("StartSum");
            }
        }
        public string Procent
        {
            get => _Procent;
            set
            {
                if (_Procent != value)
                {
                    _Procent = value;
                    OnPropertyChanged("Procent");
                }
            }
        }
        public DateTime EndDate
        {
            get => _EndDate;
            set
            {
                _EndDate = value;
                OnPropertyChanged("EndDate");
            }
        }
        public string Summarize
        {
            get => _Summarize;
            set
            {
                _Summarize = value;
                OnPropertyChanged("Summarize");
            }
        }
        public string PutOff
        {
            get => _PutOff;
            set
            {
                _PutOff = value;
                OnPropertyChanged("PutOff");
            }
        }

        #endregion

        #region Секция команд
        private ICommand _sumCommand;
        public ICommand SumCommand => _sumCommand ?? (_sumCommand = new DelegateCommand(OnSum));
        public ICommand test { get; private set; }
        #endregion

        #region Секция методов
        private void OnSum(object parameter)
        {

            // Формируем модель (Необходимы соответствующие преобразования из string ->
            MainPageModel model = new MainPageModel();
            model.EndDate = EndDate;
            model.StartSum = StartSum;

            double s;
            double.TryParse(Procent, out s);
            model.Procent = s;

            long tes;
            
            long.TryParse(Summarize, out tes);
            model.Summarize = tes;
            long.TryParse(PutOff, out tes);
            model.PutOff = tes;


            // Если ввели стартовые необходимые значения, то открой окно и посчитай
            if (model.StartSum != 0 && model.Procent != 0 && model.EndDate != null)
            {
                // Если дату выбрали больше одного месяца, то открой новое окно и передай в него данные
                if (model.EndDate >= DateTime.Now.AddMonths(1))
                    new MainWindow(model).ShowDialog();
                // Иначе выведи ошибку
                else
                {
                    MessageBox.Show($"Выберите больше, чем один месяц");
                }
            }
            else
                MessageBox.Show($"Введите начальные значения");
        }        
        private void OnDiff(object parameter)
        {
            MessageBox.Show("hello world!");
        }
        #endregion

        #region Конструктор
        public MainVM()
        {
            test = new DelegateCommand(OnDiff);
            EndDate = DateTime.Now;
            StartSum = 2000000;
            Procent = "3,5";

            StartTimer();
        }
        #endregion

        #region Таймер

        // Таймер
        public void StartTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(dmbtick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }


        // Метод, который делает тик таймера
        private void dmbtick(object sender, EventArgs e)
        {
            text = $"{DateTime.Now}";

            //var date = dmb - DateTime.Now; // До дембеля осталось
            //var exp = DateTime.Now - datearmy; // Прошло времени

            //dateexp.Content = $"Время службы: {exp.Days} дней {exp.Hours} часов {exp.Minutes} минут {exp.Seconds} секунд";
            //dmbtimelb.Content = $"До дембеля: {date.Days} дней {date.Hours} часов {date.Minutes} минут {date.Seconds} секунд";

        }
        #endregion

        #region Реализация интерфейса INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

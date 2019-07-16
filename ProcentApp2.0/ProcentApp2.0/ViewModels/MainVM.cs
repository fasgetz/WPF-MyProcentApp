using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProcentApp2._0.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {

        #region Свойства

        private int _StartSum; // Начальная сумма инвестиций
        private double _Procent; // Процент суммирования
        private DateTime _EndDate; // Дата конца инвестиций
        private int _Summarize; // Сумма реинвестирования
        private int _PutOff; // Докладываем с внешних источников каждый месяц (зп)

        public int StartSum
        {
            get => _StartSum;
            set
            {
                _StartSum = value;
                PutOff++;
                OnPropertyChanged("StartSum");
            }
        }
        public double Procent
        {
            get => _Procent;
            set
            {
                _Procent = value;
                OnPropertyChanged("Procent");
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
        public int Summarize
        {
            get => _Summarize;
            set
            {
                _Summarize = value;
                OnPropertyChanged("Summarize");
            }
        }
        public int PutOff
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
            MessageBox.Show("hello world!");
        }        
        private void OnDiff(object parameter)
        {
            MessageBox.Show("hello world!");
        }
        #endregion

        #region Конструктор
        public MainVM()
        {
            EndDate = DateTime.Now;
            test = new DelegateCommand(OnDiff);
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

using ProcentApp2._0.AppLogic;
using ProcentApp2._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProcentApp2._0.ViewModels
{
    class ProcentsVM : INotifyPropertyChanged
    {
        #region Свойства

        private double _EarnedSum; // Заработанная сумма
        private double _AllCapital; // Вся итоговая сумма (Стартовый капитал + Заработанная сумма)

        public double EarnedSum
        {
            get => _EarnedSum;
            set
            {
                _EarnedSum = value;
                OnPropertyChanged("EarnedSum");
            }
        }

        public double AllCapital
        {
            get => _AllCapital;
            set
            {
                _AllCapital = value;
                OnPropertyChanged("AllCapital");
            }
        }


        // Месяцев в обороте
        private int _Month;
        public int Month
        {
            get => _Month;
            set
            {
                _Month = value;
                OnPropertyChanged("Month");
            }
        }

        private MainPageModel _mymodel;
        public MainPageModel mymodel
        {
            get => _mymodel;
            set
            {
                _mymodel = value;
                OnPropertyChanged("mymodel");
            }
        }

        List<string> _list;
        public List<string> list
        {
            get => _list;
            set
            {
                _list = value;
                OnPropertyChanged("list");
            }
        }

        #endregion

        public ProcentsVM(MainPageModel model)
        {
            mymodel = model;

            list = new List<string>();


            // Получаем сколько всего месяцев капитал будет в обороте
            Month = (mymodel.EndDate - DateTime.Now).Days / 30; // Количество месяцев

            AllCapital = mymodel.StartSum; // Для инициализации общего капитала
            EarnedSum = 0; // Заработанная сумма


            StartInvseting();
            AllCapital += EarnedSum;

        }

        #region Методы


        // Стартовый метод для инициализации
        private void StartInvseting()
        {
            double residue = 0; // Остаточная сумма
            double startcap = mymodel.StartSum; // Стартовый капитал

            // Считаем заработок за каждый месяц
            for (int i = 0; i < Month; i++)
            {
                double MonthSum = Calculate.GetProcent(startcap, mymodel.Procent); // Месячный доход

                // Добавляем к остаточной сумме нашу зп (если ее выбрали)
                if (mymodel.PutOff != 0)
                    MonthSum += mymodel.PutOff;

                residue += MonthSum; // Добавляем к остаточной сумме 

                EarnedSum += MonthSum; // Прибавляем к заработанному капиталу сумму


                string s = $"Месяц {i + 1} | Доход с процентов {MonthSum - mymodel.PutOff}";
                if (mymodel.PutOff != 0)
                    s += $" | Сумма всего (С зп): {MonthSum}";

                list.Add(s);



                // Если заработанная сумма достигла больше суммы, которую можно добавить,
                // то добавь к капиталу для увеличения ежемесечных процентов
                if (residue > mymodel.Summarize && mymodel.Summarize != 0)
                {

                    var temp = residue - mymodel.Summarize; // Остаточная сумма
                    startcap += mymodel.Summarize; // Добавляем к капиталу накопленную сумму. Теперь будет больше %

                    residue = temp; // Остаточная сумма = Накопленная сумма - добавляемая сумма

                }
            }
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

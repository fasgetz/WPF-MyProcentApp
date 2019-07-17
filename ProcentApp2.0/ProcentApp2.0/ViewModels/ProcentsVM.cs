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

            // Получаем сколько всего месяцев капитал будет в обороте
            Month = (mymodel.EndDate - DateTime.Now).Days / 30; // Количество месяцев
        }

        #region Методы



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

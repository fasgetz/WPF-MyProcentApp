using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcentApp2._0.Models
{
    public class MainPageModel
    {

        public long StartSum { get; set; } // Начальная сумма инвестиций
        public double Procent { get; set; } // Процент суммирования (В стринге т.к. проблемы с приемкой запятой в привязке)
        public DateTime EndDate { get; set; } // Дата конца инвестиций
        public long Summarize { get; set; } // Сумма реинвестирования
        public long PutOff { get; set; } // Докладываем с внешних источников каждый месяц (зп)
    }
}

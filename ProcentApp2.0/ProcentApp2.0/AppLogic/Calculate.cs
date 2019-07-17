using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcentApp2._0.AppLogic
{

    /// <summary>
    /// В классе содержится весь вычислительный функционал
    /// </summary>

    public static class Calculate
    {

        /// <summary>
        /// Метод, который вычисляет процент
        /// </summary>
        /// <returns>Возвращает процент от суммы</returns>
        public static double GetProcent(double sum, double procent)
        {
            return ((sum / 100) * procent);
        }
    }
}

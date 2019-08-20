using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiburTest2
{
    class Вектор
    {
        public Точка Начало { get; set; }
        public Точка Конец { get; set; }
        public Вектор()
        {
            Начало = new Точка();
            Конец = new Точка();
        }
        public Вектор(double x, double y)
        {
            Начало = new Точка(0, 0);
            Конец = new Точка(x, y);
        }
        public Вектор(Точка т1, Точка т2)
        {
            Начало = т1;
            Конец = т2;
        }
        public string Координаты()
        {
            return string.Format("Координаты точек вектора: ({0}, {1})/nКоординаты вектора: ({2}, {3})", Начало.Координаты(true), Конец.Координаты(true), Конец.X - Начало.X, Конец.Y - Начало.Y);
        }
        public bool Перпендикулярен(Вектор в)
        {
            double а1 = Конец.X - Начало.X,
            а2 = Конец.Y - Начало.Y,
            в1 = в.Конец.X - в.Начало.X,
            в2 = в.Конец.Y - в.Начало.Y;
            if (а1 * в1 + а2 * в2 == 0) return true;
            return false;
        }
    }
}

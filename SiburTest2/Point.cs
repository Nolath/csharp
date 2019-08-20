using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiburTest2
{
    class Точка
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Точка()
        {
            X = 0;
            Y = 0;
        }
        public Точка(double x, double y)
        {
            X = x;
            Y = y;
        }
        public string Координаты(bool сокр)
        {
            if (сокр) return string.Format("({0}, {1})", X, Y);
            else return string.Format("Координаты точки: ({0}, {1})", X, Y);
        }
        public void ПереместитьПоВектору(Вектор в)
        {
            X += в.Конец.X - в.Начало.X;
            Y += в.Конец.Y - в.Начало.Y;
        }
        public void Поворот(double градус, Точка т)
        {
            double радиан = Math.PI * градус / 180.0;
            double новыйX, новыйY;
            новыйX = (X - т.X) * Math.Cos(радиан) - (Y - т.Y) * Math.Sin(радиан);
            новыйY = (X - т.X) * Math.Sin(радиан) + (Y - т.Y) * Math.Cos(радиан);
            X = новыйX;
            Y = новыйY;
        }
    }
}

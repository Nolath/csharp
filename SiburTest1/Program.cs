using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiburTest1 {
    class Program {
        static string[] РазделитьСтроку(string стр, string[] разд) {
            if (стр == "")
                throw new Exception("Введена пустая строка");
            string[] итог = стр.Split(разд, StringSplitOptions.RemoveEmptyEntries);
            if (итог.Length < 2) throw new Exception("В строке меньше двух целых чисел");
            else return итог;
        }
        static void ВывестиЧисла<T>(IEnumerable<T> стры) {
            foreach (T ст in стры) Console.WriteLine(ст);
        }
        static void ПроверитьСимволы(string стр) {
            for (int и = 0; и < стр.Length; и++)
            {
                if (!Char.IsDigit(стр[и]) && !Char.IsWhiteSpace(стр[и]) && стр[и] != '-')
                    throw new Exception(string.Format("Символ {0} с индексом [{1}] запрещён", стр[и], и));
                if (и != 0 && стр[и] == '-' && !Char.IsWhiteSpace(стр[и - 1]))
                    throw new Exception(string.Format("Символу {0} с индексом [{1}] должен предшествовать пробел", стр[и], и));
            }
        }
        static void ПроверитьЧисла(string[] числа, out List<int> целыеЧисла) {
            целыеЧисла = new List<int>();
            foreach (string чс in числа)
            {
                if (Int32.TryParse(чс, out int и))
                    целыеЧисла.Add(и);
                else throw new Exception(string.Format("Элемент {0} не является целым числом типа Integer", и));
            }
        }
        static void Диапазон(IEnumerable<Int32> числа)
        {
            int большое, маленькое;

            большое = Int32.MinValue;
            маленькое = Int32.MaxValue;
            foreach (int ч in числа)
            {
                if (ч < маленькое) маленькое = ч;
                if (ч > большое) большое = ч;
            }
            Console.WriteLine("Самое маленькое число: {0}. Самое большое число: {1}. Разница между числами: {2}", маленькое, большое, Math.Abs(маленькое - большое));
        }
        static void ДваСамыхМаленьких(IEnumerable<Int32> числа) {
            int первое, второе;
            первое = второе = Int32.MaxValue;
            foreach (int ч in числа) {
                if (ч < первое)
                {
                    второе = первое;
                    первое = ч;
                }
                else if (ч < второе && ч != первое)
                    второе = ч;
            }
            Console.WriteLine("Самое маленькое число: {0}. Второе самое маленькое число: {1}", первое, второе);
        }
        static void Main()
        {
            Console.WriteLine("Введите строку с целыми числами");
            string стр = Console.ReadLine();

            string[] числа = РазделитьСтроку(стр, new[] { " " });
            
            ПроверитьСимволы(стр);
            ПроверитьЧисла(числа, out List<int> целыеЧисла);
            ВывестиЧисла(целыеЧисла);
            Диапазон(целыеЧисла);
            ДваСамыхМаленьких(целыеЧисла);

            Console.ReadKey();
        }
    }
}
using System;

namespace Singleton
{
    public class ChocolateBoiler
    {
        private bool empty; // Заполнен ли нагреватель
        private bool boiled; // Вскипячён ли шоколад
        private static ChocolateBoiler uniqueInstance; // Хранение единственного экземпляра
        private static object sync = new object(); // Объект для синхронизации потоков

        private ChocolateBoiler()
        {
            empty = true;
            boiled = false;
        }

        // Создание и возвращение экземпляра
        public static ChocolateBoiler getInstance()
        {
            if (uniqueInstance == null)
            {
                lock (sync)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new ChocolateBoiler();
                    }
                }
            }
            
            return uniqueInstance;
        }
        
        // Заполение нагревателя шоколадной смесью
        public void Fill()
        {
            lock (sync)
            {
                if (isEmpty()) // Нагреватель пуст
                {
                    empty = false;
                    boiled = false;
                    Console.WriteLine("1. Заполнение нагревателя шоколадной смесью");
                }
            }
        }
        
        // Кипячение шоколадной смеси
        public void Boil()
        {
            lock (sync)
            {
                if (!isEmpty() && !isBoiled()) // Нагреватель не пуст, шоколад не вскипячён
                {
                    boiled = true;
                    Console.WriteLine("2. Кипячение шоколадной смеси");
                }
            }
        }
        
        // Слив содержимого нагревателя
        public void Drain()
        {
            lock (sync)
            {
                if (!isEmpty() && isBoiled()) // Нагреватель не пуст, шоколад вскипячён
                {
                    Console.WriteLine("3. Слив содержимого нагревателя\n");
                    empty = true;
                    boiled = false;
                }
            }
        }
        
        // Заполнен ли нагреватель
        private bool isEmpty()
        {
            return empty;
        }
        
        // Вскипячён ли шоколад
        private bool isBoiled()
        {
            return boiled;
        }
    }
}

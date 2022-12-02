using System;
using System.Linq;


namespace CsStudy
{
    enum FillMethod : byte
    {
        Rnd,
        Hardcode
    }
    class Lenght
    {
        public static readonly int lenght = 5;
    }

    class Menu
    {
        private static readonly int menuItemsAmount = 4;
        private static bool isExit = false;
        public static void ShowMenu(int[] arr)
        {
            while (!isExit)
            {
                Console.Clear();

                ArrayStuff.Print(arr);
                Console.WriteLine($"\nУ нас есть массив размером в {arr.Length} элементов.\n\nЧто мы хотим с ним сделать? ");
                Console.WriteLine("1. Изменить размер.");
                Console.WriteLine("2. Добавить значение.");
                Console.WriteLine("3. Заново заполнить массив.");
                Console.WriteLine("4. Выход.");


                switch (GetInput(1, menuItemsAmount))
                {
                    case 1:
                        {
                            ArrayStuff.Resize(ref arr, GetResizeRequirements());
                            break;
                        }

                    case 2:
                        {
                        
                            int[] tempArr = GetAddValueRequirements(arr).ToArray();
                            ArrayStuff.AddValue(ref arr, tempArr[0], tempArr[1]);
                            break;
                        }

                    case 3:
                        {

                            ArrayStuff.Fill(arr, GetFillRequirements());
                            break;
                        }
                    case 4:
                        {
                            isExit = true;
                            break;
                        }

                }
            }

        }

        private static int GetResizeRequirements()
        {
            Console.Clear();
            Console.WriteLine("Введите новый размер массива: ");
            return GetInput(1, 50);
        }

        private static int[] GetAddValueRequirements(int[] arr)
        {
            Console.Clear();
            Console.WriteLine("Введите индекс для новго элемента: ");

            int[] tempArr = new int[2];
            tempArr.SetValue(GetInput(0, arr.Length), 0);

            Console.Clear();
            Console.WriteLine("Введите значение нового элемента: ");

            tempArr.SetValue(GetInput(0, 99), 1);

            return tempArr;
        }

        private static FillMethod GetFillRequirements()
        {
            Console.Clear();
            Console.WriteLine("Выберите метод заполнения:\n\n1 - Рандомный\n2 - Хардкодный");
            if(GetInput(1, 2) == 1)
            {
                return FillMethod.Rnd;
            }
            else
            {
                return FillMethod.Hardcode;
            }
        }

        private static int GetInput(int rangeMin, int rangeMax)
        {
            try
            {
                int input = int.Parse(Console.ReadLine());
                if (input < rangeMin || input > rangeMax)
                {
                    throw new Exception();
                }
                return input;
            }
            catch
            {
                Console.WriteLine("Неверное значение!");
                return GetInput(rangeMin, rangeMax);
            }
        }
    }

    class ArrayStuff
    {
        public static void Resize(ref int[] arr, int newSize)
        {
            if (newSize < 1 || newSize == arr.Length)
            {
                ExeptionProcessor("Resize", "newSize", newSize.ToString());
                return;
            }
            int[] tempArr = new int[newSize];
            Array.Copy(arr, tempArr, arr.Length > newSize ? newSize : arr.Length);
            arr = tempArr;
        }
        
        public static void AddValue(ref int[] arr, int index, int newVal)
        {
            if (newVal < 0)
            {
                ExeptionProcessor("AddValue", "newVal", newVal.ToString());
                return;
            }
            if (index >= 0 && index <= arr.Length)
            {
                Resize(ref arr, arr.Length + 1);

                for (int i = 1; i != arr.Length-index; ++i)
                {
                    arr.SetValue(arr.GetValue(arr.Length - (i + 1)), arr.Length - i);
                }
                arr.SetValue(newVal, index);
            }
            else
            {
                ExeptionProcessor("AddValue", "index", index.ToString());
                return;
            }
        }

        public static void Fill(int[] arr, FillMethod fillMethod)
        {
            if(fillMethod == FillMethod.Rnd)
            {
                RndFill(arr);
            }
            else if(fillMethod == FillMethod.Hardcode)
            {
                HardcodeFill(arr);
            }
            else
            {
                ExeptionProcessor("Fill", "fillMethod", fillMethod.ToString());
                return;
            }
        }

        private static void RndFill(int[] arr)
        {
            Random random = new Random();
            for(int i = 0; i < arr.Length; ++i)
            {
                arr.SetValue(random.Next(100), i);
            }
        } 

        private static void HardcodeFill(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                arr.SetValue(99, i);
            }
        }

        public static void Print(int[] arr)
        {
            foreach(var i in arr)
            {
                Console.Write($"{i}\t");
            }
            Console.WriteLine();
        }


        //Обработчик исключений ниже
        private static void ExeptionProcessor(string caller, string paramname, string param)
        {
            Console.WriteLine($"Метод {caller} получил некорректный параметр: {paramname} = {param}");
        }
    }

    class Program
    {
        static void Main()
        {
            int[] arr = new int[Lenght.lenght];
            ArrayStuff.Fill(arr, FillMethod.Rnd);

            Menu.ShowMenu(arr);
        }
    }
}

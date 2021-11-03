using System;

namespace Module1_HomeWork_04
{
    public class Program
    {
        private static int[] sourceIntArray;
        private static int[] intArray1;
        private static int[] intArray2;
        private static char[] charArray1;
        private static char[] charArray2;

        public static void Main(string[] args)
        {
            int n;
            bool flag = false;
            do
            {
                Console.WriteLine("Укажите размер массива: ");
                string userAnswerString = Console.ReadLine();
                flag = int.TryParse(userAnswerString, out n);
                if (flag && (n < 1 || n > 100))
                {
                    flag = false;
                }

                if (!flag)
                {
                    Console.WriteLine("Только циыры (От 1 до 100)");
                }
            }
            while (!flag);
            GenerateArray(ref sourceIntArray, n, 1, 26);
            Console.WriteLine("Исходный массив: ");
            PrintArray(sourceIntArray);

            ByParityTwoArray(sourceIntArray, ref intArray1, ref intArray2);
            Console.WriteLine("Массив 1: ");
            PrintArray(intArray1);
            Console.WriteLine("Массив 2: ");
            PrintArray(intArray2);

            Console.WriteLine("Преобразование массива цифр 1 в строку: ");
            ModifyArrayToChar(intArray1, ref charArray1);
            PrintArray(charArray1);
            Console.WriteLine("Преобразование массива цифр 2 в строку: ");
            ModifyArrayToChar(intArray2, ref charArray2);
            PrintArray(charArray2);

            switch (CompareCharArrays(charArray1, charArray2))
            {
                case 0:
                    Console.WriteLine("Одинаковое количество букв в верхнем регистре");
                    break;
                case 1:
                    Console.WriteLine("В первой строке больше больше букв в верхнем регистре");
                    break;
                case 2:
                    Console.WriteLine("В второй строке больше больше букв в верхнем регистре");
                    break;
                default:
                    break;
            }
        }

        public static void GenerateArray(ref int[] arr, int newSizeArray, int minValue, int maxValue)
        {
            Random rand = new Random();
            arr = new int[newSizeArray];
            for (int i = 0; i < newSizeArray; i++)
            {
                arr.SetValue(rand.Next(minValue, maxValue), i);
            }
        }

        public static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        public static void PrintArray(char[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        public static void ByParityTwoArray(int[] arraySource, ref int[] arrayDest1, ref int[] arrayDest2)
        {
            int size1 = 0;
            int size2 = 0;
            foreach (var item in arraySource)
            {
                if (item % 2 == 0)
                {
                    size1++;
                }
                else
                {
                    size2++;
                }
            }

            if (size1 > 0)
            {
                arrayDest1 = new int[size1];
            }

            if (size2 > 0)
            {
                arrayDest2 = new int[size2];
            }

            for (int i = 0, i1 = 0, i2 = 0; i < arraySource.Length; i++)
            {
                if (arraySource[i] % 2 == 0 && i1 < size1)
                {
                    arrayDest1.SetValue(arraySource[i], i1);
                    i1++;
                }
                else if (i2 < size2)
                {
                    arrayDest2.SetValue(arraySource[i], i2);
                    i2++;
                }
            }
        }

        public static void ModifyArrayToChar(int[] arrayInt, ref char[] arrayChar)
        {
            arrayChar = new char[arrayInt.Length];
            for (int i = 0; i < arrayInt.Length; i++)
            {
                char ch = 'a';
                for (int j = 0; j < arrayInt[i]; j++)
                {
                    ch++;
                }

                switch (ch)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'd':
                    case 'h':
                    case 'j':
                        ch = char.ToUpper(ch);
                        break;
                    default:
                        break;
                }

                arrayChar.SetValue(ch, i);
            }
        }

        public static int CompareCharArrays(char[] arrayChar1, char[] arrayChar2)
        {
            int countUpperChar1 = 0;
            int countUpperChar2 = 0;
            foreach (char item in arrayChar1)
            {
                if (char.IsUpper(item))
                {
                    countUpperChar1++;
                }
            }

            foreach (char item in arrayChar2)
            {
                if (char.IsUpper(item))
                {
                    countUpperChar2++;
                }
            }

            if (countUpperChar1 > countUpperChar2)
            {
                return 1;
            }
            else if (countUpperChar1 < countUpperChar2)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}

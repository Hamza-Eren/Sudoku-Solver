using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuCozum
{
    public static class Global
    {
        public static int[,] sudoku = new int[9, 9];
    }

    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.Write($"{i + 1}. satırı girin: ");
                for (int j = 0; j < 9; j++)
                {
                    int sayi = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
                    Global.sudoku[i, j] = sayi;
                }
                Console.WriteLine();
            }

            Cozum();
        }

        public static bool Tespit(int satir, int sutun, int sayi)
        {
            for (int i = 0; i < 9; i++)
            {
                if (Global.sudoku[satir, i] == sayi)
                {
                    return false;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (Global.sudoku[i, sutun] == sayi)
                {
                    return false;
                }
            }

            int x0 = (sutun / 3);
            x0 *= 3;
            int y0 = (satir / 3);
            y0 *= 3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Global.sudoku[y0 + i, x0 + j] == sayi)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void Cozum()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Global.sudoku[i, j] == 0)
                    {
                        for (int k = 1; k < 10; k++)
                        {
                            if (Tespit(i, j, k))
                            {
                                Global.sudoku[i, j] = k;
                                Cozum();
                                Global.sudoku[i, j] = 0;
                            }
                        }
                        return;
                    }
                }
            }

            for (int i = 0; i < 9; i++)
            {
                Console.Write("[");
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(Global.sudoku[i, j]);
                }
                Console.WriteLine("]");
            }
        }
    }
}
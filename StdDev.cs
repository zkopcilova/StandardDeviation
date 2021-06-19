/*--
 * Výpočet výběrové směrodatné odchylky
 * 
 * Autor: Zuzana Kopčilová
 * Datum: Duben 2021
 * 
 * Samostatný program pro výpočet směrodatné odchylky z posloupnosti čísel,
 * zadané pomocí standartního vstupu.
 * Využívá funkce matematické knihovny Kozmath.
 * --
 */

/**
 * @file Program.cs
 * 
 * @brief Výpočet výběrové směrodatné odchylky
 * @author Zuzana Kopčilová
 */



using System;
using System.Collections;
using static System.Linq.Enumerable;
using KozmathLibrary;
using M = KozmathLibrary.Kozmath;

namespace StdDev
{
    class Program
    {
		
		static void Main(string[] args)
        {
            char[] Delimiters = {' ','\r','\n','\t'};
			string Buffer;
			double Sum = 0;
			double SumSquare = 0;
			double NumberOfNumbers = 0;

			while((Buffer=Console.ReadLine()) != null)
            {
				if (Buffer == "")
					break;

				double[] Nums = Buffer.Split(new Char [] {' ' , '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(Double.Parse).ToArray(); 
				var NumCount = Nums.Count();


				for (int i=0; i<NumCount; i++)
                {
					Sum = M.Add(Sum,Nums[i]);
					SumSquare = M.Add(SumSquare, M.Power(Nums[i],2));
					NumberOfNumbers = M.Add(NumberOfNumbers, 1);
                }
				
            }


			double Mean = M.Divide(Sum, NumberOfNumbers);

			double TmpResult = M.Multiply(M.Divide(1, M.Subtract(NumberOfNumbers, 1)), M.Subtract(SumSquare, M.Multiply(NumberOfNumbers, M.Multiply(Mean,Mean))));

			double StdDeviation = M.NthRoot(TmpResult, 2);

			Console.Write(StdDeviation+"\n");

        }
    }
}

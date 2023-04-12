using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Emberek_LINQ
{
	internal class Program
	{
		static List<Ember> Emberek;

		static void FileBeolvas(string file)
		{			
			string[] sorok = File.ReadAllLines(file);
			foreach (string sor in sorok)
			{
				string[] adatok = sor.Split(';');
				Ember ember = new Ember();

				ember.Vezeteknev = adatok[0];
				ember.Keresztnev = adatok[1];
				ember.Eletkor = int.Parse(adatok[2]);
				ember.Iranyitoszam = adatok[3];
				ember.Varos = adatok[4];
				ember.Fizetes = int.Parse(adatok[5]);

				Emberek.Add(ember);
			}
		}

		static void Main(string[] args)
		{
			Emberek = new List<Ember>();
			FileBeolvas("Emberek.csv");

            Console.WriteLine("A rendszerben lévő emberek:");
            foreach (Ember ember in Emberek)
			{
				Console.WriteLine(ember);
			}

			Console.ReadLine();
			Console.Clear();
			Console.WriteLine("Budapesti emberek:");

			//Első módszer: (hagyományos)
			//List<Ember> Budapestiek = new List<Ember>();
			//foreach (Ember ember in Emberek)
			//{
			//	if(ember.Varos == "Budapest")
			//	{
			//		Budapestiek.Add(ember);
			//	}
			//}

			//2. verzió
			//List<Ember> Budapestiek = (from ember in Emberek where ember.Varos.Contains("Budapest") select ember).ToList();

			//3. verzió (LINQ)
			List<Ember>  Budapestiek = Emberek.Where(ember => ember.Varos == "Budapest").ToList();

			foreach (Ember ember in Budapestiek )
			{
				Console.WriteLine(ember);
			}

			Console.ReadLine();
			Console.Clear();
            Console.WriteLine("A 65 év feletti lakosok:");
			
			// 1-verzió LINQ:
			//List<Ember> FoVeszelyeztetettek = (from ember in Emberek
			//								   where ember.Eletkor > 65 &&
			//										 ember.Varos.Contains("Budapest")
			//								   select ember).ToList();

			//Lambda lekérdezés verzió
			//List<Ember> FoVeszelyeztetettek = Emberek.Where(e => e.Varos == "Budapest" && 
			//													 e.Eletkor > 65).ToList();

			//ugyan az szebben:
			List<Ember> FoVeszelyeztetettek = Emberek.Where(e => e.Varos == "Budapest")
													 .Where(e => e.Eletkor > 65)
													 .ToList();			

			//kiíratás lambda:
			FoVeszelyeztetettek.ForEach(ember => Console.WriteLine(ember)); 

			Console.ReadLine();
			Console.Clear();
            //átlagfizetés.
			Console.WriteLine("Az emberek átlagfizetése: {0:0.000} Ft", Emberek.Average(e => e.Fizetes));

			Console.ReadLine();
			Console.Clear();
			Console.WriteLine("A legidősebb kőbányai lakos:");
			int maxEletkor = Emberek.Where(e => e.Varos == "Budapest")
				   .Where(e => e.Iranyitoszam.Substring(1, 2) == "08")
				   .Max(e => e.Eletkor);

			Emberek.Where(e => e.Varos == "Budapest")
				.Where(e => e.Iranyitoszam.Substring(1, 2) == "08")
				.Where (e => e.Eletkor == maxEletkor)
				.ToList()
				.ForEach(e => Console.WriteLine(e));

			Console.ReadKey();
		}
	}
}

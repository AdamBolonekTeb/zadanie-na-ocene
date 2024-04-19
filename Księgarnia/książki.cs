using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Księgarnia
{
    public class Ksiazka
    {
        static List<Ksiazka>? ksiazki = new List<Ksiazka>();
        static string path = "ksiazki.json";

        static Ksiazka() => RefreshData();

        public static void RefreshData() =>
          ksiazki = JsonSerializer.Deserialize<List<Ksiazka>>(File.ReadAllText(path));

        public static bool Exists(int id)
        {
            return ksiazki.Any(k => k.Id == id);
        }

        public static void Info(Ksiazka k)
        {
            Console.WriteLine($"{k.Id} | {k.Tytul}");
            Console.WriteLine(k.Gatunek);
            Console.WriteLine(k.Autor);
            Console.WriteLine(k.RokWydania);
        }

        public static void Add(string tytul, string autor, int rokWydania, string gatunek)
        {
            ksiazki.Add(
              new Ksiazka
              {
                  Id = ksiazki.Count + 1,
                  Tytul = tytul,
                  Autor = autor,
                  RokWydania = rokWydania,
                  Gatunek = gatunek,
              });

            File.WriteAllText(path, JsonSerializer.Serialize(ksiazki));
        }

        public static void Remove(int id)
        {
            if (!Exists(id))
            {
                Console.WriteLine("Nie ma takiej ksiazki");
                return;
            }

            ksiazki.RemoveAll((k) => k.Id == id);
            NormalizeIds();

            File.WriteAllText(path, JsonSerializer.Serialize(ksiazki));
        }

        public static void NormalizeIds() =>
          ksiazki.ForEach(k => k.Id = ksiazki.IndexOf(k) + 1);

        

        public static void ShowAll()
        {
            ksiazki.ForEach(k =>
            {
                Info(k);
                Console.WriteLine("--------------------");
            });
        }

        public int Id { get; set; }
        public string? Tytul { get; set; }
        public string? Autor { get; set; }
        public int RokWydania { get; set; }
        public string? Gatunek { get; set; }

        public static void Show(int id)
        /*************************************
         * Kod sprawdza czy znajduje się taka książka w bazie
         *************************************/
        {
            if (!Exists(id))
            {
                Console.WriteLine("Nie ma takiej ksiazki");
                return;
            }
            Ksiazka k = ksiazki.Find(k => k.Id == id);

            Info(k);
        }

        
    }
}

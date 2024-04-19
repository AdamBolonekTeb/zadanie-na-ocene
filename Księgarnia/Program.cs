using Księgarnia;

void menu(string? message = "")
{
    Console.Clear();

    if (!string.IsNullOrEmpty(message)) Console.WriteLine(message);
    Console.WriteLine("1 Wszystkie Ksiazki");
    Console.WriteLine("2 Wyswietl wybrana ksiazke");
    Console.WriteLine("3 Dodaj ksiazke");
    Console.WriteLine("4 Usun ksiazke");

    int i = Convert.ToInt16(Console.ReadLine());

    switch (i)
    {
        default:
            menu();
            break;

        case 1:
            Ksiazka.ShowAll();
            Console.ReadKey();

            menu();
            break;

        case 2:
            Console.WriteLine("Podaj id ksiazki, ktora chcesz wyswietlic");
            Ksiazka.Show(Convert.ToInt16(Console.ReadLine()));
            Console.ReadKey();

            menu();
            break;

        case 3:
            Console.WriteLine("Tytul Ksiazki");
            string title = Console.ReadLine();

            Console.WriteLine("Autor ksiazki");
            string author = Console.ReadLine();

            Console.WriteLine("Rok wydania ksiazki");
            int releaseDate = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Gatunek ksiazki");
            string genre = Console.ReadLine();

            Ksiazka.Add(title, author, releaseDate, genre);

            menu("Ksiazka zostala dodana poprawnie");
            break;

        case 4:
            Console.WriteLine("Daj id ksiazki, ktora ma zostac usunieta");
            Ksiazka.Remove(Convert.ToInt16(Console.ReadLine()));

            menu("Ksiezke udalo sie usunac poprawnie");
            break;
    }
}
menu();

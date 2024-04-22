using System;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        Random slump = new Random();


        bool oavgjort = false;
        int slutaDra = 21;
        int maxpoäng = 10;
        int minpoäng = 1;
        int vinst = 21;
        int startpoäng = 0;
        string tänkande = "...";
        string filnamn = "vinnaren";

        Console.WriteLine("Välkommen till 21:an!");
        Console.WriteLine("_____________________________________________________________________");
        Console.WriteLine();
        for (int i = 0; i < 1; i++)
        {
            Console.WriteLine("Loading.");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Välkommen till 21:an!");
            Console.WriteLine("_____________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("Loading..");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Välkommen till 21:an!");
            Console.WriteLine("_____________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("Loading...");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }

        string settings = "0";
        string menyVal = "0";
        while (menyVal != "5")
        {
            // Skriv ut huvudmenyn
            Console.WriteLine();
            Console.WriteLine("Välj ett alternativ");
            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("1. Spela 21:an");
            Console.WriteLine("2. Visa senaste vinnaren");
            Console.WriteLine("3. Spelets regler");
            Console.WriteLine("4. Inställningar");
            Console.WriteLine("5. Avsluta programmet");
            menyVal = Console.ReadLine();
            Console.Clear();

            // Tom rad innan användarens val körs
            Console.WriteLine();

            switch (menyVal)
            {
                // Spela en omgång av 21:an
                case "1":
                    int datornsPoäng = startpoäng;
                    int spelarensPoäng = startpoäng;
                    Console.WriteLine("21:an");
                    Console.WriteLine("________________________________________");
                    Console.WriteLine();
                    Console.WriteLine("Nu kommer två kort dras per spelare");
                    datornsPoäng += slump.Next(minpoäng, (maxpoäng + 1));
                    datornsPoäng += slump.Next(minpoäng, (maxpoäng + 1));
                    spelarensPoäng += slump.Next(minpoäng, (maxpoäng + 1));
                    spelarensPoäng += slump.Next(minpoäng, (maxpoäng + 1));

                    // Låt användaren dra fler kort
                    string kortVal = "";
                    while (kortVal != "n" && spelarensPoäng <= vinst)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Din poäng: {spelarensPoäng}");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Datorns poäng: {datornsPoäng}");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Vill du ha ett till kort? (j/n)");
                        Console.WriteLine();
                        kortVal = Console.ReadLine();
                        Console.Clear();

                        switch (kortVal)
                        {
                            case "j":
                                Console.WriteLine("21:an");
                                Console.WriteLine("________________________________________");
                                Console.WriteLine();
                                int nyPoäng = slump.Next(minpoäng, (maxpoäng + 1));
                                spelarensPoäng += nyPoäng;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(" _____");
                                Console.WriteLine($"|{nyPoäng}_ _ |");
                                Console.WriteLine("|( v )|");
                                Console.WriteLine("| \\ / |");
                                Console.WriteLine("|  .  |");
                                Console.WriteLine($"|____{nyPoäng}|");
                                Console.WriteLine();
                                break;

                            case "n":
                                break;

                            default:
                                Console.WriteLine("21:an");
                                Console.WriteLine("________________________________________");
                                Console.WriteLine();
                                Console.WriteLine("Du valde inte ett giltigt alternativ");
                                break;
                        }

                    }

                    // Gå tillbaka till huvudmenyn om användaren har över 21
                    if (spelarensPoäng > vinst)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("21:an");
                        Console.WriteLine("________________________________________");
                        Console.WriteLine();
                        Console.WriteLine($"Din poäng: {spelarensPoäng}");
                        Console.WriteLine("Du har mer än 21 och har förlorat");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();
                        break;
                    }

                    Console.WriteLine("21:an");
                    Console.WriteLine("________________________________________");
                    Console.WriteLine();

                    // Datorn drar kort tills den vinner eller går över 21
                    while (datornsPoäng < spelarensPoäng && datornsPoäng <= slutaDra)
                    {
                        for (int i = 0; i < tänkande.Length; i++)
                        {
                            System.Threading.Thread.Sleep(200);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(tänkande[i]);
                        }
                        int datornsNyaPoäng = slump.Next(minpoäng, (maxpoäng + 1));

                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine(" _____");
                        Console.WriteLine($"|{datornsNyaPoäng}_ _ |");
                        Console.WriteLine("|( v )|");
                        Console.WriteLine("| \\ / |");
                        Console.WriteLine("|  .  |");
                        Console.WriteLine($"|____{datornsNyaPoäng}|");
                        Console.WriteLine();

                        datornsPoäng += datornsNyaPoäng;

                    }


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Din poäng: {spelarensPoäng}");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Datorns poäng: {datornsPoäng}");


                    // Undersök vem som vann
                    if (datornsPoäng == spelarensPoäng && oavgjort == true)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("________________________________________");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Du och dator har lika mycket poäng");
                        Console.WriteLine("Det blir oavgjort");
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();
                    }

                    else if (datornsPoäng < spelarensPoäng)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("________________________________________");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Du har vunnit!");
                        Console.WriteLine("Du har mer poäng än datorn");
                        Console.WriteLine("Skriv in ditt namn");
                        Console.ForegroundColor = ConsoleColor.White;
                        string senasteVinnaren = Console.ReadLine();
                        File.WriteAllText(filnamn, senasteVinnaren);
                        Console.Clear();
                    }

                    else if (datornsPoäng > vinst)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("________________________________________");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Du har vunnit!");
                        Console.WriteLine("Datorn har mer än 21 poäng");
                        Console.WriteLine("Skriv in ditt namn");
                        Console.ForegroundColor = ConsoleColor.White;
                        string senasteVinnaren = Console.ReadLine();
                        File.WriteAllText(filnamn, senasteVinnaren);
                        Console.Clear();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("________________________________________");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Datorn har vunnit!");
                        Console.WriteLine("Datorn har fått mer poäng än dig");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();
                    }

                    break;

                // Visa senaste vinnaren
                case "2":
                    if (File.Exists(filnamn))
                    {
                        string filinnehål = File.ReadAllText(filnamn);
                        Console.WriteLine("Winner List");
                        Console.WriteLine("________________________________________");
                        Console.WriteLine();
                        Console.WriteLine($"Senaste vinnaren: {filinnehål}");
                    }
                    else Console.WriteLine("Ingen har vunnit än");

                    break;

                // Visa spelets regler
                case "3":
                    Console.WriteLine("Regler");
                    Console.WriteLine("________________________________________");
                    Console.WriteLine();
                    Console.WriteLine("Ditt mål är att tvinga datorn att få mer än 21 poäng.");
                    Console.WriteLine("Du får poäng genom att dra kort, varje kort har 1-10 poäng.");
                    Console.WriteLine("Om du får mer än 21 poäng har du förlorat.");
                    Console.WriteLine("Både du och datorn får två kort i början. Därefter får du");
                    Console.WriteLine("dra fler kort tills du är nöjd eller får över 21.");
                    Console.WriteLine("När du är färdig drar datorn kort till den har");
                    Console.WriteLine("mer poäng än dig eller över 21 poäng.");
                    break;

                case "4":
                    while (settings != "5")
                    {
                        Console.WriteLine("Inställningar");
                        Console.WriteLine("________________________________________");
                        Console.WriteLine();
                        Console.WriteLine("1. Ändra svårighetsgrad");
                        Console.WriteLine("2. Ändra maxpoäng");
                        Console.WriteLine("3. Det kan bli oavgjort");
                        Console.WriteLine("4. Återställ");
                        Console.WriteLine("5. Tillbaka");
                        settings = Console.ReadLine();
                        Console.WriteLine();
                        switch (settings)
                        {
                            case "1":
                                Console.WriteLine("Skriv in vid vilken poängtal ska datorn sluta dra, 1-21");
                                slutaDra = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Datorn slutar da nu vid {slutaDra}");
                                Console.WriteLine();
                                break;
                            case "2":
                                Console.WriteLine("Skriv in max poäng per kort");
                                maxpoäng = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Max poäng per kort är nu {maxpoäng}");
                                Console.WriteLine();
                                break;
                            case "3":
                                oavgjort = true;
                                Console.WriteLine("Det kan bli oavgjort nu");
                                Console.WriteLine();
                                break;
                            case "4":
                                slutaDra = 21;
                                maxpoäng = 11;
                                oavgjort = false;
                                Console.WriteLine("Allt är återställt nu");
                                Console.WriteLine();
                                break;
                            case "5":
                                break;
                            default:
                                Console.WriteLine("Du valde inte ett giltigt alternativ");
                                Console.WriteLine();
                                break;
                        }
                    }
                    Console.Clear();
                    break;
                // Gör ingenting (programmet avslutas)
                case "5":
                    break;

                default:
                    Console.WriteLine("Du valde inte ett giltigt alternativ");
                    break;
            }

            // Tom rad innan nästa körning
            Console.WriteLine();
        }
    }
}
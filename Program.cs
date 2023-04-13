namespace CSEindopdracht__Command_line_Spotify_
{

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Playlist> playlists = new List<Playlist>();

            while (true)
            {
                Console.WriteLine("Wat wil je doen?");
                Console.WriteLine("1. Bekijk afspeellijsten");
                Console.WriteLine("2. Maak nieuwe afspeellijst");
                Console.WriteLine("3. Bewerk bestaande afspeellijst");
                Console.WriteLine("4. Verwijder afspeellijst");
                Console.WriteLine("5. Bekijk alle nummers");
                Console.WriteLine("6. Stop");

                int keuze = Convert.ToInt16(Console.ReadLine());
                Console.Clear();

                switch (keuze)
                {
                    case 1:
                        ToonAfspeellijsten(playlists);
                        break;
                    case 2:
                        MaakNieuweAfspeellijst(playlists);
                        Console.Clear();
                        break;
                    case 3:
                        BewerkAfspeellijst(playlists);
                        Console.Clear();
                        break;
                    case 4:
                        VerwijderAfspeellijst(playlists);
                        Console.Clear();
                        break;
                    case 5:
                        ToonBeschikbareNummers();
                        Console.WriteLine(" ");
                        break;
                    case 6:
                        Console.WriteLine("Doei, neef!");
                        return;
                    default:
                        Console.WriteLine("Nee mag niet man.");
                        break;
                }
            }
        }

        static void ToonAfspeellijsten(List<Playlist> playlists)
        {
            if (playlists.Count == 0)
            {
                Console.WriteLine("Er zijn geen afspeellijsten.");
            }
            else
            {
                Console.WriteLine("Afspeellijsten:");
                foreach (Playlist playlist in playlists)
                {
                    Console.WriteLine($"- {playlist.Name} ({playlist.Songs.Count} nummer(s))");
                }
            }
        }

        static void MaakNieuweAfspeellijst(List<Playlist> playlists)
        {
            Console.WriteLine("Voer de naam van de nieuwe afspeellijst in:");
            string playlistName = Console.ReadLine();

            Playlist playlist = new Playlist
            {
                Name = playlistName,
                Songs = new List<string>()
            };

            Console.WriteLine($"De afspeellijst {playlistName} is aangemaakt.");

            while (true)
            {
                Console.WriteLine("Wil je een nummer toevoegen? (ja/nee)");
                string antwoord = Console.ReadLine();

                if (antwoord.ToLower() != "ja")
                {
                    playlists.Add(playlist);
                    Console.WriteLine($"De afspeellijst {playlistName} is opgeslagen.");
                    return;
                }

                ToonBeschikbareNummers();

                Console.WriteLine("Voer het nummer in dat je aan de afspeellijst wilt toevoegen:");
                string nummer = Console.ReadLine();

                if (nummer != null && nummer.Length > 0)
                {
                    playlist.Songs.Add(nummer);
                }
            }
        }
        static void BewerkAfspeellijst(List<Playlist> playlists)
        {
            Console.WriteLine("Voer de naam in van de afspeellijst die je wilt bewerken:");
            string playlistName = Console.ReadLine();

            Playlist playlist = playlists.FirstOrDefault(p => p.Name == playlistName);

            if (playlist == null)
            {
                Console.WriteLine($"Er is geen afspeellijst met de naam {playlistName}.");
            }
            else
            {
                Console.WriteLine($"Afspeellijst {playlistName}:");
                for (int i = 0; i < playlist.Songs.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {playlist.Songs[i]}");
                }

                while (true)
                {
                    Console.WriteLine("Voer het nummer in van het liedje dat je wilt verwijderen, of typ 'stop' om te stoppen:");
                    string antwoord = Console.ReadLine();

                    if (antwoord.ToLower() == "stop")
                    {
                        Console.WriteLine("Bewerken van afspeellijst gestopt.");
                        return;
                    }

                    int nummer;
                    if (int.TryParse(antwoord, out nummer) && nummer > 0 && nummer <= playlist.Songs.Count)
                    {
                        playlist.Songs.RemoveAt(nummer - 1);
                        Console.WriteLine($"Nummer {nummer} is verwijderd.");
                    }
                    else
                    {
                        Console.WriteLine("Ongeldige invoer. Probeer opnieuw.");
                    }
                }
            }
        }

        static void VerwijderAfspeellijst(List<Playlist> playlists)
        {
            Console.WriteLine("Voer de naam in van de afspeellijst die je wilt verwijderen:");
            string playlistName = Console.ReadLine();

            Playlist playlist = playlists.FirstOrDefault(p => p.Name == playlistName);

            if (playlist == null)
            {
                Console.WriteLine($"Er is geen afspeellijst met de naam {playlistName}.");
            }
            else
            {
                playlists.Remove(playlist);
                Console.WriteLine($"De afspeellijst {playlistName} is verwijderd.");
            }
        }

        static void ToonBeschikbareNummers()
        {
            Console.WriteLine("Beschikbare nummers:");
            Console.WriteLine("1. Bohemian Rhapsody - Queen");
            Console.WriteLine("2. Stairway to Heaven - Led Zeppelin");
            Console.WriteLine("3. Hotel California - Eagles");
            Console.WriteLine("4. Smells Like Teen Spirit - Nirvana");
            Console.WriteLine("5. Sweet Child O' Mine - Guns N' Roses");
            Console.WriteLine("6. Imagine - John Lennon");
            Console.WriteLine("7. Like a Rolling Stone - Bob Dylan");
            Console.WriteLine("8. Hey Jude - The Beatles");
            Console.WriteLine("9. Purple Haze - Jimi Hendrix");
            Console.WriteLine("10. Billie Jean - Michael Jackson");
        }
    }

    class Playlist
    {
        public string Name { get; set; }
        public List<string> Songs { get; set; }
    }
}

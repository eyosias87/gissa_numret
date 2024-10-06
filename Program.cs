using System;

namespace NumbersGame
{
        class Program
        {
            static void Main(string[] args)
            {
                bool spelaIgen = true;

                while (spelaIgen)
                {
                    StartGame();

                    Console.WriteLine("\nVill du spela igen? (ja/nej)");
                    string spelaIgenSvar = Console.ReadLine()?.ToLower();
                    spelaIgen = spelaIgenSvar == "ja";
                }
            }

            // Startar spelet
            static void StartGame()
            {
                Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");

                // Välj svårighetsgrad
                int maxNummer = VäljSvårighetsgrad();
                Random random = new Random();
                int nummer = random.Next(1, maxNummer + 1);

                // Gissningsprocessen
                for (int försök = 1; försök <= 5; försök++)
                {
                    Console.WriteLine($"Försök {försök}: ");
                    int gissning = int.Parse(Console.ReadLine());

                    if (CheckGuess(nummer, gissning))
                    {
                        Console.WriteLine("Wohoo! Du klarade det!");
                        return;
                    }

                    if (försök == 5)
                    {
                        Console.WriteLine($"Tyvärr, du lyckades inte gissa talet på fem försök! Rätt svar var {nummer}.");
                    }
                }
            }

            // Väljer svårighetsgrad och återlämnar maxvärdet för talet
            static int VäljSvårighetsgrad()
            {
                Console.WriteLine("\nVälj svårighetsgrad:\n1. Enkel (10 tal, 6 försök)\n2. Medel (25 tal, 5 försök)\n3. Svår (50 tal, 3 försök)");
                int svårighetsgrad = int.Parse(Console.ReadLine());
                switch (svårighetsgrad)
                {
                    case 1: return 10;  // Enkel nivå
                    case 2: return 25;  // Medel nivå
                    case 3: return 50;  // Svår nivå
                    default: return 20; // Standard 20
                }
            }

            // Kollar om gissningen är rätt eller fel och ger feedback
            static bool CheckGuess(int nummer, int gissning)
            {
                if (gissning == nummer)
                {
                    return true; // Rätt gissning
                }
                else if (gissning < nummer)
                {
                    Console.WriteLine(VäljMeddelande(false, nummer - gissning));
                }
                else
                {
                    Console.WriteLine(VäljMeddelande(true, gissning - nummer));
                }

                return false; // Fel gissning
            }

            // Ger varierande meddelanden beroende på om gissningen är för hög eller låg
            static string VäljMeddelande(bool förHögt, int skillnad)
            {
                string[] högtMeddelanden = new string[]
                {
                "Tyvärr, du gissade för högt!",
                "Haha! Det var för högt!",
                "Bra försök, men det var för högt.",
                "Oj, du är lite för hög!"
                };

                string[] lågtMeddelanden = new string[]
                {
                "Tyvärr, du gissade för lågt!",
                "Hmm, det var lite lågt.",
                "Nästan, men du är lite för låg.",
                "Det där var för lågt!"
                };

                string näraSvar = skillnad <= 2 ? "Det var nära!" : "";
                string långtBortSvar = skillnad > 10 ? "Oj, det var långt ifrån!" : "";

                Random random = new Random();
                if (förHögt)
                {
                    return högtMeddelanden[random.Next(högtMeddelanden.Length)] + " " + näraSvar + " " + långtBortSvar;
                }
                else
                {
                    return lågtMeddelanden[random.Next(lågtMeddelanden.Length)] + " " + näraSvar + " " + långtBortSvar;
                }
            }
        }
}



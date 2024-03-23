class Starter
{
    static void Main(string[] args)
    {
        Buchhaltung buchhaltung = new Buchhaltung();
        int intTask;
        bool wasTaskSuccessful = false;
        bool repeat = true;
        while (repeat)
        {
            while (true)
            {
                Console.WriteLine("Was möchten Sie tun? 1) Konto erstellen 2) Buchen 3) Alle Kontostände abrufen");

                try
                {
                    intTask = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Dies ist keine gültige Aktion, geben Sie bitte 1, 2 oder 3 ein.");
                }
            }

            switch (intTask)
            {
                case 1:
                    Console.WriteLine("Geben Sie den Namen des Kontos so wie den Kontotyp(Aktiv, Passiv, Aufwand, Ertrag) im folgenden Format ein: Kontoname, Kontotyp");
                    string[] konti = Console.ReadLine().Replace(" ", "").Split(",");
                    if (konti.Length > 1)
                    {
                        wasTaskSuccessful = buchhaltung.addKonto(konti[0], konti[1]);
                    }
                    else
                    {
                        wasTaskSuccessful = false;
                        Console.Error.WriteLine("Sie haben den Kontotyp nicht angegeben. Die Aufgabe wurde abgebrochen.");
                    }
                    break;
                case 2:
                    Console.WriteLine("Geben Sie die Buchung im folgenden Format ein: Sollkonto / Habenkonto / Betrag");
                    string[] buchung = Console.ReadLine().Replace(" ", "").Split("/");
                    if(buchung.Length != 3)
                    {
                        wasTaskSuccessful = false;
                        Console.WriteLine("Bitte überprüfe das Format der Buchung. So kann die Buchung nicht weiterverarbeitet werden.");
                    } else
                    {
                        wasTaskSuccessful = buchhaltung.buchungVerarbeiten(buchung[0], buchung[1], buchung[2]);
                    }
                    break;
                case 3:
                    Console.WriteLine("Salden der Konten");
                    Console.WriteLine("------------------");
                    int summeAktiv = 0;
                    int summePassiv = 0;
                    int summeAufwand = 0;
                    int summeErtrag = 0;
                    Console.WriteLine("Aktiven:");
                    foreach(Konti konto in buchhaltung.getAktiv())
                    {
                        Console.WriteLine(konto.getName() +  ": " + konto.getSaldo());
                        summeAktiv += konto.getSaldo();
                    }
                    Console.WriteLine("------------------");
                    Console.WriteLine("Passiven:");
                    foreach (Konti konto in buchhaltung.getPassiv())
                    {
                        Console.WriteLine(konto.getName() + ": " + konto.getSaldo());
                        summePassiv += konto.getSaldo();
                    }
                    Console.WriteLine("------------------");
                    Console.WriteLine("Aufwände:");
                    foreach (Konti konto in buchhaltung.getAufwand())
                    {
                        Console.WriteLine(konto.getName() + ": " + konto.getSaldo());
                        summeAufwand += konto.getSaldo();
                    }
                    Console.WriteLine("------------------");
                    Console.WriteLine("Erträge:");
                    foreach (Konti konto in buchhaltung.getErfolg())
                    {
                        Console.WriteLine(konto.getName() + ": " + konto.getSaldo());
                        summeErtrag += konto.getSaldo();
                    }
                    Console.WriteLine("------------------");
                    Console.WriteLine("Total Aktiv: " + summeAktiv);
                    Console.WriteLine("Total Passiv: " + summePassiv);
                    Console.WriteLine("Total Aufwand: " + summeAufwand);
                    Console.WriteLine("Total Erfolg: " + summeErtrag);
                    Console.WriteLine("------------------");
                    break;
                default:
                    Console.WriteLine("Dies ist keine gültige Aktion.");
                    break;
            }

            if(wasTaskSuccessful)
            {
                Console.WriteLine("Die Aufgabe wurde erfolgreich ausgeführt.");
            }

            Console.WriteLine("Wollen Sie nochmals eine Aufgabe ausführen? Tippen Sie 'ja'");
            repeat = Console.ReadLine().ToLower() == "ja" ? true : false;
        }

    }
}
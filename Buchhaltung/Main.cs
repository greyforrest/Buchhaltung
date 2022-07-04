class Starter
{
    static void Main(string[] args)
    {
        Buchhaltung buchhaltung = new Buchhaltung();
        int intTask;
        bool wasTaskSuccessful;
        bool repeat = true;
        while (repeat)
        {
            while (true)
            {
                Console.WriteLine("Was möchten Sie tun? 1) Konto erstellen 2) Buchen");

                try
                {
                    intTask = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Dies ist keine gültige Aktion, geben Sie bitte 1 oder 2 ein.");
                }
            }

            if (intTask == 1)
            {
                Console.WriteLine("Geben Sie den Namen des Kontos so wie den Kontotyp(Aktiv, Passiv, Aufwand, Ertrag) im folgenden Format ein: Kontoname, Kontotyp");
                string[] konti = Console.ReadLine().Replace(" ", "").Split(",");
                if (konti.Length > 1)
                {
                    wasTaskSuccessful = buchhaltung.addKonto(konti[0], konti[1]);
                } else
                {
                    wasTaskSuccessful = false;
                    Console.Error.WriteLine("Sie haben den Kontotyp nicht angegeben. Die Aufgabe wurde abgebrochen.");
                }

            }
            else if (intTask == 2)
            {
                Console.WriteLine("Geben Sie die Buchung im folgenden Format ein: Sollkonto / Habenkonto / Betrag");
                string[] buchung = Console.ReadLine().Replace(" ", "").Split("/");
                wasTaskSuccessful = buchhaltung.buchungVerarbeiten(buchung[0], buchung[1], buchung[2]);
            }
            Console.WriteLine("Wollen Sie nochmals eine Aufgabe ausführen? Tippen Sie 'ja'");
            repeat = Console.ReadLine().ToLower() == "ja" ? true : false;
        }

    }
}
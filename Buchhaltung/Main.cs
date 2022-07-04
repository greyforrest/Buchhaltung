class Starter
{
    static void Main(string[] args)
    {
        Buchhaltung buchhaltung = new Buchhaltung();
        int intTask;

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

        if(intTask == 1)
        {
            Console.WriteLine("Geben Sie den Namen des Kontos so wie den Kontotyp(Aktiv, Passiv, Aufwand, Ertrag) im folgenden Format ein: Kontoname, Kontotyp");
            string[] konti = Console.ReadLine().Replace(" ", "").Split(",");
            buchhaltung.addKonto(new Konti(konti[0], konti[1]));
        }
    }
}
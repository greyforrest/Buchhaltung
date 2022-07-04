class Buchhaltung{
    List<Konti> alleKonten = new List<Konti> ();

    public bool addKonto(string name, string typ)
    {
        Kontotyp konto;
        switch (typ.ToLower())
        {
            case "aktiv":
                konto = Kontotyp.Aktiv;
                break;
            case "passiv":
                konto = Kontotyp.Passiv;
                break;
            case "aufwand":
                konto = Kontotyp.Aufwand;
                break;
            case "erfolg":
                konto = Kontotyp.Erfolg;
                break;
            default:
                Console.Error.WriteLine("Dieser Kontotyp existiert nicht. Es gibt: Aktiv, Passiv, Ertrag und Aufwand");
                return false;
        }
        alleKonten.Add(new Konti(name, konto));
        return true;
    }

    public List<Konti> getKonti()
    {
        return alleKonten;
    }

    public bool buchungVerarbeiten(string soll, string haben, string betrag)
    {
        int intBetrag;
        Konti kSoll = null;
        Konti kHaben = null;
        try
        {
            intBetrag = Int32.Parse(betrag);
            foreach (Konti konto in alleKonten)
            {
               if(konto.getName() == soll)
                {
                    kSoll = konto;
                }
               if(konto.getName() == haben)
                {
                    kHaben = konto;
                }
            }
            if ((kSoll != null) && (kHaben != null))
            {
                kSoll.inSoll(intBetrag);
                kHaben.inHaben(intBetrag);
            } else
            {
                Console.Error.WriteLine("Nicht alle verwendeten Konten existieren. Bitte erstellen Sie die Konten zuerst bevor Sie sie verwenden.");
                return false;
            }

        }
        catch
        {
            Console.Error.WriteLine("Ungültige Buchung");
            return false;
        }
        return true;
    }
}

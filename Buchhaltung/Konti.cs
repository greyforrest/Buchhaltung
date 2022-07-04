class Konti
{
    private string name;
    private int soll;
    private int haben;
    private Kontotyp konto;

    public Konti(string name, string kontotyp)
    {
        this.name = name;
        soll = 0;
        haben = 0;

        switch (kontotyp)
        {
            case "Aktiv":
                this.konto = Kontotyp.Aktiv;
                break;
            case "Passiv":
                this.konto = Kontotyp.Passiv;
                break;
            case "Aufwand":
                this.konto = Kontotyp.Aufwand;
                break;
            case "Erfolg":
                this.konto = Kontotyp.Erfolg;
                break;
            default:
                Console.Error.WriteLine("Dieser Kontotyp existiert nicht. Es gibt: Aktiv, Passiv, Ertrag und Aufwand");
                break;
        }
    }

    public void inSoll(int soll)
    {
        this.soll += soll;
    }

    public void inHaben(int haben)
    {
        this.haben += haben;
    }

    public int getSaldo()
    {
        if((konto == Kontotyp.Aktiv)||(konto == Kontotyp.Aufwand)){
            return soll - haben;
        } else if((konto == Kontotyp.Passiv) || (konto == Kontotyp.Erfolg))
        {
            return haben - soll;
        } else
        {
            return 0;
        }
    }
}

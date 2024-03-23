class Konti
{
    private string name;
    private int soll;
    private int haben;
    private Kontotyp konto;

    public Konti(string name, Kontotyp kontotyp)
    {
        this.name = name;
        soll = 0;
        haben = 0;
        this.konto = kontotyp;
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

    public Kontotyp getKontotyp()
    {
        return konto;
    }

    public string getName()
    {
        return name;
    }
}

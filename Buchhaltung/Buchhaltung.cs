class Buchhaltung{
    List<Konti> alleKonten = new List<Konti> ();

    public void addKonto(Konti konto)
    {
        alleKonten.Add(konto);
    }

    public List<Konti> getKonti()
    {
        return alleKonten;
    }
}

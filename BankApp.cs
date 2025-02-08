using System;
using System.Collections.Generic;

public class Konto
{
    public string Kontonummer { get; set; }
    public double Kontostand { get; set; }

    
    public List<string> transaktionsHistorie = new List<string>();

    public Konto(string kontonummer, double startguthaben)
    {
        Kontonummer = kontonummer;
        Kontostand = startguthaben;
        transaktionsHistorie.Add($"Konto eröffnet. Startguthaben: {startguthaben}");
    }

    public void Einzahlen(double betrag)
    {
        if (betrag > 0)
        {
            Kontostand += betrag;
            transaktionsHistorie.Add($"Eingezahlt: +{betrag}. Neuer Kontostand: {Kontostand}");
        }
        else
        {
            Console.WriteLine("Einzahlungsbetrag muss positiv sein.");
        }
    }

    
    public void Abheben(double betrag)
    {
        if (betrag <= 0)
        {
            Console.WriteLine("Abhebungsbetrag muss positiv sein.");
            return;
        }
        if (betrag > Kontostand)
        {
            Console.WriteLine("Fehler: Nicht genügend Guthaben auf dem Konto.");
        }
        else
        {
            Kontostand -= betrag;
            transaktionsHistorie.Add($"Abgehoben: -{betrag}. Neuer Kontostand: {Kontostand}");
        }
    }

    
    public void ZeigeKontostand()
    {
        Console.WriteLine($"Kontonummer: {Kontonummer}");
        Console.WriteLine($"Aktueller Kontostand: {Kontostand}");
    }


    public void Transaktionshistorie()
    {
        Console.WriteLine("\n--- Transaktionshistorie ---");
        foreach (var eintrag in transaktionsHistorie)
        {
            Console.WriteLine(eintrag);
        }
    }
}

class Program
{
    static void Main()
    {
      
        Console.Write("Geben Sie die Kontonummer an: ");
        string knr = Console.ReadLine();
        
        Console.Write("Geben Sie das Startguthaben an: ");
        double startguthaben = Convert.ToDouble(Console.ReadLine());

        Konto konto = new Konto(knr, startguthaben);

        bool running = true;
        while (running)
        {
            Console.WriteLine("1) Einzahlen");
            Console.WriteLine("2) Abheben");
            Console.WriteLine("3) Kontostand anzeigen");
            Console.WriteLine("4) Transaktionshistorie anzeigen");
            Console.WriteLine("5) Beenden");
            Console.Write("Auswahl: ");
            string auswahl = Console.ReadLine();

            switch (auswahl)
            {
                case "1":
                    Console.Write("Bitte geben Sie den Einzahlungsbetrag ein: ");
                    double einzahlung = Convert.ToDouble(Console.ReadLine());
                    konto.Einzahlen(einzahlung);
                    break;

                case "2":
                    Console.Write("Bitte geben Sie den Abhebungsbetrag ein: ");
                    double abhebung = Convert.ToDouble(Console.ReadLine());
                    konto.Abheben(abhebung);
                    break;

                case "3":
                    konto.ZeigeKontostand();
                    break;

                case "4":
                    konto.Transaktionshistorie();
                    break;

                case "5":
                    Console.WriteLine("Programm wird beendet.");
                    running = false;
                    break;

                
            }
        }
    }
}

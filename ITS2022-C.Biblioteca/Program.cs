using System;

namespace ITS2022_C.Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gestionale per biblioteche.");

            Utente utente1 = new(Guid.NewGuid().ToString(), "Federico", "Martelloni", 2020);
            Utente utente2 = new(Guid.NewGuid().ToString(), "Luigi", "Martelloni", 2021);

            Libro libro = new()
            {
                Id = Guid.NewGuid().ToString(),
                Autore = "Primo Levi",
                Titolo = "Se questo è un uomo"
            };

            libro.VaInPrestito(utente1);
            libro.VaInPrestito(utente2);
            libro.Restituzione();
            libro.VieneVenduto(utente2);
            libro.VieneVenduto(utente2);
            libro.VieneVenduto(utente1);
            libro.VaInPrestito(utente2);
            libro.Riacquisto();
            libro.VaInPrestito(utente2);
            libro.VieneVenduto(utente2);
            libro.Riacquisto();
            libro.Restituzione();
            libro.Restituzione();
        }
    }
}
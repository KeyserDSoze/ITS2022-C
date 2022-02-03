using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.Biblioteca
{
    public class Libro
    {
        public string Id { get; init; }
        public string Titolo { get; init; }
        public string Autore { get; init; }
        public Utente Possessore { get; private set; }
        public int Stato { get; set; }
        public string Descrizione => $"{this.Titolo} di {this.Autore}";
        public void VaInPrestito(Utente utente)
            => CambiaStato(utente, 1);
        public void VieneVenduto(Utente utente)
            => CambiaStato(utente, 2);
        private void CambiaStato(Utente utente, int nuovoStato)
        {
            if (Possessore != null && utente.Id == Possessore.Id)
            {
                if (Stato == 1)
                    Console.WriteLine($"Libro {Descrizione} già noleggiato da {Possessore.Denominazione}.");
                else if (Stato == 2)
                    Console.WriteLine($"Libro {Descrizione} già venduto a {Possessore.Denominazione}.");
            }
            switch (Stato)
            {
                case 0:
                    Possessore = utente;
                    Stato = nuovoStato;
                    if (Stato == 1)
                        Console.WriteLine($"Libro {Descrizione} noleggiato da {Possessore.Denominazione}.");
                    else if (Stato == 2)
                        Console.WriteLine($"Libro {Descrizione} venduto a {Possessore.Denominazione}.");
                    break;
                case 1:
                    Console.WriteLine($"Libro {Descrizione} già noleggiato.");
                    break;
                case 2:
                    Console.WriteLine($"Libro {Descrizione} già acquistato.");
                    break;
                default:
                    throw new ArgumentException($"Stato sconosciuto per il libro {Descrizione}");
            }
        }
        public void Restituzione()
        {
            switch (Stato)
            {
                case 1:
                    Console.WriteLine($"Fine prestito libro {Descrizione} a {Possessore.Denominazione}");
                    Possessore = null;
                    Stato = 0;
                    break;
                case 2:
                    Console.WriteLine($"Non è possibile restituire un libro acquistato.");
                    break;
                case 0:
                    Console.WriteLine($"Non è possibile restituire un libro già presente.");
                    break;
            }
        }
        public void Riacquisto()
        {
            switch (Stato)
            {
                case 2:
                    Console.WriteLine($"Libro {Descrizione} ricomprato da {Possessore.Denominazione}");
                    Possessore = null;
                    Stato = 0;
                    break;
                case 1:
                    Console.WriteLine($"Non è possibile riacquistare un libro noleggiato.");
                    break;
                case 0:
                    Console.WriteLine($"Non è possibile riacquistare un libro già presente.");
                    break;
            }
        }
    }
}

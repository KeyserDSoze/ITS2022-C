using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.Biblioteca
{
    public class Utente
    {
        //Uso solo il get per rendere il mio oggetto immutabile, cioè ogni volta che creo un'istanza
        //non potrò piu cambiare il valore delle proprietà al suo interno. Potrei utilizzare anche
        //la keyword init, che permette la creazione con le stesse proprietà di read-only e immutabilità
        //anche al costruttore vuoto con graffe, per esempio new Utente() { Id = "29" };
        public string Id { get; }
        public string Nome { get; }
        public string Cognome { get; }
        public int AnnoIscrizione { get; }
        public Utente(string id, string nome, string cognome, int annoIscrizione)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            AnnoIscrizione = annoIscrizione;
        }
        public string Denominazione => $"{this.Nome} {this.Cognome}";
    }
}
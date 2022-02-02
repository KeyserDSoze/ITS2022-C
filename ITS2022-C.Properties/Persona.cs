using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS2022_C.Properties
{
    internal class OldPersona
    {
        public string Nome;
    }
    internal class Persona
    {
        private string nome;
        public void SetNome(string nome)
        {
            this.nome = nome.Replace(" ", string.Empty);
        }
        public string GetNome()
        {
            return this.nome.Substring(0, 1).ToUpper() + this.nome.Substring(1).ToLower();
        }
    }
    internal class NewPersona
    {
        private string nome;
        public string Nome
        {
            get
            {
                //more operations to do
                return this.nome.Substring(0, 1).ToUpper() + this.nome.Substring(1).ToLower();
            }
            set
            {
                //more operations to do
                this.nome = value.Replace(" ", string.Empty);
            }
        }
    }
    internal class NewPersonaWithLambda
    {
        private string nome;
        private string cognome;
        public string Nome
        {
            get => this.nome.Substring(0, 1).ToUpper() + this.nome.Substring(1).ToLower();
            set => this.nome = value.Replace(" ", string.Empty);
        }
        public string Cognome
        {
            get => this.cognome.Substring(0, 1).ToUpper() + this.cognome.Substring(1).ToLower();
            internal set => this.cognome = value.Replace(" ", string.Empty);
        }
        public string Denominazione => $"Ciao {nome} {cognome}";
    }
    internal class ClassicPersona
    {
        public string Nome { get; internal set; }
    }
    internal class InitOnlyPersona
    {
        public string Nome { get; init; } = "Mario";
        public string Cognome { get; init; }
        public string Saluto { get; } = "Ciao";
        public override bool Equals(object? obj)
        {
            var myObject = obj as InitOnlyPersona;
            return myObject.Nome == Nome && myObject.Cognome == Cognome;
        }
    }
    internal record ModelForPersona(string Nome, string Cognome)
    {
        public override string ToString()
        {
            return $"Ciao {Nome} {Cognome}";
        }
    }
}

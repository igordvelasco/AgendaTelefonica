using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoEstrutura
{
    public class Contato
    {
        public Contato() { }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public Contato(string nome, string telefone, string email)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
        }
    }
}
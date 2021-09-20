using System;

namespace Projeto1
{
    public class Cadastro : EntidadeBase
    {
        // Determinar os atributos

        private Tipo Tipo { get; set; }
        private string Descricao { get; set; }
        private string Nome { get; set; }
        private int NumeroRestaurante { get; set; }
        private string Localizacao { get; set; }
        private bool Excluido {get; set;}

        // Determinar os métodos

        public Cadastro(int id, Tipo tipo, string nome, string descricao, int numero, string local)
        {
            this.Id = id;
            this.Tipo = tipo;
            this.Nome = nome;
            this.Descricao = descricao;
            this.NumeroRestaurante = numero;
            this.Localizacao = local;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Tipo: " + this.Tipo + Environment.NewLine;
            retorno += "Descricao: " + this.Descricao + Environment.NewLine;
            retorno += "Número do Restaurante: " + this.NumeroRestaurante + Environment.NewLine;
            retorno += "Localização: " + this.Localizacao + Environment.NewLine;
            return retorno;
        }

        public string RetornaNome()
        {
            return this.Nome;
        }

        public int RetornaId()
        {
            return this.Id;
        }
        public bool RetornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir(){
            this.Excluido = true;
        }

    }
}

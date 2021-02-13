using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        public bool Excluido { get; private set; }
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero " + this.Genero + Environment.NewLine;
            retorno += "Titulo " + this.Titulo + Environment.NewLine;
            retorno += "Descricao " + this.Descricao + Environment.NewLine;
            retorno += "Ano de inicio " + this.Ano + Environment.NewLine;
            retorno += "Excluido " + this.Excluido + Environment.NewLine;
            return retorno;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }

        // Nao faz sentido um getId ja que a prop Id esta publica!!!
        // public int retornaId()
        // {
        //     return this.Id;
        // }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}
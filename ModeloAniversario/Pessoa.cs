using System;

namespace ModeloAniversario
{
    public class Pessoa
    {

        public Pessoa(string nome, string sobrenome, string nascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Nascimento = nascimento;
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Nascimento { get; set; }

        public int TotalDias {
            get {
                return CalcDias();
            }
        }

        private int CalcDias()
        {
            DateTime dataNascimento = DateTime.Parse(Nascimento);
            DateTime dataAniversario = new DateTime(DateTime.Now.Year, dataNascimento.Month, dataNascimento.Day);
            TimeSpan intervalo = dataAniversario - DateTime.Now;

            if (intervalo.Days < 0)
            {
                dataAniversario = new DateTime(DateTime.Now.Year + 1, dataNascimento.Month, dataNascimento.Day);
                intervalo = dataAniversario - DateTime.Now;
            }
            else if (intervalo.Days == 0 &&
                       intervalo.Hours <= 0 &&
                       intervalo.Minutes <= 0 &&
                       intervalo.Seconds <= 0 &&
                       intervalo.Milliseconds <= 0)
            {
                
                return 0;
            }
            var resultado = intervalo.Days + 1;
            return resultado;
        }

        public string Parabens
        {
            get
            {
                return $"Parabéns, {this.Nome} {this.Sobrenome}, " +
                  $"pelos seus {DateTime.Now.Year - DateTime.Parse(Nascimento).Year} anos. ";
            }
        }
    }
}

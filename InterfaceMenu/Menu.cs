using ModeloAniversario;
using Repository;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace InterfaceMenu
{
    public class Menu
    {

        private readonly IPessoaRepository<Pessoa> _repository;
        public List<Pessoa> BirthToday { get; }
        public Menu(IPessoaRepository<Pessoa> repository)
        {
            _repository = repository;
            BirthToday = VerificarAniversarioDoDia();
        }
        public bool AdicionarAmigo(string nome, string sobrenome, string nascimento)
        {
           return _repository.AddPessoa(nome, sobrenome, nascimento);
        }
        public List<Pessoa> BuscarAmigo(string nome)
        {
            return _repository.GetPessoasByName(nome);
        }
        public List<Pessoa> ListarAmigos()
        {
            return _repository.GetAll();
        }

        private List<Pessoa> VerificarAniversarioDoDia()
        {
            List<Pessoa> aniversariantes = new List<Pessoa>();
            foreach (var p in _repository.GetAll())
            {
                if (p.TotalDias == 0)
                {
                    aniversariantes.Add(p);
                }
            }
            return aniversariantes.Count > 0 ? aniversariantes: null;
        }

        public bool Delete(Pessoa p)
        {
            return _repository.Delete(p);
        }

        public bool AtualizarDados(string dados, Pessoa p)
        {
            string[] data = dados.Split(';', ';');
            return _repository.Atualizar(data, p);
        }
    }
}

using ModeloAniversario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IPessoaRepository<Pessoa>
    {
        Boolean AddPessoa(string nome, string sobrenome, string nascimento);
        List<Pessoa> GetPessoasByName(string nome);
        List<Pessoa> GetAll();
        Boolean Delete(Pessoa p);
        Boolean Atualizar(string[] dados, Pessoa p);
    }
}

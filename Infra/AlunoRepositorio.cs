using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_do_aluno.Infra
{
    internal class AlunoRepositorio
    {
        private readonly DbConnection _contexto = new DbConnection();


        public void Add(Aluno aluno)
        {
            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();
        }

        public List<Aluno> Get()
        {
            return _contexto.Alunos.ToList();
        }
    }
}

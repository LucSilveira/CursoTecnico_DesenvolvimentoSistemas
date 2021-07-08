using DoLink.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoLink.Dominio.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> ListarSkills();
        Task<Skill> BuscarSkill(string _nomeSkill);
        Task<Skill> BuscarSkillEspecifica(string _id);
        Task<Skill> CadastrarSkill(Skill _skill);
        Task<Skill> AlterarSkill(Skill _skill);
        Task<Skill> DeletarSkill(Skill _skill);
    }
}

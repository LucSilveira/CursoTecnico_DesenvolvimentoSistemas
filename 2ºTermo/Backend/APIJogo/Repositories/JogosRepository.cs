using APIJogo.Contexts;
using APIJogo.Domains;
using APIJogo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJogo.Repositories
{
    public class JogosRepository : IJogoRepository
    {
        private readonly JogosContext _context;

        public JogosRepository()
        {
            _context = new JogosContext();
        }

        /// <summary>
        /// Método para listar os jogos cadastrados
        /// </summary>
        /// <returns>Lista com nossos jogos</returns>
        public List<Jogo> ListarJogos()
        {
            return _context.Jogos.ToList();
        }

        /// <summary>
        /// Método para buscar os dados pertinentes de um jogo
        /// </summary>
        /// <param name="_idJogo">Código de identificação do jogo</param>
        /// <returns>Dados pertinentes ao jogo buscado</returns>
        public Jogo BuscarJogoId(Guid _idJogo)
        {
            try
            {
                return _context.Jogos.FirstOrDefault(jg => jg.Id == _idJogo);

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }

        /// <summary>
        /// Método para cadastrar um novo jogo
        /// </summary>
        /// <param name="_jogo">Dados do jogo a serem cadastrados</param>
        /// <returns>Jogo recem cadastrado</returns>
        public Jogo CadastrarJogo(Jogo _jogo)
        {
            try
            {
                _context.Jogos.Add(_jogo);

                _context.SaveChanges();

                return _jogo;

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }

        /// <summary>
        /// Método para alterar os dados de um jogo
        /// </summary>
        /// <param name="_jogo">Dados a serem alterados</param>
        /// <returns>Dado alterado</returns>
        public Jogo AlterarJogo(Jogo _jogo)
        {
            try
            {
                Jogo _jogoBuscado = BuscarJogoId(_jogo.Id);

                _jogoBuscado.Nome = _jogo.Nome;
                _jogoBuscado.Descricao = _jogo.Descricao;
                _jogoBuscado.DataLancamento = _jogo.DataLancamento;

                _context.Jogos.Update(_jogoBuscado);
                _context.SaveChanges();

                return _jogoBuscado;

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }

        public void ExcluirJogo(Guid _idJogo)
        {
            try
            {
                Jogo _jogoBuscado = BuscarJogoId(_idJogo);

                _context.Jogos.Remove(_jogoBuscado);
                _context.SaveChanges();

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }

        
    }
}

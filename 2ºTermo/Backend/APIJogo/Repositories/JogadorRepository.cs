using APIJogo.Contexts;
using APIJogo.Domains;
using APIJogo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJogo.Repositories
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly JogosContext _context;

        public JogadorRepository()
        {
            _context = new JogosContext();
        }

        public List<Jogador> ListarJogadores()
        {
            try
            {
                return _context.Jogadores.Include(jg => jg.JogosJogadores).ToList();

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }

        public Jogador BuscarJogadorId(Guid _idJogador)
        {
            try
            {

                return _context.Jogadores.Include(jgd => jgd.JogosJogadores).ThenInclude(jgd => jgd.Jogador)
                            .FirstOrDefault(jgd => jgd.Id == _idJogador);

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }

        public Jogador CadastrarJogador(Jogador _jogador)
        {
            try
            {
                Jogador jg = new Jogador
                {
                    Nome = _jogador.Nome,
                    Email = _jogador.Email,
                    Senha = _jogador.Senha
                };

                foreach (var _item in _jogador.JogosJogadores)
                {
                    jg.JogosJogadores.Add(new JogosJogadores
                    {
                        IdJogador = _jogador.Id,
                        IdJogo = _item.IdJogo
                    });
                }

                _context.Jogadores.Add(jg);
                _context.SaveChanges();

                return jg;

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }

        public void ExcluirJogador(Guid _idJogador)
        {
            try
            {
                Jogador _jogadorBuscado = BuscarJogadorId(_idJogador);

                JogosJogadores _jogosDoJogadorBuscado = _context.JogosJogador.FirstOrDefault(jgd => jgd.IdJogador == _idJogador);

                if(_jogadorBuscado == null)
                {
                    throw new Exception("Produto não encontrado");
                }

                if(_jogosDoJogadorBuscado != null)
                {
                    _context.JogosJogador.Remove(_jogosDoJogadorBuscado);
                }

                _context.Jogadores.Remove(_jogadorBuscado);

                _context.SaveChanges();

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }
    }
}

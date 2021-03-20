using CodeTur.Comum.Commands;
using CodeTur.Dominio.Commands.Usuarios;
using CodeTur.Dominio.Handlers.Usuarios;
using CodeTur.Testes.Repositories.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Handlers.Usuarios
{
    public class AdicionarTelefoneHandleTestes
    {
        [Fact]
        public void ErroCasoDadosAdicionarTelefoneHandleInvalidos()
        {
            //Criando o nosso command
            var _command = new AdicionarTelefoneCommand(Guid.Empty, "");

            //Criando o nosso handle
            var _handle = new AdicionarTelefoneHandle(new FakeUsuarioRepository());

            //Pegando os valores informados
            var _result = (GenericCommandResult)_handle.Handle(_command);

            //Validando os parametros
            Assert.False(_result.Sucesso, "Telefone válido");
        }

        [Fact]
        public void ErroCasoIdAdicionarTelefoneHandleInvalidos()
        {
            //Criando o nosso command
            var _command = new AdicionarTelefoneCommand(Guid.Empty, "11962553590");

            //Criando o nosso handle
            var _handle = new AdicionarTelefoneHandle(new FakeUsuarioRepository());

            //Pegando os valores informados
            var _result = (GenericCommandResult)_handle.Handle(_command);

            //Validando os parametros
            Assert.False(_result.Sucesso, "Identificador do usuário válido");
        }

        [Fact]
        public void ErroCasoTelefoneAdicionarTelefoneHandleInvalidos()
        {
            //Criando o nosso command
            var _command = new AdicionarTelefoneCommand(Guid.NewGuid(), "1124568");

            //Criando o nosso handle
            var _handle = new AdicionarTelefoneHandle(new FakeUsuarioRepository());

            //Pegando os valores informados
            var _result = (GenericCommandResult)_handle.Handle(_command);

            //Validando os parametros
            Assert.False(_result.Sucesso, "Telefone válido");
        }

        /*[Fact]
        public void SucessoCasoDadosAdicionarTelefoneHandleValidos()
        {
            //Criando o nosso command
            var _command = new AdicionarTelefoneCommand(Guid.NewGuid(), "+5511962553590");

            //Criando o nosso handle
            var _handle = new AdicionarTelefoneHandle(new FakeUsuarioRepository());

            //Pegando os valores informados
            var _result = (GenericCommandResult)_handle.Handle(_command);

            //Validando os parametros
            Assert.True(_result.Sucesso, "Telefone inválido");
        }*/
    }
}

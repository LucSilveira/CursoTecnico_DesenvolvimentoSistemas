﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DoLink.Comum.Utils
{
    public static class UploadFiles
    {
        public static string Local(IFormFile _file, string _caminho)
        {
            //Gera um nome unico para o arquivo concatenando com o tipo dele
            var _nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(_file.FileName);

            var _caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\Uploads\" + _caminho, _nomeArquivo);

            // passa para nosso repositorio o arquivo para o alocar
            using var _streamImagem = new FileStream(_caminhoArquivo, FileMode.Create);

            //faz uma copia do arquivo inserido no nosso repositorio
            _file.CopyTo(_streamImagem);

            return $"https://dolink.azurewebsites.net/Uploads/{_caminho}/{_nomeArquivo}";
        }
    }
}

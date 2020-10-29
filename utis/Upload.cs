using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace prjORMapi.utis
{
    public static class Upload
    {
        public static string Local(IFormFile file){
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-","") + Path.GetExtension(file.Imagem.FileName);
                    var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(),@"wwwRoot\upload\imagens", nomeArquivo);
                    using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);
                    file.CopyTo(streamImagem);

                  return "http://localhost:64061/" + nomeArquivo;
        }
    }
}
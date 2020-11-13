using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace prjORMapi.Domains
{
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }
        public float Preco { get; set; }
        [NotMapped]//nao mapeia a propriedade
        [JsonIgnore]//ignora o parametro de retorno do Json
        public IFormFile Imagem { get; set; }
        public string UrlImagem { get; set; }

        public List<PedidoItem>  PedidoItens { get; set; }
    }
}
 
using System;
using System.ComponentModel.DataAnnotations;

namespace prjORMapi.Domains
{
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }
        public float Preco { get; set; }
    }
}
 
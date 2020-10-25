using System;
using System.ComponentModel.DataAnnotations;

namespace prjORMapi.Domains
{
    public class Pedido
    {
        [Key]
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime MyProperty { get; set; }

        public Pedido()
        {
            Id = Guid.NewGuid();
        }
    }
}
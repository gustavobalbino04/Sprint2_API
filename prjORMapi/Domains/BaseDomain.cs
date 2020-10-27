using System;
using System.ComponentModel.DataAnnotations;

namespace prjORMapi.Domains
{
    //abstract - deixa seu cod mais seguro, pois nao vai consegui estanciar essa classe 
    public  abstract class BaseDomain
    {
        [Key]

        public Guid Id { get; set; }
        public BaseDomain()
        {
            Id = Guid.NewGuid();
        }
    }
}
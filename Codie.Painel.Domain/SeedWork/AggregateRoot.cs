using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codie.Painel.Domain.SeedWork
{
    public abstract class AggregateRoot : Entity
    {        
        public bool? Ativo { get; set; }
        public bool? Excluido { get; set; }
        public bool? Destaque { get; set; }
        public int? Ordem { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataEdicao { get; set; }

        protected AggregateRoot() : base() { }

    }
}

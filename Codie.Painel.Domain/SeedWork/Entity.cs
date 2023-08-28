using System.ComponentModel.DataAnnotations;

namespace Codie.Painel.Domain.SeedWork
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; protected set; }

    }
}

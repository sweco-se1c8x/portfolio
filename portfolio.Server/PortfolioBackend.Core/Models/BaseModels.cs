using System.ComponentModel.DataAnnotations;

namespace PortfolioBackend.PortfolioBackend.Core.Models
{
    public class BaseModels
    {
        [Key]
        public Guid Id { get; set; }

    }
}

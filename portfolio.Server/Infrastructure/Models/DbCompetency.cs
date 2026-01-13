using System.ComponentModel.DataAnnotations;
using portfolio.Server.Infrastructure.Models;

namespace portfolio.Server.Infrastructure.Models
{
    public class DbCompetency
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string CompetencyName { get; set; }

        public Guid ProjectId { get; set; }

        public DbProject Project { get; set; }
    }
}



using System.ComponentModel.DataAnnotations;
using portfolio.Server.Infrastructure.Models;

public class DbProject
{
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }
        public ICollection<DbCompetency> Competencies { get; set; }
}
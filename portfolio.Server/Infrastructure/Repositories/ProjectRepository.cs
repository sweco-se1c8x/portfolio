using Microsoft.EntityFrameworkCore;
using portfolio.Server.Infrastructure.Models;
using PortfolioBackend.PortfolioBackend.Core.Models;
using PortfolioBackend.PortfolioBackend.Core.Repositories;

namespace PortfolioBackend.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _dataContext;

        public ProjectRepository(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            var projects = await _dataContext.Projects
                .Include(p => p.Competencies)
                .ToListAsync();
            return projects.Select(p => new Project
            {
                ProjectName = p.ProjectName,
                Company = p.Company,
                Description = p.Description,
                ProjectStartDate = p.ProjectStartDate,
                ProjectEndDate = p.ProjectEndDate,
                Role = p.Role,
                Competencies = p.Competencies?.Select(c => new Competency
                {
                    CompetencyName = c.CompetencyName
                }).ToList() ?? new List<Competency>()
            });
        }

        public async Task<Project> GetByIdAsync(Guid projectId)
        {
            var project = await _dataContext.Projects.FirstOrDefaultAsync(p => p.Id == projectId);
            if (project == null) return null;

            return new Project
            {
                ProjectName = project.ProjectName,
                Company = project.Company,
                Description = project.Description,
                ProjectStartDate = project.ProjectStartDate,
                ProjectEndDate = project.ProjectEndDate,
                Role = project.Role,
                Competencies = project.Competencies?.Select(c => new Competency
                {
                    CompetencyName = c.CompetencyName
                }).ToList() ?? new List<Competency>()
            };
        }

        public async Task<Project> Insert(Project project)
        {
            var createdProject = new DbProject
            {
                ProjectName = project.ProjectName,
                Company = project.Company,
                Description = project.Description,
                ProjectStartDate = project.ProjectStartDate,
                Role = project.Role,
                ProjectEndDate = project.ProjectEndDate,
                Competencies = project.Competencies.Select(c => new DbCompetency
                {
                    CompetencyName = c.CompetencyName
                }).ToList()
            };

            _dataContext.Projects.Add(createdProject);
            await _dataContext.SaveChangesAsync();

            return new Project
            {
                Id = createdProject.Id,
                ProjectName = createdProject.ProjectName,
                Company = createdProject.Company,
                Description = createdProject.Description,
                ProjectStartDate = createdProject.ProjectStartDate,
                ProjectEndDate = createdProject.ProjectEndDate,
                Role = createdProject.Role,
                Competencies = createdProject.Competencies?.Select(c => new Competency
                {
                    CompetencyName = c.CompetencyName
                }).ToList() ?? new List<Competency>()
            };
        }

        public async Task<Project> Update(Guid projectId,Project project)
        {
            if (project == null) return null!;
            var updatedProject = await _dataContext.Projects
                .Include(p => p.Competencies)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            if (updatedProject == null) throw new KeyNotFoundException("Project not found");

            updatedProject.ProjectName = project.ProjectName;
            updatedProject.Company = project.Company;
            updatedProject.Description = project.Description;
            updatedProject.ProjectStartDate = project.ProjectStartDate;
            updatedProject.ProjectEndDate = project.ProjectEndDate;
            updatedProject.Role = project.Role;

            // Map Competencies from Project to DbProject
            updatedProject.Competencies = project.Competencies?.Select(c => new DbCompetency
            {
                CompetencyName = c.CompetencyName,
                ProjectId = updatedProject.Id
            }).ToList() ?? new List<DbCompetency>();

            _dataContext.Projects.Update(updatedProject);
            await _dataContext.SaveChangesAsync();

            return new Project
            {
                Id = updatedProject.Id,
                ProjectName = updatedProject.ProjectName,
                Company = updatedProject.Company,
                Description = updatedProject.Description,
                ProjectStartDate = updatedProject.ProjectStartDate,
                ProjectEndDate = updatedProject.ProjectEndDate,
                Role = updatedProject.Role,
                Competencies = updatedProject.Competencies?.Select(c => new Competency
                {
                    CompetencyName = c.CompetencyName
                }).ToList() ?? new List<Competency>()
            };
        }

        public async Task Delete(Guid projectId)
        {
            var project = await _dataContext.Projects.FirstOrDefaultAsync(p => p.Id == projectId);
            if (project == null) throw new KeyNotFoundException("Project not found");

            _dataContext.Projects.Remove(project);
            _ = SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}

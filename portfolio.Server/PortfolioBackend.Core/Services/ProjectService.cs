using PortfolioBackend.PortfolioBackend.Core.Dto;
using PortfolioBackend.PortfolioBackend.Core.Models;
using PortfolioBackend.PortfolioBackend.Core.Repositories;
using PortfolioBackend.PortfolioBackend.Core.Exceptions;

namespace PortfolioBackend.PortfolioBackend.Core.Services
{
    public sealed class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
        }

        public async Task<Project> CreateAsync(Project project)
        {
            await _projectRepository.Insert(project);
            return null;
        }

        public async Task DeleteAsync(Guid projectId)
        {
            await _projectRepository.Delete(projectId);
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            var projects = await _projectRepository.GetAllAsync();
            return projects;
        }

        public async Task<Project> GetByIdAsync(Guid projectId)
        {
            return await _projectRepository.GetByIdAsync(projectId);
        }


        public async Task<Project> UpdateAsync(Guid projectId, Project project)
        {
            var updatedProject = await _projectRepository.Update(projectId, project);
            return updatedProject;
        }
    }
}

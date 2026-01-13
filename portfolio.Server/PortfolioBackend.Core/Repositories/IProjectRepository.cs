using PortfolioBackend.PortfolioBackend.Core.Models;

namespace PortfolioBackend.PortfolioBackend.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(Guid projectId);
        Task<Project> Insert(Project project);
        Task<Project> Update(Guid projectId, Project project);
        Task Delete(Guid projectId);
        Task<int> SaveChangesAsync();

    }
}

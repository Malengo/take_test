using Api.Domain.Entities;

namespace Api.Domain.Interface
{
    public interface IGitRepoInterface
    {
        Task<IEnumerable<GitEntity>> GetAll();
    }
}

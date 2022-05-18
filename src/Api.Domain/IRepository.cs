using Api.Domain.Entities;

namespace Api.Domain
{
    public interface IRepository
    {
        Task<IEnumerable<GitEntity>> GetAll();
    }
}

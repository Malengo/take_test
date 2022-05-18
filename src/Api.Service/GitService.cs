using Api.Domain;
using Api.Domain.Entities;
using Api.Domain.Interface;

namespace Api.Service
{
    public class GitService : IGitRepoInterface
    {
        private IRepository _repository;

        public GitService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<GitEntity>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}


using Api.Domain;
using Api.Domain.Entities;
using Api.Domain.Interface;
using Octokit;

namespace Api.Data.Repository
{
    public class GitRepository : IRepository
    {
        public async Task<IEnumerable<GitEntity>> GetAll()
        {
            try
            {
                List<GitEntity> git = new List<GitEntity>();
                var github = new GitHubClient(new ProductHeaderValue("Malengo"));
                var basicAuth = new Credentials("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"); // NOTE: not real credentials
                github.Credentials = basicAuth;
                var response = await github.Repository.GetAllForUser("takenet");
                List<GitEntity> api = new List<GitEntity>();
                foreach (var item in response)
                {
                    GitEntity repo = new GitEntity();
                    if (item.Language == "C#")
                    {
                        repo.AvatarUrl = item.Owner.AvatarUrl;
                        repo.Description = item.Description;
                        repo.Language = item.Language;
                        repo.FullName = item.Name;
                        repo.CreatAt = DateTime.Parse(item.CreatedAt.Date.ToShortDateString().ToString());
                        api.Add(repo);
                    }
                }

                api = api.OrderBy(o => o.CreatAt).ToList();
                api.RemoveRange(5, api.Count - 5);
                return api;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



    }
}

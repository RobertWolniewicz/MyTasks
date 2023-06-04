using MyTasks.Core.Models.Domains;

namespace MyTasks.Core.Repositorys
{
    public interface ITaskRepository
    {
        IEnumerable<Core.Models.Domains.Task> Get(string userId,
         bool isExecuted = false,
         int categoryId = 0,
         string title = null);

        IEnumerable<Category> GetCategories();

        Core.Models.Domains.Task Get(int id, string userId);

        void Add(Core.Models.Domains.Task task);

        void Update(Core.Models.Domains.Task task);

        void Finish(int id, string userId);

        void Delete(int id, string userId);

    }
}

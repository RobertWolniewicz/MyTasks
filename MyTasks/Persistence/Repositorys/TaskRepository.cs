using MyTasks.Core.Models.Domains;

namespace MyTasks.Persistence.Repositorys
{
    public class TaskRepository
    {
        public IEnumerable<Core.Models.Domains.Task> Get(string userId, 
            bool isExecuted = false, 
            int categoryId = 0, 
            string title = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Core.Models.Domains.Task Get(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public void Add(Core.Models.Domains.Task task)
        {
            throw new NotImplementedException();
        }

        public void Update(Core.Models.Domains.Task task)
        {
            throw new NotImplementedException();
        }

        internal void Finish(int id, string userId)
        {
            throw new NotImplementedException();
        }
    }
}

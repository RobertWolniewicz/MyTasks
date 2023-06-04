using MyTasks.Persistence.Repositorys;

namespace MyTasks.Persistence
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public TaskRepository Task { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}

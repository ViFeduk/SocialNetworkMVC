using Microsoft.EntityFrameworkCore;

namespace SocialNetworkMVC.DataBase.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private MyAppContext _appContext;
        private readonly IServiceProvider _serviceProvider;

        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        public UnitOfWork(MyAppContext app, IServiceProvider serviceProvider)
        {
            _appContext = app;
            _serviceProvider = serviceProvider;
        }
        public void Dispose()
        {
           
        }

        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = true) where TEntity : class
        {
            if (_repositories.TryGetValue(typeof(TEntity), out var repository))
            {
                return (IRepository<TEntity>)repository;
            }

            if (hasCustomRepository)
            {
                // Используем _serviceProvider для попытки получить кастомный репозиторий
                var customRepository = _serviceProvider.GetService(typeof(IRepository<TEntity>)) as IRepository<TEntity>;
                if (customRepository != null)
                {
                    _repositories[typeof(TEntity)] = customRepository;
                    return customRepository;
                }
            }

            // Если кастомный репозиторий не найден, создаем базовый
            var newRepository = new Repository<TEntity>(_appContext);
            _repositories[typeof(TEntity)] = newRepository;
            return newRepository;

        }
        public int SaveChanges(bool ensureAutoHistory = false)
        {
            throw new NotImplementedException();
        }
    }



}

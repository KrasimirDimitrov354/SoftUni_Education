using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories.Contracts
{
    public interface IRepository<T>
    {
        public IReadOnlyCollection<T> Models { get; }

        void AddModel(T model);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using ChristmasPastryShop.Models.Booths.Contracts;

namespace ChristmasPastryShop.Repositories.Contracts
{
    public class BoothRepository : IRepository<IBooth>
    {
        private List<IBooth> booths;

        public BoothRepository()
        {
            booths = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models
        {
            get { return booths.AsReadOnly(); }
        }

        public void AddModel(IBooth booth)
        {
            booths.Add(booth);
        }
    }
}

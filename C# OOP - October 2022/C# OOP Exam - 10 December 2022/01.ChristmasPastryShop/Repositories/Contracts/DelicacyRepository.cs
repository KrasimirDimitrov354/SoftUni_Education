using System;
using System.Collections.Generic;
using System.Text;

using ChristmasPastryShop.Models.Delicacies.Contracts;

namespace ChristmasPastryShop.Repositories.Contracts
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> delicacies;

        public DelicacyRepository()
        {
            delicacies = new List<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models
        {
            get { return delicacies.AsReadOnly(); }
        }

        public void AddModel(IDelicacy delicacy)
        {
            delicacies.Add(delicacy);
        }
    }
}

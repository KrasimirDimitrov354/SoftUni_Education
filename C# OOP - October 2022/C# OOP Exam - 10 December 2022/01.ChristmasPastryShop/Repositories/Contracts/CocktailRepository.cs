using System;
using System.Collections.Generic;
using System.Text;

using ChristmasPastryShop.Models.Cocktails.Contracts;

namespace ChristmasPastryShop.Repositories.Contracts
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private List<ICocktail> cocktails;

        public CocktailRepository()
        {
            cocktails = new List<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models
        {
            get { return cocktails.AsReadOnly(); }
        }

        public void AddModel(ICocktail cocktail)
        {
            cocktails.Add(cocktail);
        }
    }
}

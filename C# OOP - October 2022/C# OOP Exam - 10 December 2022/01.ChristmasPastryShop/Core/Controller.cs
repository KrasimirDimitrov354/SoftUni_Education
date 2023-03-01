using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private readonly string[] VALID_COCKTAILS = { "MulledWine", "Hibernation" };
        private readonly string[] VALID_DELICACIES = { "Gingerbread", "Stolen" };

        private BoothRepository booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            Booth booth = new Booth(booths.Models.Count + 1, capacity);
            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, booth.Capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (!VALID_DELICACIES.Contains(delicacyTypeName))
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            var currentBooth = booths.Models.First(b => b.BoothId == boothId);

            if (currentBooth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }
            else
            {
                switch (delicacyTypeName)
                {
                    case "Gingerbread":
                        currentBooth.DelicacyMenu.AddModel(new Gingerbread(delicacyName));
                        break;
                    case "Stolen":
                        currentBooth.DelicacyMenu.AddModel(new Stolen(delicacyName));
                        break;
                }

                return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
            }
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (!VALID_COCKTAILS.Contains(cocktailTypeName))
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Large" && size != "Middle" && size != "Small")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            var currentBooth = booths.Models.First(b => b.BoothId == boothId);

            if (currentBooth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }
            else
            {
                switch (cocktailTypeName)
                {
                    case "MulledWine":
                        currentBooth.CocktailMenu.AddModel(new MulledWine(cocktailName, size));
                        break;
                    case "Hibernation":
                        currentBooth.CocktailMenu.AddModel(new Hibernation(cocktailName, size));
                        break;
                }

                return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
            }
        }

        public string ReserveBooth(int countOfPeople)
        {
            var applicableBooth = booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (applicableBooth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }
            else
            {
                applicableBooth.ChangeStatus();
                return string.Format(OutputMessages.BoothReservedSuccessfully, applicableBooth.BoothId, countOfPeople);
            }
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderTokens = order.Split('/');

            string itemTypeName = orderTokens[0];
            string itemName = orderTokens[1];
            int count = int.Parse(orderTokens[2]);

            var currentBooth = booths.Models.First(b => b.BoothId == boothId);

            if (VALID_COCKTAILS.Contains(itemTypeName))
            {
                var currentCocktails = currentBooth.CocktailMenu.Models;

                if (!currentCocktails.Any(c => c.Name == itemName))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                string size = orderTokens[3];

                var orderedCocktail = currentCocktails
                    .FirstOrDefault(c => c.GetType().Name == itemTypeName
                    && c.Name == itemName && c.Size == size);

                if (orderedCocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }
                else
                {
                    currentBooth.UpdateCurrentBill(orderedCocktail.Price * count);
                    return string.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
                }
            }
            else if (VALID_DELICACIES.Contains(itemTypeName))
            {
                var currentDelicacies = currentBooth.DelicacyMenu.Models;

                if (!currentDelicacies.Any(d => d.Name == itemName))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                var orderedDelicacy = currentDelicacies
                    .FirstOrDefault(d => d.GetType().Name == itemTypeName
                    && d.Name == itemName);

                if (orderedDelicacy == null)
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }
                else
                {
                    currentBooth.UpdateCurrentBill(orderedDelicacy.Price * count);
                    return string.Format(OutputMessages.SuccessfullyOrdered, boothId, count, itemName);
                }
            }
            else
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }
        }

        public string LeaveBooth(int boothId)
        {
            var booth = booths.Models.First(b => b.BoothId == boothId);
            double currentBill = booth.CurrentBill;

            booth.Charge();
            booth.ChangeStatus();

            StringBuilder output = new StringBuilder();
            string formattedBill = $"{Math.Round(currentBill, 2):F2}";

            output.AppendLine(string.Format(OutputMessages.GetBill, formattedBill));
            output.AppendLine(string.Format(OutputMessages.BoothIsAvailable, boothId));

            return output.ToString().TrimEnd();
        }

        public string BoothReport(int boothId)
        {
            return booths.Models
                .First(b => b.BoothId == boothId)
                .ToString();
        }
    }
}

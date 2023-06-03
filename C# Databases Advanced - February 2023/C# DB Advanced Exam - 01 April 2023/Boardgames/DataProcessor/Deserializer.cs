namespace Boardgames.DataProcessor;

using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

using Data;
using Data.Common;
using Data.Models;
using ImportDto;
using Utilities;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data!";

    private const string SuccessfullyImportedCreator
        = "Successfully imported creator – {0} {1} with {2} boardgames.";

    private const string SuccessfullyImportedSeller
        = "Successfully imported seller - {0} with {1} boardgames.";

    public static string ImportCreators(BoardgamesContext context, string xmlString)
    {
        StringBuilder output = new StringBuilder();
        AutoMapperHelper autoMapperHelper = new AutoMapperHelper();
        XmlHelper xmlHelper = new XmlHelper();

        var creatorDTOs = xmlHelper.Deserialize<ImportCreatorDTO[]>(xmlString, "Creators");
        ICollection<Creator> validCreators = new HashSet<Creator>();

        foreach (var creatorDTO in creatorDTOs)
        {
            if (string.IsNullOrEmpty(creatorDTO.FirstName) ||
                creatorDTO.FirstName.Length < FieldValidation.CreatorNameMinLength ||
                creatorDTO.FirstName.Length > FieldValidation.CreatorNameMaxLength ||
                creatorDTO.LastName.Length < FieldValidation.CreatorNameMinLength ||
                creatorDTO.LastName.Length > FieldValidation.CreatorNameMaxLength)
            {
                output.AppendLine(ErrorMessage);
                continue;
            }

            Creator creator = autoMapperHelper.Initialize().Map<Creator>(creatorDTO);
            creator.Boardgames.Clear();

            foreach (var boardgameDTO in creatorDTO.Boardgames)
            {
                if (string.IsNullOrEmpty(boardgameDTO.Name) ||
                    boardgameDTO.Name.Length < FieldValidation.BoardgameNameMinLength ||
                    boardgameDTO.Name.Length > FieldValidation.BoardgameNameMaxLength ||
                    boardgameDTO.Rating < FieldValidation.BoardgameRatingMinValue ||
                    boardgameDTO.Rating > FieldValidation.BoardgameRatingMaxValue ||
                    boardgameDTO.YearPublished < FieldValidation.BoardgameYearPublishedMinValue ||
                    boardgameDTO.YearPublished > FieldValidation.BoardgameYearPublishedMaxValue)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                Boardgame boardgame = autoMapperHelper.Initialize().Map<Boardgame>(boardgameDTO);
                creator.Boardgames.Add(boardgame);
            }

            output.AppendLine(string.Format(SuccessfullyImportedCreator, 
                creator.FirstName, 
                creator.LastName, 
                creator.Boardgames.Count));

            validCreators.Add(creator);
        }

        context.Creators.AddRange(validCreators);
        context.SaveChanges();

        return output.ToString().TrimEnd();
    }

    public static string ImportSellers(BoardgamesContext context, string jsonString)
    {
        StringBuilder output = new StringBuilder();
        AutoMapperHelper autoMapperHelper = new AutoMapperHelper();

        var sellerDTOs = JsonConvert.DeserializeObject<ImportSellerDTO[]>(jsonString);
        ICollection<Seller> validSellers = new HashSet<Seller>();

        string websitePattern = @"^www\.[a-zA-Z\d-]+\.com$";

        foreach (var sellerDTO in sellerDTOs!)
        {
            if (string.IsNullOrEmpty(sellerDTO.Name) ||
                sellerDTO.Name.Length < FieldValidation.SellerNameMinLength ||
                sellerDTO.Name.Length > FieldValidation.SellerNameMaxLength ||
                string.IsNullOrEmpty(sellerDTO.Address) ||
                sellerDTO.Address.Length < FieldValidation.SellerAddressMinLength ||
                sellerDTO.Address.Length > FieldValidation.SellerAddressMaxLength ||
                string.IsNullOrEmpty(sellerDTO.Country) ||
                string.IsNullOrEmpty(sellerDTO.Website) ||
                !Regex.IsMatch(sellerDTO.Website, websitePattern))
            {
                output.AppendLine(ErrorMessage);
                continue;
            }

            Seller seller = autoMapperHelper.Initialize().Map<Seller>(sellerDTO);
            seller.BoardgamesSellers.Clear();

            foreach (var boardgameId in sellerDTO.BoardgamesIds.DistinctBy(b => b))
            {
                if (!context.Boardgames.Any(b => b.Id == boardgameId))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                BoardgameSeller boardgameSeller = new BoardgameSeller
                {
                    BoardgameId = boardgameId
                };

                seller.BoardgamesSellers.Add(boardgameSeller);
            }

            output.AppendLine(string.Format(SuccessfullyImportedSeller, 
                seller.Name, 
                seller.BoardgamesSellers.Count));

            validSellers.Add(seller);
        }

        context.Sellers.AddRange(validSellers);
        context.SaveChanges();

        return output.ToString().TrimEnd();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }
}

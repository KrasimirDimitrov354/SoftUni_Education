namespace Boardgames.DataProcessor;

using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

using Data;
using Utilities;
using DataProcessor.ExportDto;

public class Serializer
{
    public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
    {
        AutoMapperHelper autoMapperHelper = new AutoMapperHelper();
        XmlHelper xmlHelper = new XmlHelper();

        var creators = context.Creators
            .Where(c => c.Boardgames.Count >= 1)
            .ProjectTo<ExportCreatorDTO>(autoMapperHelper.Initialize().ConfigurationProvider)
            .ToArray()
            .OrderByDescending(c => int.Parse(c.BoardgamesCount))
            .ThenBy(c => c.CreatorName)
            .ToArray();

        return xmlHelper.Serialize(creators, "Creators");
    }

    public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
    {
        var sellers = context.Sellers
            .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year &&
                                                      bs.Boardgame.Rating <= rating))
            .Select(s => new
            {
                s.Name,
                s.Website,
                Boardgames = s.BoardgamesSellers
                                .Where(bs => bs.Boardgame.YearPublished >= year &&
                                             bs.Boardgame.Rating <= rating)
                                .Select(bs => new
                                {
                                    bs.Boardgame.Name,
                                    bs.Boardgame.Rating,
                                    bs.Boardgame.Mechanics,
                                    Category = bs.Boardgame.CategoryType.ToString()
                                })
                                .OrderByDescending(b => b.Rating)
                                .ThenBy(b => b.Name)
                                .ToArray()
            })
            .OrderByDescending(s => s.Boardgames.Count())
            .ThenBy(s => s.Name)
            .Take(5)
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(sellers, Formatting.Indented);
    }
}
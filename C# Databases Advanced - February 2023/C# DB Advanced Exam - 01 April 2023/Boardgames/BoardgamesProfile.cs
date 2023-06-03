namespace Boardgames;

using AutoMapper;

using Data.Models;
using Data.Models.Enums;
using DataProcessor.ImportDto;
using DataProcessor.ExportDto;

public class BoardgamesProfile : Profile
{
    // DO NOT CHANGE OR RENAME THIS CLASS!
    public BoardgamesProfile()
    {
        this.CreateMap<ImportBoardgameDTO, Boardgame>()
            .ForMember(d => d.CategoryType, opt => opt.MapFrom(s => (CategoryType)s.CategoryType));
        this.CreateMap<Boardgame, ExportBoardgameDTO>()
            .ForMember(d => d.BoardgameName, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.BoardgameYearPublished, opt => opt.MapFrom(s => s.YearPublished));

        this.CreateMap<ImportCreatorDTO, Creator>()
            .ForSourceMember(s => s.Boardgames, opt => opt.DoNotValidate());
        this.CreateMap<Creator, ExportCreatorDTO>()
            .ForMember(d => d.CreatorName, opt => opt.MapFrom(s => s.FirstName + " " + s.LastName))
            .ForMember(d => d.BoardgamesCount, opt => opt.MapFrom(s => s.Boardgames.Count))
            .ForMember(d => d.Boardgames, opt => opt.MapFrom(s => s.Boardgames.OrderBy(b => b.Name)));


        this.CreateMap<ImportSellerDTO, Seller>()
            .ForSourceMember(s => s.BoardgamesIds, opt => opt.DoNotValidate());
    }
}
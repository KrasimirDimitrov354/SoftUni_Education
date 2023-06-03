namespace Boardgames.Utilities;

using AutoMapper;

public class AutoMapperHelper
{
    public IMapper Initialize()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<BoardgamesProfile>();
        }));
    }
}

using Mapster;
using Silky.Position.Application.Contracts.Position.Dtos;

namespace Silky.Position.Domain;

public class Mapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<PositionDtoBase, Position>()
            .Ignore(p => p.IsPublic);
    }
}
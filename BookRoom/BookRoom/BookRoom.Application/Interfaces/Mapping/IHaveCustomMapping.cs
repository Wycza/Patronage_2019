using AutoMapper;

namespace BookRoom.Application.Interfaces.Mapping
{
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}

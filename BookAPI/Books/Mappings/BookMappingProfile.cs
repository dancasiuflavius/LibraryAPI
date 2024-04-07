using AutoMapper;
using BookAPI.Books.Model;
using BookAPI.Books.DTO;

namespace BookAPI.Books.Mappings
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<CreateBookRequest, Book>();
        }
    }
}

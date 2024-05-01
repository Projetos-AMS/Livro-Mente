using AutoMapper;
using LivroMente.Domain.Commands.BookCommands;
using LivroMente.Domain.Models.BookModel;
using LivroMente.Domain.Models.CategoryBookModel;
using LivroMente.Domain.Models.PaymentModel;
using LivroMente.Domain.Requests;
using LivroMente.Domain.ViewModels;

namespace LivroMente.Data.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryBook,CategoryBookViewModel>().ReverseMap();
            CreateMap<CategoryBook,CategoryBookRequest>().ReverseMap();
            CreateMap<Payment,PaymentRequest>().ReverseMap();
            CreateMap<Book,BookAddCommand>().ReverseMap();
        }
    }
}
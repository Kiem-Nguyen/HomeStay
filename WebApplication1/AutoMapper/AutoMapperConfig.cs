using AutoMapper;
using WebApplication1.Models;
using WebApplication1.ViewModels;


namespace WebApplication1.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                //x.AddProfile<DataToModelMappingProfile>();

                x.CreateMap<HomeStayModel, WebApplication1.Models.HomeStay>().ReverseMap().MaxDepth(4);




                //x.AddProfile<ModelToDataMappingProfile>();

            });
        }
    }
}
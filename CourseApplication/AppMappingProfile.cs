using AutoMapper;
using CourseApplication.Data.Entities;
using CourseApplication.Models.CollectionModels;
using CourseApplication.Models.CommentsModels;
using CourseApplication.Models.CustomFieldModels;
using CourseApplication.Models.CustomFieldValueModels;
using CourseApplication.Models.ItemModel;

namespace CourseApplication;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {			
        CreateMap<CustomFieldsDisplayModel, CustomField>().ReverseMap();
        CreateMap<CreateCollectionModel, Collection>().ReverseMap();
        CreateMap<CollectionEditModel, Collection>().ReverseMap();
        CreateMap<CollectionDisplayModel, CollectionEditModel>().ReverseMap();
        CreateMap<CollectionDisplayModel, Collection>().ReverseMap();
        CreateMap<CustomFieldsEditModel, CustomFieldsDisplayModel>().ReverseMap();
        CreateMap<CustomFieldsEditModel, CustomField>().ReverseMap();
        CreateMap<CustomFieldsValues, CustomFieldValueDisplayModel>().ReverseMap();
        CreateMap<CreateItemModel, Item>().ReverseMap();
        CreateMap<ItemsDisplayModel, Item>().ReverseMap();
        CreateMap<EditItemModel, Item>().ReverseMap();
        CreateMap<UserItemComment, CreateCommentModel>().ReverseMap();
        CreateMap<CustomFieldsCreateModel, CustomField>().ReverseMap();
        CreateMap<CustomFieldsDisplayModel, CustomFieldsValues >()
            .ForMember(dest => dest.CustomFieldId,
                opt =>
                    opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Value,
                opt => 
                    opt.MapFrom(src => src.Value))
            .ReverseMap();
    }
}
using CourseApplication.Data.Entities;
using CourseApplication.Models.ItemModel;

namespace CourseApplication.Search.Searchables;

public class SearchableArticle : Searchable
{
    public SearchableArticle(ItemsDisplayModel item)
    {
        var descriptionPath = $"Item/ItemViewPage?id={item.Id}";
        DescriptionPath     = descriptionPath;
        Description = item.CreateTime.ToString();
        Href                = $"/articles/read/{item.Id}";
        Id                  = item.Id;
        Title               = item.Name;
    }

    public override string Description { get; }
    public override string DescriptionPath { get; }
    public override string Href { get; }
    public override string Id { get; }
    public override string Title { get; }
}
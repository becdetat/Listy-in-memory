using Listy.Web.Controllers.Api;

namespace Listy.Web.Models.Api.List
{
    public class ListUpdateModel
    {
        public string Name { get; set; }
        public ListItemUpdateModel[] Items { get; set; }
    }
}
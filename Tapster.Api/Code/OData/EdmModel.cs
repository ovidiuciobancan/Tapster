using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using Tapster.Api.Models.Categories;
using Tapster.Api.Models.Managers;
using Tapster.Api.Models.Products;
using Tapster.Api.Models.Venues;

namespace Tapster.Api.Code.OData
{
    public class TapsterEdmModel
    {
       public static IEdmModel GetModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<ManagerVM>("Managers");
            builder.EntitySet<VenueVM>("Venues");
            builder.EntitySet<CategoryVM>("MenuCategories");
            builder.EntitySet<CategoryVM>("SubCategories");
            builder.EntitySet<ProductVM>("Products");

            builder.EnableLowerCamelCase();
            return builder.GetEdmModel();
        }
    }
}

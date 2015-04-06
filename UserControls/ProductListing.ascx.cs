using SitefinityWebApp.Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.RelatedData; 

namespace SitefinityWebApp.UserControls
{
    public partial class ProductListing : System.Web.UI.UserControl
    {
        #region EventHandlers

        protected void Page_Load(object sender, EventArgs e)
        {
            IQueryable<DynamicContent> products = DynamicModules.RetrieveCollectionOfProducts();

            rptProducts.DataSource = products;
            rptProducts.DataBind();
        }
        protected void rptProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Literal productTitle = e.Item.FindControl("productTitle") as Literal;
            Literal productCategory = e.Item.FindControl("productCategory") as Literal;

            if (null == e.Item.DataItem)
                return;

            DynamicContent product = e.Item.DataItem as DynamicContent;

            if (null != productTitle)
            {
                productTitle.Text = product.GetValue<Lstring>("Title");

                DynamicContent productCategoryItem = product.GetRelatedItems("ProductCategory").FirstOrDefault() as DynamicContent;
                productCategory.Text = productCategoryItem.GetValue<Lstring>("Title");
            }
        }

        #endregion
    }
}
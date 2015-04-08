using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Pages.Model;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.GenericContent.Model;

namespace SitefinityWebApp.UserControls
{
    /// <summary>
    /// http://docs.sitefinity.com/for-developers-query-pages
    /// </summary>
    public partial class Navigation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var firstLevelPages = App.WorkWith()
                                 .Pages()
                                 .LocatedIn(Telerik.Sitefinity.Fluent.Pages.PageLocation.Frontend)
                                 .Where(p => p.Parent.Title == "Pages" && p.NodeType == NodeType.Standard && p.ShowInNavigation == true && p.IsDeleted == false && p.Page.Status == ContentLifecycleStatus.Live)
                                 .ThatArePublished()
                                 .Get()
                                 .OrderBy(p => p.Ordinal);

            rptNavigation.DataSource = firstLevelPages.Select(p => new
            {
                Title = p.Title,
                Url = Page.ResolveUrl(p.GetFullUrl()),
                secondLevelPages = GetSecondLevelPages(p.PageId).Select(n => new { Title = n.Title, Url = Page.ResolveUrl(n.GetFullUrl()) })
            });
            rptNavigation.DataBind();

        }

        protected List<PageNode> GetSecondLevelPages(Guid pageId)
        {
            var childNodes = App.WorkWith()
                                 .Pages()
                                 .LocatedIn(Telerik.Sitefinity.Fluent.Pages.PageLocation.Frontend)
                                 .Where(p => p.Parent.PageId == pageId && p.NodeType == NodeType.Standard && p.ShowInNavigation == true && p.IsDeleted == false && p.Page.Status == ContentLifecycleStatus.Live)
                                 .ThatArePublished()
                                 .Get()
                                 .OrderBy(p => p.Ordinal);
            return childNodes.ToList();
        }
    }
}
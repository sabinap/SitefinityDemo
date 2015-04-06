using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.DynamicModules.Model;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;

namespace SitefinityWebApp.Application.Core
{
    public static class DynamicModules
    {
        
        #region Properties

        public static Type productType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.Product.Product");
        
        #endregion

        #region Methods

        public static IQueryable<DynamicContent> RetrieveCollectionOfProducts()
        {
            var providerName = String.Empty;
            DynamicModuleManager dynamicModuleManager = DynamicModuleManager.GetManager(providerName);
            var myCollection = dynamicModuleManager.GetDataItems(productType).Where(p=>p.Visible && p.Status == ContentLifecycleStatus.Live);
            return myCollection;
        }

        #endregion


    }
}
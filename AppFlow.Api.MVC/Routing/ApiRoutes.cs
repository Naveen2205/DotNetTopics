using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFlow.Api.MVC.Routing
{
    public struct ApiRoutes
    {
        public struct HomeRoutes
        {
            public const string INDEX = "Home-Index";
            public const string DATA = "Home-Data";
            public const string ADD = "Home-Add";
            public const string EDIT = "home/update/{filter}";
            public const string BULK_EDIT = "Home-Data-Bulk-Edit";
            public const string BULK_EDIT_ALL = "Home-Data-Bulk-Edit-All";
            public const string DELETE = "Home-Data-Delete";
            public const string BULk_DELETE = "Home-Data-Bulk-Delete";
            public const string BULK_DELETE_ALL = "Home-Data-Bulk-Delete-All";
            public const string CLOSE = "Home-Data-Close";
            public const string PREVIOUS = "Home-Previous";
            public const string EXPORT = "Home-Export";
            public const string EXPORT_ALL = "Home-Export-All";
            public const string IMPORT = "Home-Import";
        }
    }
}

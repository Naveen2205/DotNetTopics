using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFlow.CommonConfiguration.FieldMetaProvider;
using AppFlow.Columns;

namespace AppFlow.MetaProvider
{
    public class HomeMetaProvider
    {
        public Dictionary<string, FieldDefinition> Fields;
        public HomeMetaProvider()
        {
            Fields = new Dictionary<string, FieldDefinition>
            {
                {
                    HomeColumn.FirstName,
                    new FieldDefinition().IsSearchable().IsSortable().IsEditable()
                },
                {
                    HomeColumn.LastName,
                    new FieldDefinition().IsSearchable().IsSortable().IsEditable()
                },
                {
                    HomeColumn.DOB,
                    new FieldDefinition().IsSearchable().IsSortable().IsEditable()
                },
                {
                    HomeColumn.Gender,
                    new FieldDefinition().IsSearchable().IsSortable().IsEditable()
                },
                {
                    HomeColumn.City,
                    new FieldDefinition().IsSearchable().IsSortable().IsEditable()
                },
                {
                    HomeColumn.Country,
                    new FieldDefinition().IsSearchable().IsSortable().IsEditable()
                }
            };
        }
    }
}

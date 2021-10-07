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
                    new FieldDefinition().IsSearchable(true).IsSortable(true).IsEditable(true)
                },
                {
                    HomeColumn.LastName,
                    new FieldDefinition().IsSearchable(true).IsSortable(true).IsEditable(true)
                },
                {
                    HomeColumn.DOB,
                    new FieldDefinition().IsSearchable(true).IsSortable(true).IsEditable(true)
                },
                {
                    HomeColumn.Gender,
                    new FieldDefinition().IsSearchable(true).IsSortable(true).IsEditable(true)
                },
                {
                    HomeColumn.City,
                    new FieldDefinition().IsSearchable(true).IsSortable(true).IsEditable(true)
                },
                {
                    HomeColumn.Country,
                    new FieldDefinition().IsSearchable(true).IsSortable(true).IsEditable(true)
                }
            };
        }
    }
}

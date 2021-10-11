using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFlow.CommonConfiguration.FieldMetaProvider
{
    public class FieldDefinition : IFieldDefinition
    {
        public string DataSource { get; private set; }
        public bool Searchable { get; private set; }
        public bool Sortable { get; private set; }
        public bool Editable { get; private set; }

        public FieldDefinition()
        {
            DataSource = null;
            Searchable = false;
            Sortable = false;
            Editable = false;
        }

        public FieldDefinition WithDataSource(string dataSource)
        {
            DataSource = dataSource;
            return this;
        }
        public FieldDefinition IsSearchable()
        {
            Searchable = true;
            return this;
        }
        public FieldDefinition IsSortable()
        {
            Sortable = true;
            return this;
        }
        public FieldDefinition IsEditable()
        {
            Editable = true;
            return this;
        }
    }
}

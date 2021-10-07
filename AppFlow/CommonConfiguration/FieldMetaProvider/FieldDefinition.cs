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

        public FieldDefinition WithDataSource(string dataSource)
        {
            DataSource = dataSource;
            return this;
        }
        public FieldDefinition IsSearchable(bool isSearchable)
        {
            Searchable = isSearchable;
            return this;
        }
        public FieldDefinition IsSortable(bool isSortable)
        {
            Sortable = isSortable;
            return this;
        }
        public FieldDefinition IsEditable(bool isEditable)
        {
            Editable = isEditable;
            return this;
        }
    }
}

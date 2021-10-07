using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFlow.CommonConfiguration.FieldMetaProvider
{
    public interface IFieldDefinition
    {
        public FieldDefinition IsSearchable(bool isSearchable);
        public FieldDefinition IsSortable(bool isSortable);
        public FieldDefinition IsEditable(bool isEditable);
        public FieldDefinition WithDataSource(string dataSource);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFlow.CommonConfiguration.FieldMetaProvider
{
    public interface IFieldDefinition
    {
        public FieldDefinition IsSearchable();
        public FieldDefinition IsSortable();
        public FieldDefinition IsEditable();
        public FieldDefinition WithDataSource(string withDataSource);
    }
}

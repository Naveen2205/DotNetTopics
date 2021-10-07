using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFlow.Mappers;
using AppFlow.CommonConfiguration.FieldMetaProvider;

namespace AppFlow.CommonClass.Grid
{
    public class GridResultCell
    {
        public string ColumnName { get; }
        public string ColumnData { get; }
        public FieldDefinition FieldMeta { get; }
        public GridResultCell(
                string _columnName,
                string _columnData,
                FieldDefinition _fieldMeta
            )
        {
            ColumnName = _columnName;
            ColumnData = _columnData;
            FieldMeta = _fieldMeta;
        }
    }
}

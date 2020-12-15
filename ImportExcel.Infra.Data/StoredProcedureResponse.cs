using System;
using System.Collections.Generic;

namespace ImportExcel.Infra.Data
{
    public class StoredProcedureResponse<T>
    {
        public IList<IList<T>> ResultSets { get; set; }
        public Object OutputParameters { get; set; }
        public object ReturnValue { get; set; }
    }
}
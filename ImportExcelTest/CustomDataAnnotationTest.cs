using ImportExcel.Domain.Model;
using ImportExcel.Domain.Utils.CustomDataAnnotations;
using System;
using System.Reflection;
using Xunit;

namespace ImportExcelTest
{
    public class CustomDataAnnotationTest
    {
        [Fact]
        public void GetRowValue_MateriaPrima_Altura_Test()
        {
            Type type = typeof(T_importacao_modelo_bd_materia_prima);
            var row = type.GetProperty("altura").GetCustomAttribute(typeof(Row)) as Row;

            Assert.True(row.Value == 6);
        }

        [Fact]
        public void GetColumnValue_MateriaPrima_Altura_Test()
        {
            Type type = typeof(T_importacao_modelo_bd_materia_prima);
            var prop = type.GetProperty("altura");
            var column = prop.GetCustomAttribute(typeof(Column)) as Column;

            Assert.True(column.Value == 5);
        }
    }
}
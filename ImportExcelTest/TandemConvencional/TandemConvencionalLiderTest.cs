using ImportExcel.Domain.Model;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ImportExcelTest
{
    public class TandemConvencionalLiderTest
    {
        [Fact]
        public void ObterLider_planilha_L152x152_Rev_W_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "Tandem_L152x152_Rev_W.xlsx";
            var fullPath = $"../../../Mock/ModeloTandem/{fileName}";

            Type type = typeof(T_importacao_modelo_tandem_lider);
            var obj = new T_importacao_modelo_tandem_lider();

            //Act
            var lider = svc.ReadFile(type, obj, fullPath) as T_importacao_modelo_tandem_lider;

            //Assert
            Assert.NotNull(lider);
            Assert.True(lider.altura > 97);
            Assert.True(lider.comprimento_inicial == 26.3);
        }
    }
}

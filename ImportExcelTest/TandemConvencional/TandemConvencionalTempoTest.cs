using ImportExcel.Domain.Model;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using System;
using Xunit;

namespace ImportExcelTest
{
    public class TandemConvencionalTempoTest
    {
        [Fact]
        public void ObterLider_planilha_L152x152_Rev_W_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "Tandem_L152x152_Rev_W.xlsx";
            var fullPath = $"../../../Mock/ModeloTandem/{fileName}";

            Type type = typeof(T_importacao_modelo_tandem_tempo);
            var obj = new T_importacao_modelo_tandem_tempo();

            //Act
            var tempo = svc.ReadFile(type, obj, fullPath) as T_importacao_modelo_tandem_tempo;

            //Assert
            Assert.NotNull(tempo);
            Assert.True(tempo.laminacao >= 46.8);
            Assert.True(tempo.morto >= 55);
            Assert.True(tempo.total >= 101.8);
            Assert.True(tempo.produtividade >= 68.2);
        }
    }
}
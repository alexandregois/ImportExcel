using ImportExcel.Domain.Model;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using Xunit;

namespace ImportExcelTest.TandemUniversal
{
    public class TandemUniversalTempoTest
    {

        [Fact]
        public void ObterTandemUniversal_W610x101_List()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W610x101_original.XLS";
            var fullPath = $"../../../Mock/ModeloTandemUniversal/{fileName}";

            //Act
            var tempo = new T_importacao_modelo_tandem_urs_tempo();
            tempo = svc.ReadFile(typeof(T_importacao_modelo_tandem_urs_tempo), tempo, fullPath, -1, true, null, true, 1) as T_importacao_modelo_tandem_urs_tempo;

            //Assert
            Assert.NotNull(tempo);
            Assert.True(tempo.laminacao > 98);
            Assert.True(tempo.morto_teorico > 65);
            Assert.True(tempo.total > 132);
            Assert.True(tempo.produtividade > 217);
        }
    }
}

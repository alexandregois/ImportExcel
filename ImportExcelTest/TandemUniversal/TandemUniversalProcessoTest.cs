using ImportExcel.Domain.Model;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using Xunit;

namespace ImportExcelTest.TandemUniversal
{
    public class TandemUniversalProcessoTest
    {
        [Fact]
        public void ObterTandemUniversal_W610x101_List()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W610x101_original.XLS";
            var fullPath = $"../../../Mock/ModeloTandemUniversal/{fileName}";

            //Act
            var processo = new T_importacao_modelo_tandem_urs_processo();
            processo = svc.ReadFile(typeof(T_importacao_modelo_tandem_urs_processo), processo, fullPath, -1, true, null, true, 1) as T_importacao_modelo_tandem_urs_processo;

            //Assert
            Assert.NotNull(processo);
            Assert.True(processo.diametro_inicial_cilindro_horizontal == 1270);
            Assert.True(processo.diametro_inicial_cilindro_vertical == 915);
            Assert.True(processo.diametro_inicial_colar_cil_edger == 1000);
            Assert.True(processo.profundidade_canal_h_edger > 102);
            Assert.True(processo.largura_mesa_cilindros_horizontais_urii > 579);
            Assert.True(processo.largura_mesa_cilindros_horizontais_uriin == 582);
            Assert.True(processo.numero_passes == 14);
        }
    }
}

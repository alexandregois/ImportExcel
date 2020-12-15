using ImportExcel.Domain.Model;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using Xunit;

namespace ImportExcelTest.TandemUniversal
{
    public class TandemUniversalDimensaoTest
    {
        [Fact]
        public void ObterTandemUniversal_W610x101_List()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W610x101_original.XLS";
            var fullPath = $"../../../Mock/ModeloTandemUniversal/{fileName}";

            //Act
            var tandemUrsDimensao = new T_importacao_modelo_tandem_urs_dimensao();
            tandemUrsDimensao = svc.ReadFile(typeof(T_importacao_modelo_tandem_urs_dimensao), tandemUrsDimensao, fullPath, -1, true, null, true, 1) as T_importacao_modelo_tandem_urs_dimensao;

            //Assert
            Assert.NotNull(tandemUrsDimensao);
            Assert.True(tandemUrsDimensao.profundidade_chamber_nominal > 108.7);
            Assert.True(tandemUrsDimensao.largura_chamber_nominal == 573.2);
            Assert.True(tandemUrsDimensao.espessura_alma_minimo == 9);
            Assert.True(tandemUrsDimensao.espessura_alma_nominal == 10.5);
            Assert.True(tandemUrsDimensao.espessura_alma_maximo == 12);
            Assert.True(tandemUrsDimensao.raio_produto_nominal == 16);
        }
    }
}
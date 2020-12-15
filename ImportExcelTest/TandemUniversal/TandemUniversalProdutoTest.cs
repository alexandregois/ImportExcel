using ImportExcel.Domain.Model;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using Xunit;

namespace ImportExcelTest.TandemUniversal
{
    public class TandemUniversalProdutoTest
    {

        [Fact]
        public void ObterTandemUniversal_W610x101_List()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W610x101_original.XLS";
            var fullPath = $"../../../Mock/ModeloTandemUniversal/{fileName}";

            //Act
            var produto = new T_importacao_modelo_tandem_urs_produto();
            produto = svc.ReadFile(typeof(T_importacao_modelo_tandem_urs_produto), produto, fullPath, -1, true, null, true, 1) as T_importacao_modelo_tandem_urs_produto;

            //Assert
            Assert.NotNull(produto);
            Assert.True(produto.bitola_produto.Equals("W 610 x 101"));
        }
    }
}

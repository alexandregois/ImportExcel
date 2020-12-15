using ImportExcel.Domain.Model;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ImportExcelTest
{
    public class TandemConvencionalProdutoTest
    {
        [Fact]
        public void ObterLider_planilha_L152x152_Rev_W_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "Tandem_L152x152_Rev_W.xlsx";
            var fullPath = $"../../../Mock/ModeloTandem/{fileName}";

            Type type = typeof(T_importacao_modelo_tandem_produto);
            var obj = new T_importacao_modelo_tandem_produto();

            //Act
            var produto = svc.ReadFile(type, obj, fullPath) as T_importacao_modelo_tandem_produto;

            //Assert
            Assert.NotNull(produto);
            Assert.True(produto.bitola_produto.Equals("L152X152X9,5"));
        }
    }
}

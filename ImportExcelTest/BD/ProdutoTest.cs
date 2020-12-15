using ImportExcel.Domain.Model;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ImportExcelTest
{
    public class ProdutoTest
    {
        [Fact]
        public void ObterMateriaPrima_planilha_W150x13_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W150x13.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";
            Type type = typeof(T_importacao_modelo_bd_produto);
            var obj = new T_importacao_modelo_bd_produto();

            //Act
            var produto = svc.ReadFile(type, obj, fullPath) as T_importacao_modelo_bd_produto;

            //Assert
            Assert.NotNull(produto);
            Assert.True(produto.descricao.Equals("W150X13,0"));
            Assert.True(produto.numero_escala == 67);
        }
    }
}

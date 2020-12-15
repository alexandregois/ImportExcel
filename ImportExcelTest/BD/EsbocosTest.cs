using ImportExcel.Domain.Model;
using ImportExcel.Domain.Utils.CustomDataAnnotations;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using System;
using Xunit;

namespace ImportExcelTest
{
    public class EsbocosTest
    {
        [Fact]
        public void ObterEsboco_planilha_W150x13_bd1_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W150x13.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";
            Type type = typeof(T_importacao_modelo_bd_esbocos);
            var obj = new T_importacao_modelo_bd_esbocos();

            //Act
            var esboco = svc.ReadFile(type, obj, fullPath, null, false, new Column(T_importacao_modelo_bd_esbocos.column_bd1)) as T_importacao_modelo_bd_esbocos;

            //Assert
            Assert.NotNull(esboco);
            Assert.True(esboco.esp_alma_tw == 60);
            Assert.True(esboco.altura == 150);
            Assert.True(esboco.largura == 189.2);
            Assert.True(esboco.prof_int == 45);
            Assert.True(esboco.larg_int == 75.6);
            Assert.True(esboco.area == 19505.7);
            Assert.True(esboco.comprimento == 11.2);
            Assert.True(esboco.peso_por_metro == 147.3);
        }

        [Fact]
        public void ObterEsboco_planilha_W150x13_bd2_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W150x13.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";
            Type type = typeof(T_importacao_modelo_bd_esbocos);
            var obj = new T_importacao_modelo_bd_esbocos();

            //Act
            var esboco = svc.ReadFile(type, obj, fullPath, null, false, new Column(T_importacao_modelo_bd_esbocos.column_bd2)) as T_importacao_modelo_bd_esbocos;

            //Assert
            Assert.NotNull(esboco);
            Assert.True(esboco.esp_alma_tw == 25);
            Assert.True(esboco.altura == 105);
        }
    }
}
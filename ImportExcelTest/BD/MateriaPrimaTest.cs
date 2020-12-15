using ImportExcel.Service;
using ImportExcel.Domain.Model;
using System;
using Xunit;
using ImportExcel.Service.Interfaces;

namespace ImportExcelTest
{
    public class MateriaPrimaTest
    {
        [Fact]
        public void Obter_materia_prima_planilha_com_dois_bds_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "Planilha_com_dois_bds.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";
            Type type = typeof(T_importacao_modelo_bd_materia_prima);
            var obj = new T_importacao_modelo_bd_materia_prima();

            //Act
            var matPrima = svc.ReadFile(type, obj, fullPath) as T_importacao_modelo_bd_materia_prima;

            //Assert
            Assert.NotNull(matPrima);
            Assert.True(matPrima.altura == 220);
            Assert.Equal(matPrima.tipo, "BL1");
        }

        [Fact]
        public void Obter_materia_prima_planilha_com_dois_bds_exemplo2_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "Planilha_com_dois_bds_exemplo2.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";
            Type type = typeof(T_importacao_modelo_bd_materia_prima);
            var obj = new T_importacao_modelo_bd_materia_prima();

            //Act
            var matPrima = svc.ReadFile(type, obj, fullPath) as T_importacao_modelo_bd_materia_prima;

            //Assert
            Assert.NotNull(matPrima);
            Assert.True(matPrima.altura == 203);
            Assert.True(matPrima.largura == 243);
        }

        [Fact]
        public void Obter_materia_prima_planilha_U200x20_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "U200x20,5-17,1.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";
            Type type = typeof(T_importacao_modelo_bd_materia_prima);
            var obj = new T_importacao_modelo_bd_materia_prima();

            //Act
            var matPrima = svc.ReadFile(type, obj, fullPath) as T_importacao_modelo_bd_materia_prima;

            //Assert
            Assert.NotNull(matPrima);
            Assert.True(matPrima.comprimento >= 3.56);
            Assert.True(matPrima.peso_por_metro >= 368.3);
        }
        [Fact]
        public void Obter_materia_prima_planilha_UIC865_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "UIC865.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";
            Type type = typeof(T_importacao_modelo_bd_materia_prima);
            var obj = new T_importacao_modelo_bd_materia_prima();

            //Act
            var matPrima = svc.ReadFile(type, obj, fullPath) as T_importacao_modelo_bd_materia_prima;

            //Assert
            Assert.NotNull(matPrima);
            Assert.True(matPrima.largura >= 245);
            Assert.True(matPrima.comprimento >= 7.2);
        }
        [Fact]
        public void Obter_materia_prima_planilha_W150x13_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W150x13.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";
            Type type = typeof(T_importacao_modelo_bd_materia_prima);
            var obj = new T_importacao_modelo_bd_materia_prima();

            //Act
            var matPrima = svc.ReadFile(type, obj, fullPath) as T_importacao_modelo_bd_materia_prima;

            //Assert
            Assert.NotNull(matPrima);
            Assert.True(matPrima.tipo == "BL1");
            Assert.True(matPrima.espessura == 200);
            Assert.True(matPrima.altura == 200);
            Assert.True(matPrima.largura == 240);
            Assert.True(matPrima.comprimento == 4.6);
            Assert.True(matPrima.area == 47463.5);
            Assert.True(matPrima.peso_por_metro == 358.3);
            Assert.True(matPrima.peso == 1626.4);
        }
        [Fact]
        public void Obter_materia_prima_planilha_W610x155_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W610x155.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";
            Type type = typeof(T_importacao_modelo_bd_materia_prima);
            var obj = new T_importacao_modelo_bd_materia_prima();

            //Act
            var matPrima = svc.ReadFile(type, obj, fullPath) as T_importacao_modelo_bd_materia_prima;

            //Assert
            Assert.NotNull(matPrima);
            Assert.True(matPrima.espessura == 120);
            Assert.True(matPrima.comprimento >= 9.7);
        }
    }
}
using ImportExcel.Service;
using ImportExcel.Domain.Model;
using System;
using Xunit;
using ImportExcel.Service.Interfaces;

namespace ImportExcelTest
{
    public class TemposTeoricosTest
    {
        [Fact]
        public void ObterTemposTeoricos_W150x13_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W150x13.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";
            Type type = typeof(T_tempo_teorico);
            var obj = new T_tempo_teorico();

            //Act
            var temposTeoricos = svc.ReadFile(type, obj, fullPath) as T_tempo_teorico;

            //Assert
            Assert.NotNull(temposTeoricos);
            Assert.True(temposTeoricos.laminacao == 35.4);
            Assert.True(temposTeoricos.morto == 93);
            Assert.True(temposTeoricos.total == 128.4);
            Assert.True(temposTeoricos.produtividade == 62.1);
        }

        [Fact]
        public void ObterTemposTeoricos_planilha_com_dois_bds_exemplo2_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "Planilha_com_dois_bds_exemplo2.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";
            Type type = typeof(T_tempo_teorico);
            var obj = new T_tempo_teorico();

            //Act
            var temposTeoricos = svc.ReadFile(type, obj, fullPath) as T_tempo_teorico;

            //Assert
            Assert.NotNull(temposTeoricos);
            Assert.True(temposTeoricos.laminacao >= 32);
        }
    }
}

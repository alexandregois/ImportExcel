using ImportExcel.Domain.Model;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using System;
using Xunit;

namespace ImportExcelTest.TandemUniversal
{
    public class TandemUniversalBeamBlankTest
    {

        [Fact]
        public void ObterLider_planilha_L152x152_Rev_W_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W610x101_original.XLS";
            var fullPath = $"../../../Mock/ModeloTandemUniversal/{fileName}";

            Type type = typeof(T_importacao_modelo_tandem_urs_beam_blank);
            var obj = new T_importacao_modelo_tandem_urs_beam_blank();

            //Act
            var beam_Blank = svc.ReadFile(type, obj, fullPath, null, true, null, true, 1) as T_importacao_modelo_tandem_urs_beam_blank;

            //Assert
            Assert.NotNull(beam_Blank);
            Assert.True(beam_Blank.altura >= 46.8);
            Assert.True(beam_Blank.angulo_inclinacao_interno >= 15);
            Assert.True(beam_Blank.area_secao_transversal == 78642);
            Assert.True(beam_Blank.comprimento_inicial >= 15);
        }
    }
}
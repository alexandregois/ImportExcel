using ImportExcel.Domain.Model;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ImportExcelTest.TandemUniversal
{
    public class TandemUniversalPosicionamentoTeoricoTest
    {
        [Fact]
        public void ObterTandemUniversal_W610x101_List()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W610x101_original.XLS";
            var fullPath = $"../../../Mock/ModeloTandemUniversal/{fileName}";

            //Act
            var posicionamentoTeorico = new T_importacao_modelo_tandem_urs_posicionamento_teorico();
            posicionamentoTeorico = svc.ReadFile(typeof(T_importacao_modelo_tandem_urs_posicionamento_teorico), posicionamentoTeorico, fullPath, -1, true, null, true, 1) as T_importacao_modelo_tandem_urs_posicionamento_teorico;

            //Assert
            Assert.NotNull(posicionamentoTeorico);
            Assert.True(posicionamentoTeorico.posicionamento_inicial_cilindro_inferior_ur2 > 908.8);
            Assert.True(posicionamentoTeorico.posicionamento_inicial_cilindro_inferior_edger > 908.3);
            Assert.True(posicionamentoTeorico.posicionamento_inicial_cilindro_inferior_ur2n > 911);
            Assert.True(posicionamentoTeorico.cpl_ur2 == 115);
            Assert.True(posicionamentoTeorico.cpl_ur2n == 115);
            Assert.True(posicionamentoTeorico.passe_line_teorico == 935);
        }

    }
}

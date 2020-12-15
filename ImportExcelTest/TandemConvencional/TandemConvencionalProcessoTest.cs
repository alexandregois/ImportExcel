using ImportExcel.Domain.Model;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ImportExcelTest
{
    public class TandemConvencionalProcessoTest
    {
        [Fact]
        public void ObterLider_planilha_L152x152_Rev_W_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "Tandem_L152x152_Rev_W.xlsx";
            var fullPath = $"../../../Mock/ModeloTandem/{fileName}";

            Type type = typeof(T_importacao_modelo_tandem_processo);
            var obj = new T_importacao_modelo_tandem_processo();

            //Act
            var processo = svc.ReadFile(type, obj, fullPath) as T_importacao_modelo_tandem_processo;

            //Assert
            Assert.NotNull(processo);
            Assert.True(processo.diametro_inicial_cii == 940);
            Assert.True(processo.diametro_inicial_ciin == 940);
            Assert.True(processo.numero_passes == 6);
            Assert.True(processo.passe_line_teorico == 865);
        }
    }
}

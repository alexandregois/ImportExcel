using ImportExcel.Domain.Model;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using System;
using Xunit;

namespace ImportExcelTest
{
    public class TandemConvencionalDimensaoTest
    {
        [Fact]
        public void ObterDimensao_planilha_L152x152_Rev_W_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "Tandem_L152x152_Rev_W.xlsx";
            var fullPath = $"../../../Mock/ModeloTandem/{fileName}";

            Type type = typeof(T_importacao_modelo_tandem_dimensao);
            var obj = new T_importacao_modelo_tandem_dimensao();

            //Act
            var dimensao = svc.ReadFile(type, obj, fullPath) as T_importacao_modelo_tandem_dimensao;

            //Assert
            Assert.NotNull(dimensao);
            Assert.True(dimensao.espessura_aba_minimo == null);
            Assert.True(dimensao.largura_aba_minimo >= 149.2);
            Assert.True(dimensao.altura_perfil_nominal >= 215.5);
        }
    }
}

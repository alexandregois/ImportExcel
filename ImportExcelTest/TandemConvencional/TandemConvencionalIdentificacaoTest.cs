using ImportExcel.Domain.Model;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ImportExcelTest
{
    public class TandemConvencionalIdentificacaoTest
    {
        [Fact]
        public void ObterIdentificacao_planilha_L152x152_Rev_W_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "Tandem_L152x152_Rev_W.xlsx";
            var fullPath = $"../../../Mock/ModeloTandem/{fileName}";

            Type type = typeof(T_importacao_modelo_tandem_identificacao);
            var obj = new T_importacao_modelo_tandem_identificacao();

            //Act
            var identificacao = svc.ReadFile(type, obj, fullPath) as T_importacao_modelo_tandem_identificacao;

            //Assert
            Assert.NotNull(identificacao);
            Assert.True(identificacao.observacao.Contains("Acerto das larguras na escala de passes"));
            Assert.True(identificacao.desenho_usinagem_1.Equals("GOB-1C05E.05-Z-8056"));
            Assert.True(identificacao.data_ultima_atualizacao_planilha.ToString().Equals("21/05/2019 00:00:00"));
        }
    }
}

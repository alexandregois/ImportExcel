using ImportExcel.Domain.Model;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using Xunit;

namespace ImportExcelTest.TandemUniversal
{
    public class TandemUniversalIdentificacaoTest
    {
        [Fact]
        public void ObterTandemUniversal_W610x101_List()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W610x101_original.XLS";
            var fullPath = $"../../../Mock/ModeloTandemUniversal/{fileName}";

            //Act
            var identificacao = new T_importacao_modelo_tandem_urs_identificacao();
            identificacao = svc.ReadFile(typeof(T_importacao_modelo_tandem_urs_identificacao), identificacao, fullPath, -1, true, null, true, 1) as T_importacao_modelo_tandem_urs_identificacao;

            //Assert
            Assert.NotNull(identificacao);
            Assert.True(identificacao.codigo == "TD - 24");
            Assert.True(identificacao.revisao == "AM");
            Assert.True(identificacao.desenho_usinagem_1 == "1C05-000-P-0067");
            Assert.True(identificacao.data_emissao.ToString().Equals("12/08/2008 00:00:00"));
            Assert.True(identificacao.data_ultima_atualizacao_planilha.ToString().Equals("08/06/2017 00:00:00"));
            Assert.True(identificacao.responsavel_emitente == "Hegler Assunção - 36467");
            Assert.True(string.IsNullOrWhiteSpace(identificacao.responsavel_aprovador));
        }
    }
}

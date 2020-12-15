using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Model;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ImportExcelTest
{
    public class IdentificacaoTest : IImportSingleData
    {
        [Fact]
        public void ObterMateriaPrima_planilha_W150x13_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W150x13.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";
            Type type = typeof(T_importacao_modelo_bd_identificacao);
            var obj = new T_importacao_modelo_bd_identificacao();

            //Act
            var identificacao = svc.ReadFile(type, obj, fullPath) as T_importacao_modelo_bd_identificacao;

            //Assert
            Assert.NotNull(identificacao);
            Assert.True(identificacao.codigo.Equals("BD-67"));
            Assert.True(identificacao.revisao.Equals("S"));
            Assert.True(identificacao.desenhos_usinagem_bd1.Equals("320/321"));
            Assert.True(identificacao.desenhos_usinagem_bd2.Equals("206/255 E 251/263"));
            Assert.True(identificacao.data_emissao.ToString().Equals("08/10/2007 00:00:00"));
            Assert.True(identificacao.data_atualizacao.ToString().Equals("29/11/2018 00:00:00"));
            Assert.True(identificacao.responsavel_emitente.Equals("Luciano Toledo Ribeiro"));
            Assert.True(identificacao.responsavel_aprovador.Equals("Delvaux Carlos de M. Sobrinho"));

        }
    }
}

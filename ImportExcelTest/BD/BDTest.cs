using ImportExcel.Domain.Model.Enuns;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace ImportExcelTest
{
    public class BDTest
    {               
        [Fact]
        public void ObterBDList_planilha_com_dois_bds_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "Planilha_com_dois_bds.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";

            //Act
            var bds = svc.ReadFile_BD(fullPath);

            //Assert
            Assert.NotNull(bds);
            Assert.True(bds.Count == 7);
            //Assert.True(bds.GroupBy(g => g.index_bd).Count() == 2);
            Assert.Equal(bds[0].canal_posicao_stripper, "6/BOX1");
        }
        [Fact]
        public void ObterBDList_planilha_com_tres_bds_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "Planilha_com_tres_bds.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";

            //Act
            var bds = svc.ReadFile_BD(fullPath);

            //Assert
            Assert.NotNull(bds);
            Assert.True(bds.Count == 14);
        }
        [Fact]
        public void ObterBDList_planilha_U200x20_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "U200x20,5-17,1.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";

            //Act
            var bds = svc.ReadFile_BD(fullPath);

            //Assert
            Assert.NotNull(bds);
            Assert.True(bds.Count == 8);
        }
        //[Fact]
        //public void ObterBDList_planilha_U200x20_com_mais_de_13_linhas_Test()
        //{
        //    //Arrange
        //    IReadExcelService svc = new ReadExcelService();
        //    var fileName = "W150x13-_com_mais_de_treze_linhas.xlsx";
        //    var fullPath = $"../../../Mock/ModeloBd/{fileName}";

        //    //Act
        //    var bds = svc.ReadFile_BD(fullPath);

        //    //Assert
        //    Assert.NotNull(bds);
        //    Assert.True(bds[5].canal_posicao_stripper_entrada == "teste");
        //    Assert.True(bds.Count == 9);
        //}
        [Fact]
        public void ObterBDList_planilha_UIC865_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "UIC865.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";

            //Act
            var bds = svc.ReadFile_BD(fullPath);

            //Assert
            Assert.NotNull(bds);
            Assert.True(bds.Count == 7);
        }
        [Fact]
        public void ObterBDList_planilha_W150x13_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W150x13.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";

            //Act
            var bds = svc.ReadFile_BD(fullPath);

            //Assert
            Assert.NotNull(bds);
            Assert.True(bds[0].numero_passe == 1);
            Assert.True(bds.Count == 8);
        }
        [Fact]
        public void ObterBDList_planilha_W610x155_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W610x155.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";

            //Act
            var bds = svc.ReadFile_BD(fullPath);

            //Assert
            Assert.NotNull(bds);
            Assert.True(bds.Count == 8);
        }

        [Fact]
        public void Error_GetCellValue_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W610x155.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";

            NPOI.SS.UserModel.ISheet passesDesbastadoresSheet = null;

            System.IO.FileStream stream = File.OpenRead(fullPath);
          
                var xssfWorkbook = new NPOI.XSSF.UserModel.XSSFWorkbook(stream);
                passesDesbastadoresSheet = xssfWorkbook.GetSheetAt(0);
          
            //Act            
            var cr = new NPOI.SS.Util.CellReference("L20");
            var row = passesDesbastadoresSheet.GetRow(cr.Row);
            var cell = row.GetCell(cr.Col);
            Assert.True(cell.NumericCellValue == 80);

            cr = new NPOI.SS.Util.CellReference("O20");
            row = passesDesbastadoresSheet.GetRow(cr.Row);
            cell = row.GetCell(cr.Col);
            Assert.True(cell.NumericCellValue > 397);

            cr = new NPOI.SS.Util.CellReference("P20");
            row = passesDesbastadoresSheet.GetRow(cr.Row);
            cell = row.GetCell(cr.Col);
            Assert.True(cell.NumericCellValue > 117858);

            cr = new NPOI.SS.Util.CellReference("R20");
            row = passesDesbastadoresSheet.GetRow(cr.Row);
            cell = row.GetCell(cr.Col);
            Assert.True(cell.NumericCellValue == 0);

            cr = new NPOI.SS.Util.CellReference("S20");
            row = passesDesbastadoresSheet.GetRow(cr.Row);
            cell = row.GetCell(cr.Col);
            Assert.True(cell.NumericCellValue == 1);

            cr = new NPOI.SS.Util.CellReference("T20");
            row = passesDesbastadoresSheet.GetRow(cr.Row);
            cell = row.GetCell(cr.Col);
            Assert.True(cell.NumericCellValue > 9.7);
        }


        [Fact]
        public void Erro_em_arredondamento_area_along_W150x13_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W150x13.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";

            //Act
            var bds = svc.ReadFile_BD(fullPath);

            //Assert
            Assert.NotNull(bds);
            Assert.True(bds.Count == 8);
            Assert.True(bds[0].area_along == 1.320);
            Assert.True(bds[1].area_along == 1.230);
            Assert.True(bds[2].area_along == 1.052);
            Assert.True(bds[3].area_along == 1.194);
            Assert.True(bds[4].area_along == 1.194);
        }

        [Fact]
        public void Inversao_valores_forca_x_torque_W150x13_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W150x13.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";

            //Act
            var bds = svc.ReadFile_BD(fullPath);

            //Assert
            Assert.NotNull(bds);
            Assert.True(bds.Count == 8);
            
            Assert.True(bds[0].forca == 2351.8);
            Assert.True(bds[0].torque == 382.4);

            Assert.True(bds[1].forca == 1789.8);
            Assert.True(bds[1].torque == 245.2);

            Assert.True(bds[2].forca == 2238.2);
            Assert.True(bds[2].torque == 386.2);
        }


        [Fact]
        public void Validacao_valores_todas_as_colunas_W150x13_Test()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W150x13.xlsx";
            var fullPath = $"../../../Mock/ModeloBd/{fileName}";

            //Act
            var bds = svc.ReadFile_BD(fullPath);

            //Assert
            Assert.NotNull(bds);
            Assert.True(bds.Count == 8);

            Assert.True(bds[3].canal_posicao_stripper_entrada == "q");
            Assert.True(bds[3].canal_posicao_stripper == "4/E");
            Assert.True(string.IsNullOrWhiteSpace(bds[3].canal_posicao_stripper_saida));
            Assert.True(bds[3].giro == "N");
            Assert.True(bds[3].tipo == "H");
            Assert.True(bds[3].alma_espes == 80);
            Assert.True(bds[3].alma_dh == 25);
            Assert.True(bds[3].luz == 18);
            Assert.True(bds[3].pass_line == 85);
            Assert.True(bds[3].perfil_largura == 185);
            Assert.True(bds[3].perfil_altura == 169);
            Assert.True(bds[3].area_mm2 == 23282);
            Assert.True(bds[3].area_red == 16.2);
            Assert.True(bds[3].area_along == 1.194);
            Assert.True(bds[3].comp == 9.4);
            Assert.True(bds[3].dia_trab == 956);
            Assert.True(bds[3].velocidade_entrada == 1);
            Assert.True(bds[3].velocidade_laminacao == 4.4);
            Assert.True(bds[3].tempo_laminacao == 3.8);
            Assert.True(bds[3].tempo_morto == 4.0);
            Assert.True(bds[3].forca == 1372.1);
            Assert.True(bds[3].torque == 136.5);
        }
    }
}

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using Xunit;

namespace ImportExcelTest
{
    public class FormulaEvaluatorTest
    {
        [Fact]
        public void TryGetValueFromFormula_EvaluateInCell_Test()
        {
            ISheet sheet = null;

            var fileName = "W610x101_original.xls";
            var fullPath = $"../../../Mock/ModeloTandemUniversal/{fileName}";

            FileStream stream = File.OpenRead(fullPath);
            var hssfWorkbook = new HSSFWorkbook(stream);
            sheet = hssfWorkbook.GetSheetAt(1);

            var cell = sheet.GetRow(34).GetCell(3);

            HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(hssfWorkbook);
            
            e.EvaluateInCell(cell);
            var value = cell.NumericCellValue;

            Assert.True(value.ToString() != "D8");
            Assert.True(value == 54);
        }

        [Fact]
        public void TryGetValueFromFormula_EvaluateAll_Test()
        {
            ISheet sheet = null;

            var fileName = "W610x101_original.xls";
            var fullPath = $"../../../Mock/ModeloTandemUniversal/{fileName}";

            FileStream stream = File.OpenRead(fullPath);
            var hssfWorkbook = new HSSFWorkbook(stream);
            sheet = hssfWorkbook.GetSheetAt(1);

            var cell = sheet.GetRow(34).GetCell(3);

            HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(hssfWorkbook);

            e.EvaluateAll();
            var value = cell.NumericCellValue;

            Assert.True(value.ToString() != "D8");
            Assert.True(value == 54);
        }
        [Fact]
        public void TryGetValueFromFormula_EvaluateAll_GetBeamBlank_Test()
        {
            ISheet sheet = null;

            var fileName = "W610x101_original.xls";
            var fullPath = $"../../../Mock/ModeloTandemUniversal/{fileName}";

            FileStream stream = File.OpenRead(fullPath);
            var hssfWorkbook = new HSSFWorkbook(stream);
            sheet = hssfWorkbook.GetSheetAt(1);
            
            //var cell = sheet.GetRow(19).GetCell(3);

            HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(hssfWorkbook);

            e.EvaluateAll();
            var cell = sheet.GetRow(19).GetCell(3);
            var value = cell.NumericCellValue;

            Assert.True(value.ToString() != @"'BD2'!X13");
            Assert.True(value == 107.5);
        }
    }
}
using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Model;
using ImportExcel.Domain.Utils.CustomDataAnnotations;
using ImportExcel.Service.Interfaces;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ImportExcel.Service
{
    public class ReadExcelService : IReadExcelService
    {
        private LogService log = null;

        public ReadExcelService()
        {
            this.log = new LogService();
        }

        public IList<T_importacao_modelo_bd> ReadFile_BD(string filePath, int idImport = -1)
        {
            var sheet = GetSheet(filePath);

            var props = typeof(T_importacao_modelo_bd).GetProperties();
            var list = new List<T_importacao_modelo_bd>();
            string indexValue, indexValueOld = string.Empty;
            bool _continue = true;

            try
            {
                for (int row = T_importacao_modelo_bd.FirstRow; _continue; row++)
                {
                    var obj = new T_importacao_modelo_bd() { id_t_importacao = idImport };

                    foreach (var p in props)
                    {
                        var column = ((Column)p.GetCustomAttribute(typeof(Column)));
                        if (column == null) continue;

                        var round = ((Round)p.GetCustomAttribute(typeof(Round)));

                        if (p.PropertyType == typeof(Nullable<Double>) || p.PropertyType == typeof(Double))
                            p.SetValue(obj, GetNumericCellValue(sheet, row, column.Value, idImport, round?.Value));

                        else if (p.PropertyType == typeof(Nullable<int>) || p.PropertyType == typeof(int))
                            p.SetValue(obj, GetIntegerCellValue(sheet, row, column.Value, idImport));

                        else if (p.PropertyType == typeof(string))
                        {
                            indexValue = GetStringCellValue(sheet, sheet, row, column.Value);////****

                            if (p.Name.Equals("tipo_bd_value"))
                            {
                                if (string.IsNullOrWhiteSpace(indexValue))
                                {
                                    int result = (row - T_importacao_modelo_bd.FirstRow + 1) % T_importacao_modelo_bd.CountRowsBlock;

                                    if (result == 0)
                                    {
                                        var next_index_bd = sheet.GetRow(row + 1).GetCell(column.Value);

                                        if (next_index_bd == null || string.IsNullOrWhiteSpace(next_index_bd.ToString().Trim()))
                                        { _continue = false; continue; }
                                    }

                                    indexValue = indexValueOld;
                                }
                                indexValueOld = indexValue;
                            }

                            p.SetValue(obj, indexValue);
                        }
                        else
                        {
                            string message = $"Get cell value não implementado para {p.PropertyType} da propriedade {p.Name} da classe T_importacao_modelo_bd";
                            throw new NotImplementedException(message);
                        }

                    }
                    ImportMultipleData<T_importacao_modelo_bd>.AddIfIsNotEmpty(list, obj);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            return list;
        }

        public IList<T_importacao_modelo_tandem> ReadFile_Tandem(string filePath, int idImport = -1)
        {
            var sheet = GetSheet(filePath);

            var props = typeof(T_importacao_modelo_tandem).GetProperties();
            var list = new List<T_importacao_modelo_tandem>();

            try
            {
                for (int row = T_importacao_modelo_tandem.FirstRow;
                row <= T_importacao_modelo_tandem.FirstRow + T_importacao_modelo_tandem.CountRowsBlock; row++)
                {
                    var obj = new T_importacao_modelo_tandem() { id_t_importacao = idImport };

                    foreach (var p in props)
                    {
                        var column = ((Column)p.GetCustomAttribute(typeof(Column)));
                        if (column == null) continue;

                        if (p.PropertyType == typeof(Nullable<Double>) || p.PropertyType == typeof(Double))
                            p.SetValue(obj, GetNumericCellValue(sheet, row, column.Value, idImport));

                        else if (p.PropertyType == typeof(Nullable<int>) || p.PropertyType == typeof(int))
                            p.SetValue(obj, GetIntegerCellValue(sheet, row, column.Value, idImport));

                        else if (p.PropertyType == typeof(string))
                            p.SetValue(obj, GetStringCellValue(sheet, sheet, row, column.Value));

                        else
                        {
                            string message = $"Get cell value não implementado para {p.PropertyType} da propriedade {p.Name} da classe T_importacao_modelo_tandem";
                            throw new NotImplementedException(message);
                        }

                    }
                    ImportMultipleData<T_importacao_modelo_tandem>.AddIfIsNotEmpty(list, obj);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            return list;
        }

        public IList<T_importacao_modelo_tandem_urs> ReadFile_TandemUniversal(string filePath, int idImport = -1)
        {
            var sheet = GetSheet(filePath, true, 1);

            var sheet0 = GetSheet(filePath, true, 1);

            var props = typeof(T_importacao_modelo_tandem_urs).GetProperties();
            var list = new List<T_importacao_modelo_tandem_urs>();

            try
            {

                for (int row = T_importacao_modelo_tandem_urs.FirstRow;
                row <= T_importacao_modelo_tandem_urs.FirstRow + T_importacao_modelo_tandem_urs.CountRowsBlock; row++)
                {
                    var obj = new T_importacao_modelo_tandem_urs() { id_t_importacao = idImport };

                    foreach (var p in props)
                    {
                        var column = ((Column)p.GetCustomAttribute(typeof(Column)));
                        if (column == null) continue;

                        if (p.PropertyType == typeof(Nullable<Double>) || p.PropertyType == typeof(Double))
                            p.SetValue(obj, GetNumericCellValue(sheet, row, column.Value, idImport));

                        else if (p.PropertyType == typeof(Nullable<int>) || p.PropertyType == typeof(int))
                            p.SetValue(obj, GetIntegerCellValue(sheet, row, column.Value, idImport));

                        else if (p.PropertyType == typeof(string))
                            p.SetValue(obj, GetStringCellValue(sheet0, sheet, row, column.Value));

                        else
                        {
                            string message = $"Get cell value não implementado para {p.PropertyType} da propriedade {p.Name} da classe T_importacao_modelo_tandem_urs";
                            throw new NotImplementedException(message);
                        }

                    }

                    ImportMultipleData<T_importacao_modelo_tandem_urs>.AddIfIsNotEmpty(list, obj);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            return list;
        }

        public IImportSingleData ReadFile(Type t, IImportSingleData obj, string filePath, int? id_t_importacao = null, bool getColumnFromProperty = true,
            Column column = null, bool evaluate = false, int sheetIndex = 0)
        {
            var sheet = GetSheet(filePath, evaluate, sheetIndex);

            var sheet0 = GetSheet(filePath, evaluate, 0);

            var props = t.GetProperties();
            var idImport = id_t_importacao.HasValue ? (int)id_t_importacao : 0;

            try
            {
                foreach (var p in props)
                {
                    var row = ((Row)p.GetCustomAttribute(typeof(Row)));

                    if (getColumnFromProperty) column = ((Column)p.GetCustomAttribute(typeof(Column)));

                    if (row == null || column == null) continue;

                    var round = ((Round)p.GetCustomAttribute(typeof(Round)));

                    if (p.PropertyType == typeof(Nullable<Double>) || p.PropertyType == typeof(Double))
                        p.SetValue(obj, GetNumericCellValue(sheet, row.Value, column.Value, idImport, round?.Value));

                    else if (p.PropertyType == typeof(Nullable<int>) || p.PropertyType == typeof(int))
                        p.SetValue(obj, GetIntegerCellValue(sheet, row.Value, column.Value, idImport));

                    else if (p.PropertyType == typeof(Nullable<DateTime>) || p.PropertyType == typeof(DateTime))
                        p.SetValue(obj, GetDateTimeCellValue(sheet, row.Value, column.Value));

                    else if (p.PropertyType == typeof(string))
                        p.SetValue(obj, GetStringCellValue(sheet0, sheet, row.Value, column.Value));

                    else
                    {
                        string message = $"Get cell value não implementado para {p.PropertyType} da propriedade {p.Name} da classe {t.Name}";
                        throw new NotImplementedException(message);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }


            return obj;
        }

        private ISheet GetSheet(string filePath, bool evaluate = false, int sheetIndex = 0)
        {
            ISheet sheet = null;
            try
            {
                FileStream stream = File.OpenRead(filePath);
                var fileExt = Path.GetExtension(filePath.ToLower());
                if (fileExt == ".xls")
                {
                    var hssfWorkbook = new HSSFWorkbook(stream);
                    sheet = hssfWorkbook.GetSheetAt(sheetIndex);

                    if (evaluate)
                    {
                        HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(hssfWorkbook);
                        e.EvaluateAll();
                    }
                }
                else
                {
                    var xssfWorkbook = new XSSFWorkbook(stream);
                    sheet = xssfWorkbook.GetSheetAt(sheetIndex);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception($"Não foi possível abrir a pasta de trabalho da planilha {filePath}");
            }
            return sheet;
        }

        public Nullable<double> GetNumericCellValue(ISheet sheet, int row, int column, int id_t_importacao, int? round = null)
        {
            try
            {

                var value = sheet.GetRow(row).GetCell(column);

                if (value == null || string.IsNullOrWhiteSpace(value.ToString())) return null;


                switch (value.CellType)
                {
                    case CellType.Numeric:
                        if (!double.TryParse(value.ToString(), out double result))
                        {
                            log.LogCampoNumericoComValorTexto(row, column, value.ToString(), id_t_importacao);
                            return null;
                        }
                        else
                            return round == null ? value.NumericCellValue : Math.Round(value.NumericCellValue, (int)round);
                    case CellType.Unknown:
                    case CellType.String:
                    case CellType.Blank:
                    case CellType.Boolean:
                    case CellType.Error:
                        try
                        {
                            if (value.ToString().Any(c => !Char.IsDigit(c)))
                            {
                                log.LogCampoNumericoComValorTexto(row, column, value.ToString(), id_t_importacao);
                                return null;
                            }
                            else
                                return round == null ? value.NumericCellValue : Math.Round(value.NumericCellValue, (int)round);
                        }
                        catch (Exception ex)
                        {

                            if (value.ToString().IndexOf("=") == -1)
                                log.LogCelulaComFormula(row, column, ex.Message, id_t_importacao);

                            return null;

                        }
                    case CellType.Formula:
                        try
                        {
                            return round == null ? value.NumericCellValue : Math.Round(value.NumericCellValue, (int)round);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);

                            if (value.ToString().IndexOf("=") == -1)
                                log.LogCelulaComFormula(row, column, ex.Message, id_t_importacao);

                            return null;
                        }
                    default:
                        return round == null ? value.NumericCellValue : Math.Round(value.NumericCellValue, (int)round);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

        }

        public Nullable<int> GetIntegerCellValue(ISheet sheet, int row, int column, int id_t_importacao)
        {

            try
            {

                var value = sheet.GetRow(row).GetCell(column);

                if (value == null || string.IsNullOrWhiteSpace(value.ToString())) return null;

                else if (value.CellType == CellType.Numeric && value.ToString().Any(c => !Char.IsDigit(c)))
                {
                    log.LogCampoNumericoComValorTexto(row, column, value.ToString(), id_t_importacao);
                    return null;
                }
                else if (value.CellType == CellType.Numeric && !int.TryParse(value.NumericCellValue.ToString(), out int result))
                {
                    log.LogCampoNumericoComValorTexto(row, column, value.ToString(), id_t_importacao);
                    return null;
                }
                else
                {
                    int.TryParse(value.ToString(), out int result_value);
                    return result_value;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public Nullable<DateTime> GetDateTimeCellValue(ISheet sheet, int row, int column)
        {
            var value = sheet.GetRow(row).GetCell(column);
            if (value == null || (value.CellType == CellType.String && string.IsNullOrWhiteSpace(value.ToString().Trim())))
                return null;

            else
                return value.DateCellValue;
        }

        public string GetStringCellValue(ISheet sheet0, ISheet sheet, int row, int column)
        {

            String resultado = null;

            try
            {
                var value = sheet.GetRow(row).GetCell(column);
                var value0 = sheet0.GetRow(1).GetCell(19);

                if (value.ToString().IndexOf("'BD2'!T2") > -1)
                {
                    if (value0 == null || string.IsNullOrWhiteSpace(value0.ToString().Trim()))
                        resultado = null;
                    else
                        resultado = value0.ToString();
                }
                else
                {
                    if (value == null || string.IsNullOrWhiteSpace(value.ToString().Trim()))
                        resultado = null;
                    //else if (value.ToString().All(c => Char.IsDigit(c))) return value.ToString();
                    else
                        return value.ToString();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }


            return resultado;

        }
    }
}
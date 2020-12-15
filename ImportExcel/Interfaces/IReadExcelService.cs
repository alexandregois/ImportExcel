using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Model;
using ImportExcel.Domain.Utils.CustomDataAnnotations;
using System;
using System.Collections.Generic;

namespace ImportExcel.Service.Interfaces
{
    public interface IReadExcelService
    {
        IList<T_importacao_modelo_bd> ReadFile_BD(string filePath, int idImport = -1);
        IList<T_importacao_modelo_tandem> ReadFile_Tandem(string filePath, int idImport = -1);
        IList<T_importacao_modelo_tandem_urs> ReadFile_TandemUniversal(string filePath, int idImport = -1);
        IImportSingleData ReadFile(Type t, IImportSingleData obj, string filePath, int? id_t_importacao = null, bool getColumnFromProperty = true, 
            Column column = null, bool evaluate = false, int sheetIndex = 0);
    }
}

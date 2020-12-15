using System;
using System.Collections.Generic;
using System.Text;

namespace ImportExcel.Domain.Model.Log.Enuns
{
    public enum TipoErro
    {
        desconhecido = 1,
        formato_de_arquivo_invalido = 2,
        campo_numerico_com_valor_de_texto = 3,
        identificado_formula_na_celula = 4,
        layout_nao_identificado = 5,
        arquivo_ja_importado = 6
    }
}

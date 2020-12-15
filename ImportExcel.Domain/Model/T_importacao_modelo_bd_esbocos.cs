using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;
using System;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_bd_esbocos : ImportData, IImportSingleData
    {
        public const int column_bd1 = 13;
        public const int column_bd2 = 18;

        public T_importacao_modelo_bd_esbocos()
        {
            id_t_importacao_modelo_bd_esbocos = null;
            id_t_importacao = null;
            esp_alma_tw = null;
            comprimento = null;
            altura = null;
            largura = null;
            prof_int = null;
            larg_int = null;
            area = null;
            peso_por_metro = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
            tipo_bd = null;
        }

        public int? id_t_importacao_modelo_bd_esbocos { get; set; }
        public int? id_t_importacao { get; set; }

        [Row(5), Round(1)]
        public double? esp_alma_tw { get; set; }


        [Row(6), Round(1)]
        public double? altura { get; set; }

        [Row(7), Round(1)]
        public double? largura { get; set; }

        [Row(8), Round(1)]
        public double? prof_int { get; set; }

        [Row(9), Round(1)]
        public double? larg_int { get; set; }

        [Row(10), Round(1)]
        public double? area { get; set; }

        [Row(11), Round(1)]
        public double? comprimento { get; set; }

        [Row(12), Round(1)]
        public double? peso_por_metro { get; set; }

        public int? tipo_bd { get; set; }
    }
}
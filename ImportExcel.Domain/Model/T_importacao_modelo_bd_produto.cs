using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;
using System;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_bd_produto : ImportData, IImportSingleData
    {
        public T_importacao_modelo_bd_produto()
        {
            id_t_importacao_modelo_bd_produto = null;
            id_t_importacao = null;
            descricao = null;
            numero_escala = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }

        public int? id_t_importacao_modelo_bd_produto { get; set; }
        public int? id_t_importacao { get; set; }

        [Column(25), Row(10)]
        public string descricao { get; set; }

        [Column(27), Row(11)]
        public int? numero_escala { get; set; }
    }
}
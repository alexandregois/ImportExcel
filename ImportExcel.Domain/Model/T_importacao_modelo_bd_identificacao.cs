using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;
using System;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_bd_identificacao : ImportData, IImportSingleData
    {
        public T_importacao_modelo_bd_identificacao()
        {
            id_t_importacao_modelo_bd_identificacao = null;
            id_t_importacao = null;
            codigo = null;
            revisao = null;
            desenhos_usinagem_bd1 = null;
            desenhos_usinagem_bd2 = null;
            data_emissao = null;
            data_atualizacao = null;
            responsavel_emitente = null;
            responsavel_aprovador = null;
            observacao = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }

        public int? id_t_importacao_modelo_bd_identificacao { get; set; }
        public int? id_t_importacao { get; set; }
        
        [Column(2), Row(52)]
        public string codigo { get; set; }
        
        [Column(5), Row(52)]
        public string revisao { get; set; }

        [Column(8), Row(51)] 
        public string desenhos_usinagem_bd1 { get; set; }

        [Column(8), Row(52)]
        public string desenhos_usinagem_bd2 { get; set; }

        [Column(12), Row(52)]
        public DateTime? data_emissao { get; set; }

        [Column(14), Row(52)] 
        public DateTime? data_atualizacao { get; set; }

        [Column(21), Row(51)]
        public string responsavel_emitente { get; set; }

        [Column(21), Row(52)]
        public string responsavel_aprovador { get; set; }

        [Column(5), Row(46)]
        public string observacao { get; set; }
    }
}
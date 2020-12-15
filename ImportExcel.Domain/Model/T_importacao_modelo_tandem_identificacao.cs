using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;
using System;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_tandem_identificacao : ImportData, IImportSingleData
    {
        public T_importacao_modelo_tandem_identificacao()
        {

            id_t_importacao_modelo_tandem_identificacao = null;
            id_t_importacao = null;
            codigo = null;
            revisao = null;
            desenho_usinagem_1 = null;
            desenho_usinagem_2 = null;
            data_emissao = null;
            data_ultima_atualizacao_planilha = null;
            responsavel_emitente = null;
            responsavel_aprovador = null;
            observacao = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }

        public int? id_t_importacao_modelo_tandem_identificacao { get; set; }
        public int? id_t_importacao { get; set; }
        [Column(2), Row(40)] public string codigo { get; set; }
        [Column(5), Row(40)] public string revisao { get; set; }
        [Column(7), Row(40)] public string desenho_usinagem_1 { get; set; }
        [Column(7), Row(41)] public string desenho_usinagem_2 { get; set; }
        [Column(12), Row(40)] public DateTime? data_emissao { get; set; }
        [Column(16), Row(40)] public DateTime? data_ultima_atualizacao_planilha { get; set; }
        [Column(20), Row(40)] public string responsavel_emitente { get; set; }
        [Column(26), Row(40)] public string responsavel_aprovador { get; set; }
        [Column(3), Row(37)] public string observacao { get; set; }
    }
}
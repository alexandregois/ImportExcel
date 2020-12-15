using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;
using Newtonsoft.Json;
using System;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_tandem_urs_identificacao : ImportData, IImportSingleData
    {
        public const int row = 57;
        public T_importacao_modelo_tandem_urs_identificacao()
        {
            id_t_importacao_modelo_tandem_urs_identificacao = null;
            id_t_importacao = null;
            revisao = null;
            desenho_usinagem_1 = null;
            data_emissao = null;
            data_ultima_atualizacao_planilha = null;
            responsavel_emitente = null;
            responsavel_aprovador = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }

        public int? id_t_importacao_modelo_tandem_urs_identificacao { get;  set; }
        public int? id_t_importacao { get; set; }
        [Row(row), Column(3), JsonIgnore] public string codigo_modelo_planilha { get; set; }
        [Row(row), Column(4), JsonIgnore] public string codigo_index { get; set; }
        public string codigo { get { return string.Concat(codigo_modelo_planilha, codigo_index); } }
        [Row(row),Column(7)] public string revisao { get; set; }
        [Row(row),Column(10)] public string desenho_usinagem_1 { get ;  set; }
        [Row(row),Column(15)] public DateTime? data_emissao { get; set; }
        [Row(row),Column(20)] public DateTime? data_ultima_atualizacao_planilha { get; set; }
        [Row(row),Column(24)] public string responsavel_emitente { get; set; }
        [Row(row), Column(30)] public string responsavel_aprovador{    get; set;}
    }
}
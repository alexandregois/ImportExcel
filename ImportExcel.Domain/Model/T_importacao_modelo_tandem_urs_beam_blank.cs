using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;
using System;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_tandem_urs_beam_blank : ImportData, IImportSingleData
    {
        public const int column = 3;
        public T_importacao_modelo_tandem_urs_beam_blank()
        {
            id_t_importacao_modelo_tandem_urs_beam_blank = null;
            id_t_importacao = null;
            profundidade_chamber = null;
            largura_chamber = null;
            espessura_alma = null;
            espessura_aba = null;
            altura = null;
            raio = null;
            angulo_inclinacao_externo = null;
            angulo_inclinacao_interno = null;
            comprimento_inicial = null;
            area_secao_transversal = null;
            peso_incial_bloco = null;
            peso_final_bloco = null;
            peso_metro_beam_blank = null;
            espessura_aba_e2 = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }
        public int? id_t_importacao_modelo_tandem_urs_beam_blank { get; set; }
        public int? id_t_importacao { get; set; }
        [Column(column), Row(5)] public double? profundidade_chamber { get; set; }
        [Column(column), Row(6)] public double? largura_chamber { get; set; }
        [Column(column), Row(7)] public double? espessura_alma { get; set; }
        [Column(column), Row(8)] public double? espessura_aba { get; set; }
        [Column(column), Row(9)] public double? largura_flange { get; set; }
        [Column(column), Row(10)] public double? altura { get; set; }
        [Column(column), Row(11)] public double? raio { get; set; }
        [Column(column), Row(12)] public double? angulo_inclinacao_externo { get; set; }
        [Column(column), Row(13)] public double? angulo_inclinacao_interno { get; set; }
        [Column(column), Row(14)] public double? comprimento_inicial { get; set; }
        [Column(column), Row(15)] public double? area_secao_transversal { get; set; }
        [Column(column), Row(16)] public double? peso_incial_bloco { get; set; }
        [Column(column), Row(17)] public double? peso_final_bloco { get; set; }
        [Column(column), Row(18)] public double? peso_metro_beam_blank { get; set; }
        [Column(column), Row(19)] public double? espessura_aba_e2 { get; set; }
    }
}
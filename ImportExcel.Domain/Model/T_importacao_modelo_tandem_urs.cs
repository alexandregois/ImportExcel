using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_tandem_urs : ImportData, IImportMultipleData
    {
        public const int FirstRow = 34;

        public const int CountRowsBlock = 22;
        public T_importacao_modelo_tandem_urs()
        {
            id_t_importacao_modelo_tandem_urs = null;
            id_t_importacao = null;
            passe = null;
            cadeira = null;
            alma_espessura = null;
            alma_espessura_ideal = null;
            alma_along = null;
            alma_reducao = null;
            alma_forca = null;
            flange_espessura = null;
            flange_espessura_ideal = null;
            flange_along = null;
            flange_reducao = null;
            flange_forca = null;
            perfil_altura = null;
            perfil_largura = null;
            area_mm2 = null;
            area_reducao = null;
            area_along = null;
            comprimento = null;
            diametro_trabalho = null;
            velocidade_entrada = null;
            velocidade_laminacao = null;
            rotacoes_entrada = null;
            rotacoes_laminacao = null;
            torque = null;
            potencia = null;
            corrente_motor = null;
            tempo_laminacao = null;
            tempo_morto = null;
            temperatura = null;
            posicao_mesa_5_03_2 = null;
            posicao_mesa_5_26_4 = null;
            posicao_mesa_5_03_03 = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }

        public int? id_t_importacao_modelo_tandem_urs { get; set; }
        public int? id_t_importacao { get; set; }
        [Column(1)] public int? passe { get; set; }
        [Column(2)] public string cadeira { get; set; }
        [Column(3)] public double? alma_espessura { get; set; }
        [Column(4)] public double? alma_espessura_ideal { get; set; }
        [Column(5)] public double? alma_along { get; set; }
        [Column(6)] public double? alma_reducao { get; set; }
        [Column(7)] public double? alma_forca { get; set; }
        [Column(8)] public double? flange_espessura { get; set; }
        [Column(9)] public double? flange_espessura_ideal { get; set; }
        [Column(10)] public double? flange_along { get; set; }
        [Column(11)] public double? flange_reducao { get; set; }
        [Column(12)] public double? flange_forca { get; set; }
        [Column(14)] public double? perfil_altura { get; set; }
        [Column(13)] public double? perfil_largura { get; set; }
        [Column(15)] public double? area_mm2 { get; set; }
        [Column(16)] public double? area_reducao { get; set; }
        [Column(17)] public double? area_along { get; set; }
        [Column(18)] public double? comprimento { get; set; }
        [Column(19)] public double? diametro_trabalho { get; set; }
        [Column(20)] public double? velocidade_entrada { get; set; }
        [Column(21)] public double? velocidade_laminacao { get; set; }
        [Column(22)] public double? rotacoes_entrada { get; set; }
        [Column(23)] public double? rotacoes_laminacao { get; set; }
        [Column(24)] public double? torque { get; set; }
        [Column(25)] public double? potencia { get; set; }
        [Column(26)] public double? corrente_motor { get; set; }
        [Column(27)] public double? tempo_laminacao { get; set; }
        [Column(28)] public double? tempo_morto { get; set; }
        [Column(29)] public double? temperatura { get; set; }
        [Column(30)] public int? posicao_mesa_5_03_2 { get; set; }
        [Column(31)] public int? posicao_mesa_5_26_4 { get; set; }
        [Column(32)] public int? posicao_mesa_5_03_03 { get; set; }
    }
}

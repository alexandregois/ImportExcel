using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_tandem : ImportData, IImportMultipleData
    {
        public const int FirstRow = 27;

        public const int CountRowsBlock = 9;
        public T_importacao_modelo_tandem()
        {
            id_t_importacao_modelo_tandem = null;
            id_t_importacao = null;
            numero_passe = null;
            cadeira = null;
            aba_canal = null;
            aba_espessura = null;
            aba_dh = null;
            aba_luz = null;
            aba_along = null;
            aba_reducao = null;
            forca = null;
            area_mm2 = null;
            area_along = null;
            area_reducao = null;
            comprimento = null;
            perfil_altura = null;
            perfil_largura = null;
            diametro_trabalho = null;
            velocidade_entrada = null;
            velocidade_laminacao = null;
            rot_laminacao = null;
            torque = null;
            potencia = null;
            corrente_motor = null;
            tempo_laminacao = null;
            tempo_morto = null;
            posicao_mesa_entrada_cii = null;
            posicao_mesa_entrada_ciin = null;
            posicao_mesa_saida_ciin = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }
        public int? id_t_importacao_modelo_tandem { get; set; }
        public int? id_t_importacao { get; set; }

        [Column(1)]
        public int? numero_passe { get; set; }

        [Column(2)]
        public string cadeira { get; set; }

        [Column(3)]
        public string aba_canal { get; set; }

        [Column(4)]
        public double? aba_espessura { get; set; }

        [Column(5)]
        public double? aba_dh { get; set; }

        [Column(6)]
        public double? aba_luz { get; set; }

        [Column(7)]
        public double? aba_along { get; set; }

        [Column(8)]
        public double? aba_reducao { get; set; }

        [Column(9)]
        public double? forca { get; set; }

        [Column(10)]
        public double? area_mm2 { get; set; }

        [Column(11)]
        public double? area_along { get; set; }

        [Column(12)]
        public double? area_reducao { get; set; }

        [Column(13)]
        public double? comprimento { get; set; }

        [Column(14)]
        public double? perfil_altura { get; set; }

        [Column(15)]
        public double? perfil_largura { get; set; }

        [Column(16)]
        public double? diametro_trabalho { get; set; }

        [Column(17)]
        public double? velocidade_entrada { get; set; }

        [Column(18)]
        public double? velocidade_laminacao { get; set; }

        [Column(19)]
        public double? rot_laminacao { get; set; }

        [Column(20)]
        public double? torque { get; set; }

        [Column(21)]
        public double? potencia { get; set; }

        [Column(22)]
        public double? corrente_motor { get; set; }

        [Column(23)]
        public double? tempo_laminacao { get; set; }

        [Column(24)]
        public double? tempo_morto { get; set; }

        [Column(25)]
        public int? posicao_mesa_entrada_cii { get; set; }

        [Column(26)]
        public int? posicao_mesa_entrada_ciin { get; set; }

        [Column(27)]
        public int? posicao_mesa_saida_ciin { get; set; }
    }
}
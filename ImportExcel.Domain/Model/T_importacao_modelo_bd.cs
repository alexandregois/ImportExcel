using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;
using System;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_bd : ImportData, IImportMultipleData
    {
        public T_importacao_modelo_bd()
        {
            id_t_importacao_modelo_bd = null;
            id_t_importacao = null;
            numero_passe = null;
            canal_posicao_stripper_entrada = null;
            canal_posicao_stripper = null;
            canal_posicao_stripper_saida = null;
            giro = null;
            tipo = null;
            alma_espes = null;
            alma_dh = null;
            luz = null;
            pass_line = null;
            perfil_altura = null;
            perfil_largura = null;
            area_mm2 = null;
            area_red = null;
            area_along = null;
            comp = null;
            dia_trab = null;
            velocidade_entrada = null;
            velocidade_laminacao = null;
            tempo_laminacao = null;
            tempo_morto = null;
            forca = null;
            torque = null;
            tipo_bd_value = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }

        public const int FirstRow = 19;
        public const int CountRowsBlock = 13;
        public int? id_t_importacao_modelo_bd { get; set; }
        public int? id_t_importacao { get; set; }

        public int? tipo_bd
        {
            get
            {
                switch (tipo_bd_value)
                {
                    case "BD1":
                        return 1;
                        break;
                    case "BD2":
                        return 2;
                        break;
                    default:
                        return null;
                        break;
                }
            }
        }

        [Column(2), IgnoreValue]
        public string tipo_bd_value { get; set; }

        [Column(3), IgnoreValue]
        public int? numero_passe { get; set; }

        [Column(4)]
        public string canal_posicao_stripper_entrada { get; set; }

        [Column(5)]
        public string canal_posicao_stripper { get; set; }

        [Column(6)]
        public string canal_posicao_stripper_saida { get; set; }

        [Column(7)]
        public string giro { get; set; }

        [Column(8)]
        public string tipo { get; set; }
        //public double? tipo { get; set; }

        [Column(9), Round(2)]
        public double? alma_espes { get; set; }

        [Column(10), Round(1)]
        public double? alma_dh { get; set; }

        [Column(11), Round(2)]
        public double? luz { get; set; }

        [Column(12), Round(2)]
        public double? pass_line { get; set; }

        [Column(13), Round(2)]
        public double? perfil_largura { get; set; }

        [Column(14), Round(2)]
        public double? perfil_altura { get; set; }

        [Column(15), Round(2)]
        public double? area_mm2 { get; set; }

        [Column(17), Round(1)]
        public double? area_red { get; set; }

        [Column(18), Round(3)]
        public double? area_along { get; set; }

        [Column(19), Round(1)]
        public double? comp { get; set; }

        [Column(20), Round(2)]
        public double? dia_trab { get; set; }

        [Column(22), Round(1)]
        public double? velocidade_entrada { get; set; }

        [Column(23), Round(1)]
        public double? velocidade_laminacao { get; set; }

        [Column(24), Round(1)]
        public double? tempo_laminacao { get; set; }

        [Column(25), Round(1)]
        public double? tempo_morto { get; set; }

        [Column(26), Round(1)]
        public double? forca { get; set; }

        [Column(27), Round(1)]
        public double? torque { get; set; }
    }
}
using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_tandem_urs_posicionamento_teorico : ImportData, IImportSingleData
    {
        public T_importacao_modelo_tandem_urs_posicionamento_teorico()
        {
            id_t_importacao_modelo_tandem_urs_posicionamento_teorico = null;
            id_t_importacao = null;
            posicionamento_inicial_cilindro_inferior_ur2 = null;
            posicionamento_inicial_cilindro_inferior_edger = null;
            posicionamento_inicial_cilindro_inferior_ur2n = null;
            cpl_ur2 = null;
            cpl_ur2n = null;
            passe_line_teorico = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }

        public int? id_t_importacao_modelo_tandem_urs_posicionamento_teorico { get; set; }
        public int? id_t_importacao { get; set; }

        [Column(17), Row(18)]
        public double? posicionamento_inicial_cilindro_inferior_ur2 { get; set; }

        [Column(17), Row(19)]
        public double? posicionamento_inicial_cilindro_inferior_edger { get; set; }

        [Column(17), Row(20)]
        public double? posicionamento_inicial_cilindro_inferior_ur2n { get; set; }

        [Column(20), Row(18)]
        public double? cpl_ur2 { get; set; }

        [Column(20), Row(20)]
        public double? cpl_ur2n { get; set; }

        [Column(18), Row(22)]
        public double? passe_line_teorico { get; set; }
    }
}

using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_tandem_urs_tempo : ImportData, IImportSingleData
    {
        public const int column = 30;
        public T_importacao_modelo_tandem_urs_tempo()
        {
            id_t_importacao_modelo_tandem_urs_tempo = null;
            id_t_importacao = null;
            laminacao = null;
            morto_teorico = null;
            total = null;
            produtividade = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }

        public int? id_t_importacao_modelo_tandem_urs_tempo { get; set; }
        public int? id_t_importacao { get; set; }
        [Column(column), Row(20)] public double? laminacao { get; set; }
        [Column(column), Row(21)] public double? morto_teorico { get; set; }
        [Column(column), Row(22)] public double? total { get; set; }
        [Column(column), Row(24)] public double? produtividade { get; set; }
    }
}

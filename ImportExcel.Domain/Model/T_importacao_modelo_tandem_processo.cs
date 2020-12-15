using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_tandem_processo : ImportData, IImportSingleData
    {
        public const int column = 4;
        public T_importacao_modelo_tandem_processo()
        {
            id_t_importacao_modelo_tandem_processo = null;
            id_t_importacao = null;
            diametro_inicial_cii = null;
            diametro_inicial_ciin = null;
            numero_passes = null;
            passe_line_teorico = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }

        public int? id_t_importacao_modelo_tandem_processo { get; set; }
        public int? id_t_importacao { get; set; }

        [Column(column), Row(17)]//16
        public double? diametro_inicial_cii { get; set; }

        [Column(column), Row(18)]//17
        public double? diametro_inicial_ciin { get; set; }

        [Column(column), Row(19)]
        public double? numero_passes { get; set; }

        [Column(column), Row(20)]
        public double? passe_line_teorico { get; set; }
    }
}
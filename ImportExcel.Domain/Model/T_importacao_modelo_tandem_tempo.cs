using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_tandem_tempo : ImportData, IImportSingleData
    {
        private const int column = 26;

        public T_importacao_modelo_tandem_tempo()
        {
            id_t_importacao_modelo_tandem_tempo = null;
            id_t_importacao = null;
            laminacao = null;
            morto = null;
            total = null;
            produtividade = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }

        public int? id_t_importacao_modelo_tandem_tempo { get; set; }
        public int? id_t_importacao { get; set; }

        [Row(15), Column(column)]
        public double? laminacao { get; set; }

        [Row(16), Column(column)]
        public double? morto { get; set; }

        [Row(17), Column(column)]
        public double? total { get; set; }

        [Row(18), Column(column)]
        public double? produtividade { get; set; }
    }
}
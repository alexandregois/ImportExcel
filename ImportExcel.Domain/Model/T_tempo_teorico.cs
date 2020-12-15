using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;

namespace ImportExcel.Domain.Model
{
    public class T_tempo_teorico : ImportData, IImportSingleData
    {
        private const int column = 27;
        public T_tempo_teorico()
        {
            id_t_tempo_teorico = null;
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

        public int? id_t_tempo_teorico { get; set; }
        public int? id_t_importacao { get; set; }

        [Row(4), Column(column), Round(1)]
        public double? laminacao { get; set; }

        [Row(5), Column(column), Round(1)]
        public double? morto { get; set; }

        [Row(6), Column(column), Round(1)]
        public double? total { get; set; }

        [Row(7), Column(column), Round(1)]
        public double? produtividade { get; set; }
    }
}
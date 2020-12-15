using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_tandem_urs_produto : ImportData, IImportSingleData
    {
        public T_importacao_modelo_tandem_urs_produto()
        {
            id_t_importacao_modelo_tandem_urs_produto = null;
            id_t_importacao = null;
            bitola_produto = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }

        public int? id_t_importacao_modelo_tandem_urs_produto { get; set; }
        public int? id_t_importacao { get; set; }

        [Column(18), Row(3)]
        public string bitola_produto { get; set; }
    }
}
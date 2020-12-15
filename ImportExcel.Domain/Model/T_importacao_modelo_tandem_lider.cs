using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_tandem_lider : ImportData, IImportSingleData
    {
        public const int column = 4;
        public T_importacao_modelo_tandem_lider()
        {
            id_t_importacao_modelo_tandem_lider = null;
            id_t_importacao = null;
            altura = null;
            largura = null;
            espessura_aba = null;
            espessura_alma = null;
            largura_chamber = null;
            altura_interna = null;
            comprimento_inicial = null;
            area_secao_transversal = null;
            peso_final_bloco = null;
            peso_metro_lider = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }

        public int? id_t_importacao_modelo_tandem_lider { get; set; }
        public int? id_t_importacao { get; set; }

        [Column(column), Row(4)]
        public double? altura { get; set; }

        [Column(column), Row(5)]
        public double? largura { get; set; }

        [Column(column), Row(6)]
        public double? espessura_aba { get; set; }

        [Column(column), Row(7)]
        public double? espessura_alma { get; set; }

        [Column(column), Row(8)]
        public double? largura_chamber { get; set; }

        [Column(column), Row(9)]
        public double? altura_interna { get; set; }

        [Column(column), Row(10)]
        public double? comprimento_inicial { get; set; }

        [Column(column), Row(11)]
        public double? area_secao_transversal { get; set; }

        [Column(column), Row(12)]
        public double? peso_final_bloco { get; set; }

        [Column(column), Row(13)]
        public double? peso_metro_lider { get; set; }
    }
}
using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_tandem_urs_processo : ImportData, IImportSingleData
    {
        public const int column = 4;
        public T_importacao_modelo_tandem_urs_processo()
        {
            id_t_importacao_modelo_tandem_urs_processo = null;
            id_t_importacao = null;
            diametro_inicial_cilindro_horizontal = null;
            diametro_inicial_cilindro_vertical = null;
            diametro_inicial_colar_cil_edger = null;
            profundidade_canal_h_edger = null;
            largura_mesa_cilindros_horizontais_urii = null;
            largura_mesa_cilindros_horizontais_uriin = null;
            numero_passes = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }

        public int? id_t_importacao_modelo_tandem_urs_processo { get; set; }
        public int? id_t_importacao { get; set; }
        [Column(column), Row(22)] public double? diametro_inicial_cilindro_horizontal { get; set; }
        [Column(column), Row(23)] public double? diametro_inicial_cilindro_vertical { get; set; }
        [Column(column), Row(24)] public double? diametro_inicial_colar_cil_edger { get; set; }
        [Column(column), Row(25)] public double? profundidade_canal_h_edger { get; set; }
        [Column(column), Row(26)] public double? largura_mesa_cilindros_horizontais_urii { get; set; }
        [Column(column), Row(27)] public double? largura_mesa_cilindros_horizontais_uriin { get; set; }
        [Column(column), Row(28)] public int? numero_passes { get; set; }
    }
}
using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_tandem_urs_dimensao : ImportData, IImportSingleData
    {
        public T_importacao_modelo_tandem_urs_dimensao()
        {
            id_t_importacao_modelo_tandem_urs_dimensao = null;
            id_t_importacao = null;
            profundidade_chamber_minimo = null;
            profundidade_chamber_nominal = null;
            profundidade_chamber_maximo = null;
            largura_chamber_minimo = null;
            largura_chamber_nominal = null;
            largura_chamber_maximo = null;
            espessura_alma_minimo = null;
            espessura_alma_nominal = null;
            espessura_alma_maximo = null;
            espessura_aba_minimo = null;
            espessura_aba_nominal = null;
            espessura_aba_maximo = null;
            largura_flange_minimo = null;
            largura_flange_nominal = null;
            largura_flange_maximo = null;
            altura_perfil_minimo = null;
            altura_perfil_nominal = null;
            altura_perfil_maximo = null;
            raio_produto_minimo = null;
            raio_produto_nominal = null;
            raio_produto_maximo = null;
            peso_metro_viga_minimo = null;
            peso_metro_viga_nominal = null;
            peso_metro_viga_maximo = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }
        public int? id_t_importacao_modelo_tandem_urs_dimensao { get; set; }
        public int? id_t_importacao { get; set; }
        [Column(17), Row(8)] public double? profundidade_chamber_minimo { get; set; }
        [Column(18), Row(8)] public double? profundidade_chamber_nominal { get; set; }
        [Column(19), Row(8)] public double? profundidade_chamber_maximo { get; set; }
        [Column(17), Row(9)] public double? largura_chamber_minimo { get; set; }
        [Column(18), Row(9)] public double? largura_chamber_nominal { get; set; }
        [Column(19), Row(9)] public double? largura_chamber_maximo { get; set; }
        [Column(17), Row(10)] public double? espessura_alma_minimo { get; set; }
        [Column(18), Row(10)] public double? espessura_alma_nominal { get; set; }
        [Column(19), Row(10)] public double? espessura_alma_maximo { get; set; }
        [Column(17), Row(11)] public double? espessura_aba_minimo { get; set; }
        [Column(18), Row(11)] public double? espessura_aba_nominal { get; set; }
        [Column(19), Row(11)] public double? espessura_aba_maximo { get; set; }
        [Column(17), Row(12)] public double? largura_flange_minimo { get; set; }
        [Column(18), Row(12)] public double? largura_flange_nominal { get; set; }
        [Column(19), Row(12)] public double? largura_flange_maximo { get; set; }
        [Column(17), Row(13)] public double? altura_perfil_minimo { get; set; }
        [Column(18), Row(13)] public double? altura_perfil_nominal { get; set; }
        [Column(19), Row(13)] public double? altura_perfil_maximo { get; set; }
        [Column(17), Row(14)] public double? raio_produto_minimo { get; set; }
        [Column(18), Row(14)] public double? raio_produto_nominal { get; set; }
        [Column(19), Row(14)] public double? raio_produto_maximo { get; set; }
        [Column(17), Row(15)] public double? peso_metro_viga_minimo { get; set; }
        [Column(18), Row(15)] public double? peso_metro_viga_nominal { get; set; }
        [Column(19), Row(15)] public double? peso_metro_viga_maximo { get; set; }

    }
}
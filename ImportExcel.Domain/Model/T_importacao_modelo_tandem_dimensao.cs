using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_tandem_dimensao : ImportData, IImportSingleData
    {
        public T_importacao_modelo_tandem_dimensao()
        {
            id_t_importacao_modelo_tandem_dimensao = null;
            id_t_importacao = null;
            espessura_alma_minimo = null;
            espessura_alma_nominal = null;
            espessura_alma_maximo = null;
            espessura_aba_minimo = null;
            espessura_aba_nominal = null;
            espessura_aba_maximo = null;
            largura_aba_minimo = null;
            largura_aba_nominal = null;
            largura_aba_maximo = null;
            chamber_minimo = null;
            chamber_nominal = null;
            chamber_maximo = null;
            altura_perfil_minimo = null;
            altura_perfil_nominal = null;
            altura_perfil_maximo = null;
            altura_interna_aba_minimo = null;
            altura_interna_aba_nominal = null;
            altura_interna_aba_maximo = null;
            peso_metro_viga_minimo = null;
            peso_metro_viga_nominal = null;
            peso_metro_viga_maximo = null;
            raio_produto_minimo = null;
            raio_produto_nominal = null;
            raio_produto_maximo = null;
            bf1_bf2_minimo = null;
            bf1_bf2_nominal = null;
            bf1_bf2_maximo = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }

        public int? id_t_importacao_modelo_tandem_dimensao { get; set; }
        public int? id_t_importacao { get; set; }

        [Column(14), Row(8)] public double? espessura_alma_minimo { get; set; }
        [Column(15), Row(8)] public double? espessura_alma_nominal { get; set; }
        [Column(16), Row(8)] public double? espessura_alma_maximo { get; set; }
        [Column(14), Row(9)] public double? espessura_aba_minimo { get; set; }
        [Column(15), Row(9)] public double? espessura_aba_nominal { get; set; }
        [Column(16), Row(9)] public double? espessura_aba_maximo { get; set; }
        [Column(14), Row(10)] public double? largura_aba_minimo { get; set; }
        [Column(15), Row(10)] public double? largura_aba_nominal { get; set; }
        [Column(16), Row(10)] public double? largura_aba_maximo { get; set; }
        [Column(14), Row(11)] public double? chamber_minimo { get; set; }
        [Column(15), Row(11)] public double? chamber_nominal { get; set; }
        [Column(16), Row(11)] public double? chamber_maximo { get; set; }
        [Column(14), Row(12)] public double? altura_perfil_minimo { get; set; }
        [Column(15), Row(12)] public double? altura_perfil_nominal { get; set; }
        [Column(16), Row(12)] public double? altura_perfil_maximo { get; set; }
        [Column(14), Row(13)] public double? altura_interna_aba_minimo { get; set; }
        [Column(15), Row(13)] public double? altura_interna_aba_nominal { get; set; }
        [Column(16), Row(13)] public double? altura_interna_aba_maximo { get; set; }
        [Column(14), Row(14)] public double? peso_metro_viga_minimo { get; set; }
        [Column(15), Row(14)] public double? peso_metro_viga_nominal { get; set; }
        [Column(16), Row(14)] public double? peso_metro_viga_maximo { get; set; }
        [Column(14), Row(15)] public double? raio_produto_minimo { get; set; }
        [Column(15), Row(15)] public double? raio_produto_nominal { get; set; }
        [Column(16), Row(15)] public double? raio_produto_maximo { get; set; }
        [Column(14), Row(16)] public double? bf1_bf2_minimo { get; set; }
        [Column(15), Row(16)] public double? bf1_bf2_nominal { get; set; }
        [Column(16), Row(16)] public double? bf1_bf2_maximo { get; set; }
    }
}
using ImportExcel.Domain.Interfaces;
using ImportExcel.Domain.Utils.CustomDataAnnotations;

namespace ImportExcel.Domain.Model
{
    public class T_importacao_modelo_bd_materia_prima : ImportData, IImportSingleData
    {
        private const int column = 5;
        public T_importacao_modelo_bd_materia_prima()
        {
            id_t_importacao_modelo_bd_materia_prima = null;
            id_t_importacao = null;
            tipo = null;
            espessura = null;
            altura = null;
            largura = null;
            comprimento = null;
            area = null;
            peso_por_metro = null;
            peso = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }

        public int? id_t_importacao_modelo_bd_materia_prima { get; set; }
        public int? id_t_importacao { get; set; }

        [Row(4), Column(column), Round(1)]
        public string tipo { get; set; }

        [Row(5), Column(column), Round(1)]
        public double? espessura { get; set; }

        [Row(6), Column(column), Round(1)]
        public double? altura { get; set; }

        [Row(7), Column(column), Round(1)]
        public double? largura { get; set; }

        [Row(8), Column(column), Round(1)]
        public double? comprimento { get; set; }

        [Row(9), Column(column), Round(1)]
        public double? area { get; set; }

        [Row(10), Column(column), Round(1)]
        public double? peso_por_metro { get; set; }

        [Row(11), Column(column), Round(1)]
        public double? peso { get; set; }
    }
}
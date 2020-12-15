using System;

namespace ImportExcel.Domain.Model
{
    public class T_importacao 
    {
        public T_importacao()
        {
            id_t_importacao = null;
            id_t_modelo = null;
            nome_arquivo = null;
            data_importcacao = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            nome_arquivo_original = null;
            guid_referencia = null;
            id_t_familia = null;
            id_t_produto = null;
            id_t_bitola = null;
            data_upload = null;
        }

        public int? id_t_importacao { get; set; }
        public int? id_t_modelo { get; set; }
        public string nome_arquivo { get; set; }
        public DateTime? data_importcacao { get; set; }
        public DateTime? data_ultima_atualizacao { get; set; }
        public int? id_t_usuario { get; set; }
        public string nome_arquivo_original { get; set; }
        public string guid_referencia { get; set; }
        public int? id_t_familia  { get; set; }
        public int? id_t_produto  { get; set; }
        public int? id_t_bitola { get; set; }
        public DateTime? data_upload { get; set; }
    }
}

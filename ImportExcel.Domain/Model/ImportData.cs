using System;

namespace ImportExcel.Domain.Model
{
    public class ImportData
    {
        public DateTime? data_ultima_atualizacao { get; set; }
        public int? id_t_usuario { get; set; }
        public bool? registro_ativo { get; set; }
        public int? id_t_cadastro_acao { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ImportExcel.Domain.Model.Log
{
    public class T_importacao_log
    { 
        public T_importacao_log() {}

        public int? id_t_importacao { get; set; }
        public int? id_t_erro { get; set; }
        public int? id_t_log_tipo { get; set; }
        public int? coluna { get; set; }
        public int? linha { get; set; }
        public string conteudo { get; set; }
    }
}

namespace ImportExcel.Domain.Model
{
    public class T_modelo : ImportData
    {
        public T_modelo()
        {
            id_t_modelo = null;
            nome_modelo = null;
            data_ultima_atualizacao = null;
            id_t_usuario = null;
            registro_ativo = null;
            id_t_cadastro_acao = null;
        }

        public int? id_t_modelo { get; set; }
        public string nome_modelo { get; set; }
    }
}
using ImportExcel.Domain.Model.Log;
using ImportExcel.Domain.Model.Log.Enuns;
using ImportExcel.Infra.Data;

namespace ImportExcel.Service
{
    internal class LogService
    {
        internal async void Log(T_importacao_log _log)
        => SetIntInApi(_log);

        internal async void LogCampoNumericoComValorTexto(int row, int column, string conteudo, int id_t_importacao)
            => LogCelula(row, column, id_t_importacao, conteudo, TipoErro.campo_numerico_com_valor_de_texto);

        internal async void LogCelulaComFormula(int row, int column, string conteudo, int id_t_importacao)
            => LogCelula(row, column, id_t_importacao, conteudo, TipoErro.identificado_formula_na_celula);

        private async void SetIntInApi(T_importacao_log _log)
        => await new Api().SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_log", _log);

        private async void LogCelula(int row, int column, int id_t_importacao, string conteudo, TipoErro tipoErro)
        {
            if (id_t_importacao <= 0) return;
            var log = new T_importacao_log()
            {
                coluna = column,
                linha = row,
                id_t_importacao = id_t_importacao,
                id_t_erro = (int)tipoErro,
                id_t_log_tipo = (int)TipoLog.Erro,
                conteudo = conteudo
            };
            SetIntInApi(log);
        }
    }
}
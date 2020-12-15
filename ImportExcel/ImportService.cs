using ImportExcel.Domain.Model;
using ImportExcel.Domain.Model.Enuns;
using ImportExcel.Domain.Model.Log;
using ImportExcel.Domain.Model.Log.Enuns;
using ImportExcel.Domain.Utils.CustomDataAnnotations;
using ImportExcel.Infra.Data;
using ImportExcel.Service.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ImportExcel.Service
{
    public class ImportService : IImportService
    {
        private LogService log = null;
        private IReadExcelService readExcelService = null;

        public ImportService()
        {
            this.log = new LogService();
            this.readExcelService = new ReadExcelService();
        }

        public async Task<int> CreateImport(string fileName, string fullPath)
        {
            bool bShouldExecT_importUpdateDate = false;

            using (var api = new Api())
            {

                #region [ Pega a importação pelo guid e salva a data]

                var import = new T_importacao() { guid_referencia = fileName.Split('.')[0] };

                #if DEBUG
                    import = new T_importacao() { guid_referencia = "b9bf180a-aa46-4acf-bba2-d1283d2ed691" };
                #endif

                //var import = new T_importacao() { nome_arquivo_original = fileName };


                import = await api.GetObject<T_importacao>(Constants.HostAddress, Constants.DataBase, "s_get_t_importacao", import);

                if (import == null)
                {
                    log.Log(new T_importacao_log
                    {
                        //id_t_importacao = import.id_t_importacao,
                        conteudo = $"guid_referencia '{fileName.Split('.')[0]}' não localizado ao chamar s_get_t_importacao",
                        id_t_erro = (int)Domain.Model.Log.Enuns.TipoErro.desconhecido,
                        id_t_log_tipo = (int)TipoLog.Erro
                    });

                    return -1;
                }

                if (import.data_importcacao != null)
                {
                    log.Log(new T_importacao_log()
                    {
                        id_t_importacao = import.id_t_importacao,
                        id_t_erro = (int)Domain.Model.Log.Enuns.TipoErro.arquivo_ja_importado,
                        id_t_log_tipo = (int)TipoLog.Erro
                    });
                    return 0;
                }
                else
                {
                    import.data_importcacao = DateTime.Now;
                    bShouldExecT_importUpdateDate = true;
                }

                int.TryParse(import.id_t_importacao.ToString(), out int idImport_result);

                #endregion


                switch ((Modelo)import.id_t_modelo)
                {
                    case Modelo.Desbaste:
                        await ImportDesbaste(fullPath, idImport_result, api);
                        break;
                    case Modelo.TandemConvencional:
                        await ImportTandemConvencional(fullPath, idImport_result, api);
                        break;
                    case Modelo.TandemUniversal:
                        await ImportTandemUniversal(fullPath, idImport_result, api);
                        break;
                    default:
                        break;
                }

                if (bShouldExecT_importUpdateDate)
                    await api.SetInt<T_importacao>(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao", import);

                return idImport_result;
            }
        }

        private async Task ImportDesbaste(string fullPath, int idImport_result, Api api)
        {

            #region [ Salva tempo teórico ]
            var tempoTeorico = new T_tempo_teorico { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_tempo_teorico), tempoTeorico, fullPath, idImport_result);
            tempoTeorico.id_t_tempo_teorico = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_tempo_teorico", tempoTeorico);
            #endregion

            #region [ Salva esboços desbastadores ]
            SetBDEsboco(1, T_importacao_modelo_bd_esbocos.column_bd1, idImport_result, fullPath, api);
            SetBDEsboco(2, T_importacao_modelo_bd_esbocos.column_bd2, idImport_result, fullPath, api);
            #endregion

            #region [ Salva matéria prima ]
            var materiaPrima = new T_importacao_modelo_bd_materia_prima { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_importacao_modelo_bd_materia_prima), materiaPrima, fullPath, idImport_result);
            materiaPrima.id_t_importacao_modelo_bd_materia_prima = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_bd_materia_prima", materiaPrima);
            #endregion

            #region [ Salva produto ]
            var produto = new T_importacao_modelo_bd_produto { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_importacao_modelo_bd_produto), produto, fullPath, idImport_result);
            produto.id_t_importacao_modelo_bd_produto = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_bd_produto", produto);
            #endregion

            #region [ Salva lista de BD ]
            var bds = readExcelService.ReadFile_BD(fullPath, idImport_result);

            foreach (var bd in bds)
            {
                bd.registro_ativo = true;
                bd.id_t_cadastro_acao = 1;
                bd.id_t_importacao_modelo_bd = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_bd", bd);
            }
            #endregion

            #region [ Salva identificação ]
            var identificacao = new T_importacao_modelo_bd_identificacao { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_importacao_modelo_bd_identificacao), identificacao, fullPath, idImport_result);
            identificacao.id_t_importacao_modelo_bd_identificacao = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_bd_identificacao", identificacao);
            #endregion
        }

        private async Task ImportTandemConvencional(string fullPath, int idImport_result, Api api)
        {
            #region [ Salva dados teóricos do líder ]
            var lider = new T_importacao_modelo_tandem_lider { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_importacao_modelo_tandem_lider), lider, fullPath, idImport_result);
            lider.id_t_importacao_modelo_tandem_lider = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_tandem_lider", lider);
            #endregion

            #region [ Salva dados do processo]
            var processo = new T_importacao_modelo_tandem_processo { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_importacao_modelo_tandem_processo), processo, fullPath, idImport_result);
            processo.id_t_importacao_modelo_tandem_processo = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_tandem_processo", processo);
            #endregion

            #region [ Salva dados de dimensões ]
            var dimensao = new T_importacao_modelo_tandem_dimensao { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_importacao_modelo_tandem_dimensao), dimensao, fullPath, idImport_result);
            dimensao.id_t_importacao_modelo_tandem_dimensao = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_tandem_dimensao", dimensao);
            #endregion

            #region [ Salva dados de tempo teórico]
            var tempo = new T_importacao_modelo_tandem_tempo { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_importacao_modelo_tandem_tempo), tempo, fullPath, idImport_result);
            tempo.id_t_importacao_modelo_tandem_tempo = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_tandem_tempo", tempo);
            #endregion

            #region [ Salva dados de produto]
            var produto = new T_importacao_modelo_tandem_produto { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_importacao_modelo_tandem_produto), produto, fullPath, idImport_result);
            produto.id_t_importacao_modelo_tandem_produto = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_tandem_produto", produto);
            #endregion

            #region [ Salva dados de identificação]
            var identificacao = new T_importacao_modelo_tandem_identificacao { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_importacao_modelo_tandem_identificacao), identificacao, fullPath, idImport_result);
            identificacao.id_t_importacao_modelo_tandem_identificacao = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_tandem_identificacao", identificacao);
            #endregion

            #region [ Salva lista de itens ]
            var tandems = readExcelService.ReadFile_Tandem(fullPath, idImport_result);

            foreach (var t in tandems)
            {
                t.registro_ativo = true;
                t.id_t_cadastro_acao = 1;
                t.id_t_importacao_modelo_tandem = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_tandem", t);
            }
            #endregion
        }

        private async void SetBDEsboco(int _tipobd, int _columnIndex, int _idImportacao, string fullPath, Api _api)
        {
            var esboco = new T_importacao_modelo_bd_esbocos { id_t_importacao = _idImportacao, tipo_bd = _tipobd };
            readExcelService.ReadFile(typeof(T_importacao_modelo_bd_esbocos), esboco, fullPath, _idImportacao, false, new Column(_columnIndex));
            esboco.id_t_importacao_modelo_bd_esbocos = await _api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_bd_esbocos", esboco);
        }

        private async Task ImportTandemUniversal(string fullPath, int idImport_result, Api api)
        {
            #region [ Salva dados beam blank ]
            var beamBlank = new T_importacao_modelo_tandem_urs_beam_blank { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_importacao_modelo_tandem_urs_beam_blank), beamBlank, fullPath, idImport_result, true, null, true, 1);
            beamBlank.id_t_importacao_modelo_tandem_urs_beam_blank = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_tandem_urs_beam_blank", beamBlank);
            #endregion

            #region [ Salva dados de dimensão]
            var dimensao = new T_importacao_modelo_tandem_urs_dimensao { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_importacao_modelo_tandem_urs_dimensao), dimensao, fullPath, idImport_result, true, null, true, 1);
            dimensao.id_t_importacao_modelo_tandem_urs_dimensao = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_tandem_urs_dimensao", dimensao);
            #endregion

            #region [ Salva dados de tempo ]
            var tempo = new T_importacao_modelo_tandem_urs_tempo { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_importacao_modelo_tandem_urs_tempo), tempo, fullPath, idImport_result, true, null, true, 1);
            tempo.id_t_importacao_modelo_tandem_urs_tempo = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_tandem_urs_tempo", tempo);
            #endregion

            #region [ Salva dados de processo]
            var processo = new T_importacao_modelo_tandem_urs_processo { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_importacao_modelo_tandem_urs_processo), processo, fullPath, idImport_result, true, null, true, 1);
            processo.id_t_importacao_modelo_tandem_urs_processo = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_tandem_urs_processo", processo);
            #endregion

            #region [ Salva dados de posicionamento teórico ]
            var posicionamento_teorico = new T_importacao_modelo_tandem_urs_posicionamento_teorico { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_importacao_modelo_tandem_urs_posicionamento_teorico), posicionamento_teorico, fullPath, idImport_result, true, null, true, 1);
            posicionamento_teorico.id_t_importacao_modelo_tandem_urs_posicionamento_teorico = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_tandem_urs_posicionamento_teorico", posicionamento_teorico);
            #endregion

            #region [ Salva dados de identificação ]
            var identificacao = new T_importacao_modelo_tandem_urs_identificacao { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_importacao_modelo_tandem_urs_identificacao), identificacao, fullPath, idImport_result, true, null, true, 1);
            identificacao.id_t_importacao_modelo_tandem_urs_identificacao = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_tandem_urs_identificacao", identificacao);
            #endregion

            #region [ Salva dados de produto ]
            var produto = new T_importacao_modelo_tandem_urs_produto { id_t_importacao = idImport_result };
            readExcelService.ReadFile(typeof(T_importacao_modelo_tandem_urs_produto), produto, fullPath, idImport_result, true, null, true, 1);
            produto.id_t_importacao_modelo_tandem_urs_produto = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_tandem_urs_produto", produto);
            #endregion

            #region [ Salva lista de itens ]
            var tandems = readExcelService.ReadFile_TandemUniversal(fullPath, idImport_result);

            foreach (var t in tandems)
            {
                t.registro_ativo = true;
                t.id_t_cadastro_acao = 1;
                t.id_t_importacao_modelo_tandem_urs = await api.SetInt(Constants.HostAddress, Constants.DataBase, "s_set_t_importacao_modelo_tandem_urs", t);
            }
            #endregion
        }
    }
}
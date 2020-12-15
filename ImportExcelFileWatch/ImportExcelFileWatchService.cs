using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ImportExcel.Service.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ImportExcelFileWatch
{
    public class ImportExcelFileWatchService : IHostedService, IDisposable
    {
        private readonly ILogger logger;
        private readonly IOptions<AppConfig> config;
        private Timer timer;
        private static IImportService importService;
        private static string watchPath;

        public ImportExcelFileWatchService(ILogger<ImportExcelFileWatchService> pLogger, IOptions<AppConfig> pAppConfig, IImportService service)
        {
            logger = pLogger;
            config = pAppConfig;
            importService = service;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"Starting... | interval: '{config.Value.Interval}'");
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(config.Value.Interval));

            return Task.CompletedTask;
        }

        private void WriteColor(string text, ConsoleColor foreColor = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black, bool isFullLine = true)
        {
            Console.ForegroundColor = foreColor;
            Console.BackgroundColor = backColor;
            if (isFullLine) Console.WriteLine(text); else Console.Write(text);
            
            Console.ResetColor();
        }

        private async void DoWork(object state)
        {
            logger.LogInformation($"Background work: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss fff zzz")}");
            Console.WriteLine(string.Empty);
            WriteColor("Processamento iniciado em @" + DateTime.Now.ToString("dd/MM/yyy HH:mm:ss"), ConsoleColor.Yellow);

            try
            {
                timer?.Change(Timeout.Infinite, 0);
                var watcher = new FileSystemWatcher();

                watcher.Created += OnCreated;
                watcher.Path = config.Value.watch_folder;
                watcher.EnableRaisingEvents = true;
                watcher.IncludeSubdirectories = true;
                
                watchPath = watcher.Path;

                WriteColor($"Observando o diretório ... {watcher.Path}", ConsoleColor.Yellow);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                WriteColor($"Erro ... {ex.Message}", ConsoleColor.Red, ConsoleColor.White);
                logger.LogCritical(ex, "", null);
            }

            return;
        }

        private async static void OnCreated(object sender, FileSystemEventArgs e)
        {
            int rst = 0;
            Console.ForegroundColor = ConsoleColor.White; Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine($"Novo arquivo foi criado - {e.Name}");
            Console.ResetColor();

            await Task.Delay(2000).ContinueWith(async (obj) =>
            {
                if ((rst = await importService.CreateImport(e.Name, Path.Combine(watchPath, e.Name))) < 1)
                {
                    if (rst == -1)
                    { 
                        Console.ForegroundColor = ConsoleColor.Red; Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine($"guid_referencia não localizado ao chamar s_get_t_importacao");
                        Console.ResetColor();
                    }

                    Console.ForegroundColor = ConsoleColor.White; Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Não foi possível proceder com a importação do arquivo {e.Name}. Por favor verifique o log.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green; Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($"Importação do arquivo {e.Name} foi realizada com sucesso... id_t_importacao = {rst}");
                    Console.ResetColor();
                }
            });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Stopping...");
            timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}

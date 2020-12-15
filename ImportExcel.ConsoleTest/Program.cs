using ImportExcel.ConsoleTest.Util;
using ImportExcel.Domain.Model.Enuns;
using ImportExcel.Service;
using System;
using System.Threading.Tasks;

namespace ImportExcel.ConsoleTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ConsoleUtil.WriteColor($"ConsoleTest_ImportXls v1.0", ConsoleColor.Yellow);
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);

            var svc = new ImportService();

            //var fileName = "w150x13.xlsx";
            //var fullPath = $@"C:\teste\{fileName}";
            //var import = await svc.CreateImport(fileName, fullPath, Modelo.Desbaste);

            //var fileName = "Tandem_L152x152_Rev_W.xlsx";
            //var fullPath = $@"C:\teste\{fileName}";
            //var import = await svc.CreateImport(fileName, fullPath, Modelo.TandemConvencional);

            var fileName = "W610x101_original.xls";
            var fullPath = $@"C:\teste\{fileName}";
            var import = await svc.CreateImport(fileName, fullPath);

            Console.WriteLine("Terminated");
        }
    }
}

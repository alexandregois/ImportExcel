using ImportExcel.Domain.Model;
using ImportExcel.Domain.Model.Enuns;
using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ImportExcelTest
{
    public class TandemConvencionalTest
    {

        [Fact]
        public void ObterTandem_L152x152_Rev_W_List()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "Tandem_L152x152_Rev_W.xlsx";
            var fullPath = $"../../../Mock/ModeloTandem/{fileName}";

            //Act
            var tandemList = svc.ReadFile_Tandem(fullPath, 1);

            //Assert
            Assert.NotNull(tandemList);
            Assert.True(tandemList.Count() == 6);
            Assert.True(tandemList[0].numero_passe == 1);
            Assert.True(tandemList[0].aba_canal.Equals("6/F"));
        }
    }
}
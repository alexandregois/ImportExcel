using ImportExcel.Service;
using ImportExcel.Service.Interfaces;
using System.Linq;
using Xunit;

namespace ImportExcelTest
{
    public class TandemUniversalTest
    {

        [Fact]
        public void ObterTandemUniversal_W610x101_List()
        {
            //Arrange
            IReadExcelService svc = new ReadExcelService();
            var fileName = "W610x101_original.XLS";
            var fullPath = $"../../../Mock/ModeloTandemUniversal/{fileName}";

            //Act
            var tandemList = svc.ReadFile_TandemUniversal(fullPath, 1);

            //Assert
            Assert.NotNull(tandemList);
            Assert.True(tandemList.Count() == 22);
            Assert.True(tandemList[0].passe == 0);
            Assert.True(tandemList[1].cadeira.Equals("URII"));
        }
    }
}
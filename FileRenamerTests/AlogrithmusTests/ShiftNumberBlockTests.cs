using renamerIdee;
using Moq;
using renamerIdee.Interfaces;

namespace FileRenamerTests.AlogrithmusTests
{
    [TestClass]
    public class ShiftNumberBlockTests
    {
        [TestMethod]
        public void ShiftNumberBlockSuccessful()
        {
            var files = new List<string>
            {
                @"C:\Test\img-123.jpg",
                @"C:\Test\img-3333.jpg",
                @"C:\Test\img-12.gif"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ShiftNumberBlock(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-123.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\123-img.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\3333-img.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-12.gif"),
                It.Is<string>(dest => dest == @"C:\Test\12-img.gif")
            ), Times.Once);
        }

        [TestMethod]
        public void ShiftNumberBlockOneTheOtherWay()
        {
            var files = new List<string>
            {
                @"C:\Test\123-img.jpg",
                @"C:\Test\img-3333.jpg",
                @"C:\Test\img-12.gif"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ShiftNumberBlock(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123-img.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\img-123.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\3333-img.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-12.gif"),
                It.Is<string>(dest => dest == @"C:\Test\12-img.gif")
            ), Times.Once);
        }

        [TestMethod]
        public void ShiftNumberBlockBeginningTwoTheOtherWay()
        {
            var files = new List<string>
            {
                @"C:\Test\123-img.jpg",
                @"C:\Test\3333-img.jpg",
                @"C:\Test\img-12.gif"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ShiftNumberBlock(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123-img.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\img-123.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\3333-img.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\img-3333.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-12.gif"),
                It.Is<string>(dest => dest == @"C:\Test\12-img.gif")
            ), Times.Once);
        }

        [TestMethod]
        public void ShiftNumberBlockBeginningAllTheOtherWay()
        {
            var files = new List<string>
            {
                @"C:\Test\123-img.jpg",
                @"C:\Test\3333-img.jpg",
                @"C:\Test\12-img.gif"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ShiftNumberBlock(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123-img.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\img-123.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\3333-img.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\img-3333.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\12-img.gif"),
                It.Is<string>(dest => dest == @"C:\Test\img-12.gif")
            ), Times.Once);
        }
    }
}
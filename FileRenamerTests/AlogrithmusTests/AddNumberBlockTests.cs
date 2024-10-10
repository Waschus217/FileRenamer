using renamerIdee;
using Moq;
using renamerIdee.Interfaces;

namespace FileRenamerTests.AlogrithmusTests
{
    [TestClass]
    public class AddNumberBlockTests
    {
        [TestMethod]
        public void AddNumberBlockBeginning()
        {
            var files = new List<string>
            {
                @"C:\Test\img.jpg",
                @"C:\Test\art.gif",
                @"C:\Test\miau.png"
            };
            var numberBlock = 123;
            var numberBlockPosition = 1;
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.AddNumberBlock(files, numberBlock, numberBlockPosition, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\123-img.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\art.gif"),
                It.Is<string>(dest => dest == @"C:\Test\123-art.gif")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\miau.png"),
                It.Is<string>(dest => dest == @"C:\Test\123-miau.png")
            ), Times.Once);
        }

        [TestMethod]
        public void AddNumberBlockBeginningOneAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\123-img.jpg",
                @"C:\Test\art.gif",
                @"C:\Test\miau.png"
            };
            var numberBlock = 123;
            var numberBlockPosition = 1;
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.AddNumberBlock(files, numberBlock, numberBlockPosition, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123-img.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\art.gif"),
                It.Is<string>(dest => dest == @"C:\Test\123-art.gif")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\miau.png"),
                It.Is<string>(dest => dest == @"C:\Test\123-miau.png")
            ), Times.Once);
        }

        [TestMethod]
        public void AddNumberBlockBeginningTwoAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\123-img.jpg",
                @"C:\Test\123-art.gif",
                @"C:\Test\miau.png"
            };
            var numberBlock = 123;
            var numberBlockPosition = 1;
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.AddNumberBlock(files, numberBlock, numberBlockPosition, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123-img.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123-art.gif"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\miau.png"),
                It.Is<string>(dest => dest == @"C:\Test\123-miau.png")
            ), Times.Once);
        }

        [TestMethod]
        public void AddNumberBlockBeginningAllAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img.jpg",
                @"C:\Test\art.gif",
                @"C:\Test\miau.png"
            };
            var numberBlock = 123;
            var numberBlockPosition = 1;
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.AddNumberBlock(files, numberBlock, numberBlockPosition, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-123.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-12.png"),
                It.IsAny<string>()
            ), Times.Never);
        }

        [TestMethod]
        public void AddNumberBlockEnding()
        {
            var files = new List<string>
            {
                @"C:\Test\img.jpg",
                @"C:\Test\art.gif",
                @"C:\Test\miau.png"
            };
            var numberBlock = 123;
            var numberBlockPosition = 2;
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.AddNumberBlock(files, numberBlock, numberBlockPosition, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\img-123.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\art.gif"),
                It.Is<string>(dest => dest == @"C:\Test\art-123.gif")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\miau.png"),
                It.Is<string>(dest => dest == @"C:\Test\miau-123.png")
            ), Times.Once);
        }

        [TestMethod]
        public void AddNumberBlockEndingOneAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img-123.jpg",
                @"C:\Test\art.gif",
                @"C:\Test\miau.png"
            };
            var numberBlock = 123;
            var numberBlockPosition = 2;
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.AddNumberBlock(files, numberBlock, numberBlockPosition, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-123.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\art.gif"),
                It.Is<string>(dest => dest == @"C:\Test\art-123.gif")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\miau.png"),
                It.Is<string>(dest => dest == @"C:\Test\miau-123.png")
            ), Times.Once);
        }

        [TestMethod]
        public void AddNumberBlockEndingTwoAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img-123.jpg",
                @"C:\Test\art-123.gif",
                @"C:\Test\miau.png"
            };
            var numberBlock = 123;
            var numberBlockPosition = 2;
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.AddNumberBlock(files, numberBlock, numberBlockPosition, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-123.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\art-123.gif"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\miau.png"),
                It.Is<string>(dest => dest == @"C:\Test\miau-123.png")
            ), Times.Once);
        }

        [TestMethod]
        public void AddNumberBlockEndingAllAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img-123.jpg",
                @"C:\Test\art-123.gif",
                @"C:\Test\miau-123.png"
            };
            var numberBlock = 123;
            var numberBlockPosition = 2;
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.AddNumberBlock(files, numberBlock, numberBlockPosition, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-123.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\art-123.gif"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\miau-123.png"),
                It.IsAny<string>()
            ), Times.Never);
        }
    }
}
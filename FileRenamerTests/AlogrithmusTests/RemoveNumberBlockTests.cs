using renamerIdee;
using Moq;
using renamerIdee.Interfaces;

namespace FileRenamerTests.AlogrithmusTests
{
    [TestClass]
    public class RemoveNumberBlockTests
    {
        [TestMethod]
        public void RemoveNumberBlockBeginning()
        {
            var files = new List<string>
            {
                @"C:\Test\123-img.jpg",
                @"C:\Test\123-art.gif",
                @"C:\Test\123-miau.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveNumberBlock(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123-img.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\img.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123-art.gif"),
                It.Is<string>(dest => dest == @"C:\Test\art.gif")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123-miau.png"),
                It.Is<string>(dest => dest == @"C:\Test\miau.png")
            ), Times.Once);
        }

        [TestMethod]
        public void RemoveNumberBlockBeginningOneAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img.jpg",
                @"C:\Test\123-art.gif",
                @"C:\Test\123-miau.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveNumberBlock(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123-art.gif"),
                It.Is<string>(dest => dest == @"C:\Test\art.gif")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123-miau.png"),
                It.Is<string>(dest => dest == @"C:\Test\miau.png")
            ), Times.Once);
        }

        [TestMethod]
        public void RemoveNumberBlockBeginningTwoAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img.jpg",
                @"C:\Test\art.gif",
                @"C:\Test\123-miau.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveNumberBlock(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\art.gif"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123-miau.png"),
                It.Is<string>(dest => dest == @"C:\Test\miau.png")
            ), Times.Once);
        }

        [TestMethod]
        public void RemoveNumberBlockBeginningAllAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img.jpg",
                @"C:\Test\art.gif",
                @"C:\Test\miau.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveNumberBlock(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\art.gif"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\miau.png"),
                It.IsAny<string>()
            ), Times.Never);
        }

        [TestMethod]
        public void AddNumberBlockEnding()
        {
            var files = new List<string>
            {
                @"C:\Test\img-123.jpg",
                @"C:\Test\art-123.gif",
                @"C:\Test\miau-123.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveNumberBlock(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-123.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\img.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\art-123.gif"),
                It.Is<string>(dest => dest == @"C:\Test\art.gif")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\miau-123.png"),
                It.Is<string>(dest => dest == @"C:\Test\miau.png")
            ), Times.Once);
        }

        [TestMethod]
        public void AddNumberBlockEndingOneAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img.jpg",
                @"C:\Test\art-123.gif",
                @"C:\Test\miau-123.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveNumberBlock(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\art-123.gif"),
                It.Is<string>(dest => dest == @"C:\Test\art.gif")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\miau-123.png"),
                It.Is<string>(dest => dest == @"C:\Test\miau.png")
            ), Times.Once);
        }

        [TestMethod]
        public void AddNumberBlockEndingTwoAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img.jpg",
                @"C:\Test\art.gif",
                @"C:\Test\miau-123.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveNumberBlock(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\art.gif"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\miau-123.png"),
                It.Is<string>(dest => dest == @"C:\Test\miau.png")
            ), Times.Once);
        }

        [TestMethod]
        public void AddNumberBlockEndingAllAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img.jpg",
                @"C:\Test\art.gif",
                @"C:\Test\miau.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveNumberBlock(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\art.gif"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\miau.png"),
                It.IsAny<string>()
            ), Times.Never);
        }
    }
}
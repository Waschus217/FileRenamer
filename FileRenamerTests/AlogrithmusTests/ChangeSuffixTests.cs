using renamerIdee;
using Moq;
using renamerIdee.Interfaces;

namespace FileRenamerTests.AlogrithmusTests
{
    [TestClass]
    public class ChangeSuffixTests
    {
        [TestMethod]
        public void ChangeSuffixSuccessful()
        {
            var files = new List<string>
            {
                @"C:\Test\img-123.jpg",
                @"C:\Test\img-3333.jpg",
                @"C:\Test\img-abc.png"
            };
            var newSuffix = ".gif";
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ChangeSuffix(files, newSuffix, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-123.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\img-123.gif")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\img-3333.gif")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-abc.png"),
                It.Is<string>(dest => dest == @"C:\Test\img-abc.gif")
            ), Times.Once);
        }

        [TestMethod]
        public void ChangeSuffixOneAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img-123.gif",
                @"C:\Test\img-3333.jpg",
                @"C:\Test\img-abc.png"
            };
            var newSuffix = ".gif";
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ChangeSuffix(files, newSuffix, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-123.gif"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\img-3333.gif")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-abc.png"),
                It.Is<string>(dest => dest == @"C:\Test\img-abc.gif")
            ), Times.Once);
        }

        [TestMethod]
        public void ChangeSuffixTwoAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\123.gif",
                @"C:\Test\3333.gif",
                @"C:\Test\img-abc.png"
            };
            var newSuffix = ".gif";
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ChangeSuffix(files, newSuffix, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123.gif"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\3333.gif"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-abc.png"),
                It.Is<string>(dest => dest == @"C:\Test\img-abc.gif")
            ), Times.Once);
        }

        [TestMethod]
        public void ChangeSuffixAllAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\123.gif",
                @"C:\Test\3333.gif",
                @"C:\Test\img-abc.gif"
            };
            var newSuffix = ".gif";
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ChangeSuffix(files, newSuffix, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123.gif"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\3333.gif"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-abc.gif"),
                It.IsAny<string>()
            ), Times.Never);
        }
    }
}
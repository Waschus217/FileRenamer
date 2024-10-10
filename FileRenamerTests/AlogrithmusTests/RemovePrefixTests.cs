using renamerIdee;
using Moq;
using renamerIdee.Interfaces;

namespace FileRenamerTests.AlogrithmusTests
{
    [TestClass]
    public class RemovePrefixTests
    {
        [TestMethod]
        public void RemovePrefixSuccessful()
        {
            var files = new List<string>
            {
                @"C:\Test\img-123.jpg",
                @"C:\Test\img-3333.jpg",
                @"C:\Test\img-abc.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemovePrefix(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-123.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\123.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\3333.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-abc.png"),
                It.Is<string>(dest => dest == @"C:\Test\abc.png")
            ), Times.Once);
        }

        [TestMethod]
        public void RemovePrefixOneAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\123.jpg",
                @"C:\Test\img-3333.jpg",
                @"C:\Test\img-abc.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemovePrefix(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\3333.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-abc.png"),
                It.Is<string>(dest => dest == @"C:\Test\abc.png")
            ), Times.Once);
        }

        [TestMethod]
        public void RemovePrefixTwoAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\123.jpg",
                @"C:\Test\3333.jpg",
                @"C:\Test\img-abc.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemovePrefix(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\3333.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-abc.png"),
                It.Is<string>(dest => dest == @"C:\Test\abc.png")
            ), Times.Once);
        }

        [TestMethod]
        public void RemovePrefixAllAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\123.jpg",
                @"C:\Test\3333.jpg",
                @"C:\Test\abc.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemovePrefix(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\3333.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\abc.png"),
                It.IsAny<string>()
            ), Times.Never);
        }
    }
}
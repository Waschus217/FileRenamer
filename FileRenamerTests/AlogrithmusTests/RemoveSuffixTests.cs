using renamerIdee;
using Moq;
using renamerIdee.Interfaces;

namespace FileRenamerTests.AlogrithmusTests
{
    [TestClass]
    public class RemoveSuffixTests
    {
        [TestMethod]
        public void RemoveSuffixSuccessful()
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

            algorithmus.RemoveSuffix(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-123.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\img-123")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\img-3333")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-abc.png"),
                It.Is<string>(dest => dest == @"C:\Test\img-abc")
            ), Times.Once);
        }

        [TestMethod]
        public void RemoveSuffixOneAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img-123",
                @"C:\Test\img-3333.jpg",
                @"C:\Test\img-abc.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveSuffix(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-123"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\img-3333")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-abc.png"),
                It.Is<string>(dest => dest == @"C:\Test\img-abc")
            ), Times.Once);
        }

        [TestMethod]
        public void RemoveSuffixTwoAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\123",
                @"C:\Test\3333",
                @"C:\Test\img-abc.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveSuffix(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\3333"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-abc.png"),
                It.Is<string>(dest => dest == @"C:\Test\img-abc")
            ), Times.Once);
        }

        [TestMethod]
        public void RemoveSuffixAllAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\123",
                @"C:\Test\3333",
                @"C:\Test\img-abc"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveSuffix(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\3333"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-abc"),
                It.IsAny<string>()
            ), Times.Never);
        }
    }
}
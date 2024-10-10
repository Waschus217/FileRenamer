using renamerIdee;
using Moq;
using renamerIdee.Interfaces;

namespace FileRenamerTests.AlogrithmusTests
{
    [TestClass]
    public class RemoveLeadingZerosTests
    {
        [TestMethod]
        public void RemoveLeadingZerosBeginningOneAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\0123-img.jpg",
                @"C:\Test\3333-img.jpg",
                @"C:\Test\0012-img.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveLeadingZeros(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\0123-img.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\123-img.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\3333-img.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\0012-img.png"),
                It.Is<string>(dest => dest == @"C:\Test\12-img.png")
            ), Times.Once);
        }

        [TestMethod]
        public void RemoveLeadingZerosBeginningTwoAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\123-img.jpg",
                @"C:\Test\3333-img.jpg",
                @"C:\Test\0012-img.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveLeadingZeros(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\123-img.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\3333-img.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\0012-img.png"),
                It.Is<string>(dest => dest == @"C:\Test\12-img.png")
            ), Times.Once);
        }

        [TestMethod]
        public void RemoveLeadingZerosBeginningAllAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\123-img.jpg",
                @"C:\Test\3333-img.jpg",
                @"C:\Test\12-img.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveLeadingZeros(files, directoryPath);

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
        public void RemoveLeadingZerosEndingOneAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img-0123.jpg",
                @"C:\Test\img-3333.jpg",
                @"C:\Test\img-0012.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveLeadingZeros(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-0123.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\img-123.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-0012.png"),
                It.Is<string>(dest => dest == @"C:\Test\img-12.png")
            ), Times.Once);
        }

        [TestMethod]
        public void RemoveLeadingZerosEndingTwoAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img-123.jpg",
                @"C:\Test\img-3333.jpg",
                @"C:\Test\img-0012.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveLeadingZeros(files, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-123.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-0012.png"),
                It.Is<string>(dest => dest == @"C:\Test\img-12.png")
            ), Times.Once);
        }

        [TestMethod]
        public void RemoveLeadingZerosEndingAllAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img-123.jpg",
                @"C:\Test\img-3333.jpg",
                @"C:\Test\img-12.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemoveLeadingZeros(files, directoryPath);

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
    }
}
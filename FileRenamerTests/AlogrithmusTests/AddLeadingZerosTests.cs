using renamerIdee;
using Moq;
using renamerIdee.Interfaces;

namespace FileRenamerTests.AlogrithmusTests
{
    [TestClass]
    public class AddLeadingZerosTests
    {
        [TestMethod]
        public void AddLeadingZerosBeginningOneAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\123-img.jpg",
                @"C:\Test\3333-img.jpg",
                @"C:\Test\12-img.png"
            };
            var totalLength = 4;
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.AddLeadingZeros(files, totalLength, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\0123-img.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\12-img.png"),
                It.Is<string>(dest => dest == @"C:\Test\0012-img.png")
            ), Times.Once);
        }

        [TestMethod]
        public void AddLeadingZerosBeginningTwoAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\123-img.jpg",
                @"C:\Test\3333-img.jpg",
                @"C:\Test\12-img.png"
            };
            var totalLength = 4;
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.AddLeadingZeros(files, totalLength, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\0123-img.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\3333-img.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\12-img.png"),
                It.Is<string>(dest => dest == @"C:\Test\0012-img.png")
            ), Times.Once);
        }

        [TestMethod]
        public void AddLeadingZerosBeginningAllAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\123-img.jpg",
                @"C:\Test\3333-img.jpg",
                @"C:\Test\12-img.png"
            };
            var totalLength = 4;
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.AddLeadingZeros(files, totalLength, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-0123.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-0012.png"),
                It.IsAny<string>()
            ), Times.Never);
        }

        [TestMethod]
        public void AddLeadingZerosEndingOneAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img-0123.jpg",
                @"C:\Test\img-3333.jpg",
                @"C:\Test\img-12.png"
            };
            var totalLength = 4;
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.AddLeadingZeros(files, totalLength, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-0123.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-12.png"),
                It.Is<string>(dest => dest == @"C:\Test\img-0012.png")
            ), Times.Once);
        }

        [TestMethod]
        public void AddLeadingZerosEndingTwoAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img-0123.jpg",
                @"C:\Test\img-3333.jpg",
                @"C:\Test\img-12.png"
            };
            var totalLength = 4;
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.AddLeadingZeros(files, totalLength, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-0123.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-12.png"),
                It.Is<string>(dest => dest == @"C:\Test\img-0012.png")
            ), Times.Once);
        }

        [TestMethod]
        public void AddLeadingZerosEndingAllAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\img-0123.jpg",
                @"C:\Test\img-3333.jpg",
                @"C:\Test\img-0012.png"
            };
            var totalLength = 4;
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.AddLeadingZeros(files, totalLength, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-0123.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-0012.png"),
                It.IsAny<string>()
            ), Times.Never);
        }
    }
}
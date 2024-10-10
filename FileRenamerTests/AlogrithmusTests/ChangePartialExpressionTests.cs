using renamerIdee;
using Moq;
using renamerIdee.Interfaces;

namespace FileRenamerTests.AlogrithmusTests
{
    [TestClass]
    public class ChangePartialExpressionTests
    {
        [TestMethod]
        public void ChangePartialExpressionSuccessful()
        {
            var files = new List<string>
            {
                @"C:\Test\img-123.jpg",
                @"C:\Test\img-3333.jpg",
                @"C:\Test\img-abc.png"
            };
            var oldSubstring = "img";
            var newSubstring = "test";
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ChangePartialExpression(files, oldSubstring, newSubstring, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-123.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\test-123.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\test-3333.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-abc.png"),
                It.Is<string>(dest => dest == @"C:\Test\test-abc.png")
            ), Times.Once);
        }

        [TestMethod]
        public void ChangePartialExpressionOneAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\test-123.jpg",
                @"C:\Test\img-3333.jpg",
                @"C:\Test\img-abc.png"
            };
            var oldSubstring = "img";
            var newSubstring = "test";
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ChangePartialExpression(files, oldSubstring, newSubstring, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\test-123.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-3333.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\test-3333.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-abc.png"),
                It.Is<string>(dest => dest == @"C:\Test\test-abc.png")
            ), Times.Once);
        }

        [TestMethod]
        public void ChangePartialExpressionTwoAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\test-123.jpg",
                @"C:\Test\test-3333.jpg",
                @"C:\Test\img-abc.png"
            };
            var oldSubstring = "img";
            var newSubstring = "test";
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ChangePartialExpression(files, oldSubstring, newSubstring, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\test-123.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\test-3333.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\img-abc.png"),
                It.Is<string>(dest => dest == @"C:\Test\test-abc.png")
            ), Times.Once);
        }

        [TestMethod]
        public void ChangePartialExpressionAllAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\test-123.jpg",
                @"C:\Test\test-3333.jpg",
                @"C:\Test\test-abc.png"
            };
            var oldSubstring = "img";
            var newSubstring = "test";
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ChangePartialExpression(files, oldSubstring, newSubstring, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\test-123.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\test-3333.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\test-abc.png"),
                It.IsAny<string>()
            ), Times.Never);
        }
    }
}
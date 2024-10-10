using renamerIdee;
using Moq;
using renamerIdee.Interfaces;

namespace FileRenamerTests.AlogrithmusTests
{
    [TestClass]
    public class ChangePrefixTests
    {
        [TestMethod]
        public void ChangePrefixSuccessful()
        {
            var files = new List<string>
            {
                @"C:\Test\file1.jpg",
                @"C:\Test\file2.gif",
                @"C:\Test\file3.png"
            };
            var newNamePattern = "test";
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ChangePrefix(files, newNamePattern, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\file1.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\001-test.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\file2.gif"),
                It.Is<string>(dest => dest == @"C:\Test\002-test.gif")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\file3.png"),
                It.Is<string>(dest => dest == @"C:\Test\003-test.png")
            ), Times.Once);
        }

        [TestMethod]
        public void ChangePrefixOneAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\001-test.jpg",
                @"C:\Test\file2.gif",
                @"C:\Test\file3.png"
            };
            var newNamePattern = "test";
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ChangePrefix(files, newNamePattern, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\001-test.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\file2.gif"),
                It.Is<string>(dest => dest == @"C:\Test\002-test.gif")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\file3.png"),
                It.Is<string>(dest => dest == @"C:\Test\003-test.png")
            ), Times.Once);
        }

        [TestMethod]
        public void ChangePrefixTwoAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\001-test.jpg",
                @"C:\Test\002-test.gif",
                @"C:\Test\file3.png"
            };
            var newNamePattern = "test";
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ChangePrefix(files, newNamePattern, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\001-test.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\002-test.gif"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\file3.png"),
                It.Is<string>(dest => dest == @"C:\Test\003-test.png")
            ), Times.Once);
        }

        [TestMethod]
        public void ChangePrefixAllAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\001-test.jpg",
                @"C:\Test\002-test.gif",
                @"C:\Test\003-test.png"
            };
            var newNamePattern = "test";
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ChangePrefix(files, newNamePattern, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\001-test.jpg"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\002-test.gif"),
                It.IsAny<string>()
            ), Times.Never);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\003-test.png"),
                It.IsAny<string>()
            ), Times.Never);
        }
    }
}
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
                @"C:\Test\123-img.jpg",
                @"C:\Test\123-art.gif",
                @"C:\Test\123-miau.png"
            };
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.RemovePrefix(files, directoryPath);

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
        public void ChangePrefixOneAlreadyCorrect()
        {
            var files = new List<string>
            {
                @"C:\Test\001-test.jpg",
                @"C:\Test\file2.jpg"
            };
            var newNamePattern = "test";
            var directoryPath = @"C:\Test";
            var fileMoverMock = new Mock<IFileMover>();
            var algorithmus = new Algorithmus(fileMoverMock.Object);

            algorithmus.ChangePrefix(files, newNamePattern, directoryPath);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\001-test.jpg"),
                It.IsAny<string>()
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\file2.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\002-test.jpg")
            ), Times.Once);
        }
    }
}
using renamerIdee;
using Moq;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                @"C:\Test\file2.jpg",
                @"C:\Test\file3.jpg"
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
                It.Is<string>(src => src == @"C:\Test\file2.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\002-test.jpg")
            ), Times.Once);

            fileMoverMock.Verify(f => f.Move(
                It.Is<string>(src => src == @"C:\Test\file3.jpg"),
                It.Is<string>(dest => dest == @"C:\Test\003-test.jpg")
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
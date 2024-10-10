using renamerIdee;
using Moq;

namespace FileRenamerTests.AlogrithmusTests
{
    [TestClass]
    public class ChangePrefixTests
    {
        [TestMethod]
        public void ChangePrefixSuccessful()
        {
            var algorithmus = new Algorithmus();

            algorithmus.ChangePrefix();
        }
    }
}
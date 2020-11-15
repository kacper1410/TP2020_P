using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1_TP.Data.ObjectModel;

namespace Task1Tests_TP

{
    [TestClass]
    public class ClientTest
    {
        Client Client = new Client("imie", "nazwisko", 20);

        [TestMethod]
        public void ClientGetNameTest()
        {
            Assert.AreEqual("imie", Client.Name);
        }

        [TestMethod]
        public void ClientGetSurnameTest()
        {
            Assert.AreEqual("nazwisko", Client.Surname);
        }

        [TestMethod]
        public void ClientGetAgeTest()
        {
            Assert.AreEqual( 20, Client.Age);
        }

    }
}

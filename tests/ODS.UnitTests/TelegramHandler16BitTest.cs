namespace ODS.UnitTests;
using DSE.Library.ODS;

[TestClass]
public class TelegramHandler16BitTest
{
    [TestMethod]
    public void TestMethod1()
    {
        var byteList = new LinkedList<int>(new[] { 1, 2, 3, 4 });

        TelegramHandler telegramHandler = new TelegramHandler16Bit();
        var m = telegramHandler.Process(byteList);
        Assert.AreEqual(257, m, "Account not debited correctly");
    }

}
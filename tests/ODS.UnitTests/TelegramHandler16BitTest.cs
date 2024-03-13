namespace ODS.UnitTests;
using DSE.Library.ODS;


[TestClass]
public class TelegramHandler16BitTest
{

    [TestMethod]
    public void TestMethod1()
    {
        TelegramHandler telegramHandler = new TelegramHandler16Bit();

        var q1 = new Queue<uint>(new uint[] { 170, 139, 78 });
        var m1 = telegramHandler.Process(q1);
        var e1 = 20107;
        Assert.AreEqual(e1, m1);
    }

    /*
 where:
        a   | b   | c  || d
        170 | 139 | 78 || 20107
         85 | 109 | 82 || 21101
        170 | 207 | 74 || 19151
        170 | 195 | 87 || 22467
    */

}
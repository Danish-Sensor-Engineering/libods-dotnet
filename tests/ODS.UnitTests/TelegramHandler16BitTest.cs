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

}

/*
    TODO: Implement tests here


    def telegram16Bit = new TelegramHandler16Bit()

    def "test 16bit telegram to int conversion"() {
        expect: 'Should return correct distance based on telegram'
        telegram16Bit.convert(a, b, c) == d

        where:
        a   | b   | c  || d
        170 | 139 | 78 || 20107
         85 | 109 | 82 || 21101
        170 | 207 | 74 || 19151
        170 | 195 | 87 || 22467
    }

    def "test header detection"() {
        expect: 'Should return true on valid header'
        telegram16Bit.isHeader(a) == b

        where:
        a   || b
        170 || true
        85  || true
        72  || false
    }

*/
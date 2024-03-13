namespace ODS.UnitTests;
using DSE.Library.ODS;


[TestClass]
public class TelegramHandler18BitTest
{

    [TestMethod]
    public void TestMethod1()
    {
        TelegramHandler telegramHandler = new TelegramHandler18Bit();

        var q1 = new Queue<uint>(new uint[] { 169, 192, 121 });
        var m1 = telegramHandler.Process(q1);
        var e1 = 124673;
        Assert.AreEqual(e1, m1);
    }


}


/*

    TODO: Implement tests here.


    def telegram18Bit = new TelegramHandler18Bit()

    def "test 18bit telegram to int conversion"() {
        expect: 'Should return correct distance based on telegram'
        telegram18Bit.convert(a, b, c) == d

        where:
        a   | b   | c   || d
        169 | 192 | 121 || 124673
         87 | 122 | 121 || 124395
        168 | 150 | 120 || 123480
         85 |   0 | 120 || 122881
        171 |  21 | 123 || 126039
    }

    def "test header detection"() {
        expect: 'Should return true on valid header'
        telegram18Bit.isHeader(a) == b

        where:
        a    || b
        168 || true
        169 || true
        170 || true
        171 || true
         84 || true
         85 || true
         86 || true
         87 || true
        101 || false
        127 || false
         82 || false
    }

*/
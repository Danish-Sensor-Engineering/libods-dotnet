namespace ODS.UnitTests;
using DSE.Library.ODS;


[TestClass]
public class TelegramHandler18BitTest
{

    private TelegramHandler? telegramHandler;


    [TestInitialize]
    public void Initialize() => this.telegramHandler = new TelegramHandler18Bit();



    [TestMethod]
    public void Test18BitConvert()
    {
        var q1 = new Queue<uint>(new uint[] { 169, 192, 121 });
        var m1 = this.telegramHandler.Process(q1);
        uint e1 = 124673;

        Assert.AreEqual(e1, m1);
    }


    [TestMethod]
    public void Test18BitHeader()
    {
        var h = this.telegramHandler.IsHeader(168);
        Assert.AreEqual(true, h);
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
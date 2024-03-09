namespace DSE.Library.ODS;

public class TelegramHandler16Bit : TelegramHandler {

    override protected int convert(int d1, int d2, int d3) {
        return 256 * d3 + d2;

    }

    override protected Boolean isHeader(int h)
    {
        return h == 85 || h == 170;
    }

    public override String? ToString()
    {
        return "16bit";
    }

}
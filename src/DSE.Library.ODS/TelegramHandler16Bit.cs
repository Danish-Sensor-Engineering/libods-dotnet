namespace DSE.Library.ODS;

public class TelegramHandler16Bit : TelegramHandler
{

    protected override int Convert(int d1, int d2, int d3)
    {
        return 256 * d3 + d2;
    }


    protected override bool IsHeader(int h)
    {
        return h == 85 || h == 170;
    }


    public override string? ToString()
    {
        return "16bit";
    }

}
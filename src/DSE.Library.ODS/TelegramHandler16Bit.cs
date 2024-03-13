namespace DSE.Library.ODS;

public class TelegramHandler16Bit : TelegramHandler
{

    protected override uint Convert(uint d1, uint d2, uint d3)
    {
        return (256 * d3) + d2;
    }


    public override bool IsHeader(uint h)
    {
        return h is 85 or 170;
    }


    public override string? ToString()
    {
        return "16bit";
    }

}
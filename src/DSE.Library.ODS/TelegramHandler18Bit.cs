namespace DSE.Library.ODS;

public class TelegramHandler18Bit : TelegramHandler
{

    protected override uint Convert(uint d1, uint d2, uint d3)
    {
        return (1024 * d3) + (4 * d2) + (d1 & 3);
    }


    public override bool IsHeader(uint h)
    {
        if (h is 168 or 169 or 170 or 171)
        {
            return true;
        }

        return h is 84 or 85 or 86 or 87;
    }


    public override string? ToString()
    {
        return "18bit";
    }

}
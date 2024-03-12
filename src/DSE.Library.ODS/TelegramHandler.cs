namespace DSE.Library.ODS;


public abstract class TelegramHandler
{

    // Implemented as either 16bit or 18bit in inherited class
    protected abstract int Convert(int d1, int d2, int d3);
    protected abstract bool IsHeader(int h);

    public int Process(LinkedList<int> readBuffer) {

        if (readBuffer.Count < 4)
        {
            return -1;
        }

        var b1 = readBuffer.First.Value;
        var b2 = readBuffer.First.Value;
        var b3 = readBuffer.First.Value;
        Console.WriteLine("Bytes: " + b1 + ", " + b2 + ", " + b3);

        // Call 16/18 bit specific conversion method
        return this.Convert(b1, b2, b3);

    }

}
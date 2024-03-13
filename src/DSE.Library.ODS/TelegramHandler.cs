namespace DSE.Library.ODS;


public abstract class TelegramHandler
{

    // Implemented as either 16bit or 18bit in inherited class
    protected abstract uint Convert(uint d1, uint d2, uint d3);
    public abstract bool IsHeader(uint h);

    public uint Process(Queue<uint> readBuffer)
    {

        if (readBuffer.Count < 4)
        {
            return 0;
        }

        var b1 = readBuffer.Dequeue();
        var b2 = readBuffer.Dequeue();
        var b3 = readBuffer.Dequeue();
        //Console.WriteLine("Bytes: " + b1 + ", " + b2 + ", " + b3);

        // Call 16/18 bit specific conversion method
        return this.Convert(b1, b2, b3);

    }

}
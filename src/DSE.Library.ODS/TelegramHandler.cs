using System.Numerics;
using System.Runtime.Intrinsics.X86;

namespace DSE.Library.ODS;

public abstract class TelegramHandler {

    // Implemented as either 16bit or 18bit in inherited class
    abstract protected int convert(int d1, int d2, int d3);
    abstract protected Boolean isHeader(int h);

    public int process(LinkedList<int> readBuffer) {

        if (readBuffer.Count < 4)
        {
            return -1;
        }

        int b1 = readBuffer.First.Value;
        int b2 = readBuffer.First.Value;
        int b3 = readBuffer.First.Value;
        Console.WriteLine("Bytes: " + b1 + ", " + b2 + ", " + b3);

        // Call 16/18 bit specific conversion method
        return convert(b1, b2, b3);

    }

}
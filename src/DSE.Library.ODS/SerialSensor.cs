namespace DSE.Library.ODS;

using System.IO.Ports;

public class SerialSensor : Sensor, IDisposable
{

    private SerialPort? serialPort;
    private Thread? serialReaderThread;
    private bool @continue;



    public SerialPort? GetSerialPort() => this.serialPort;


    public static void PrintSerialPorts()
    {

        var ports = SerialPort.GetPortNames();

        if (ports == null || ports.Length < 1)
        {
            Console.WriteLine("No serial ports found.");
            return;
        }

        foreach (var port in ports)
        {
            Console.WriteLine("Serial port: " + port);
        }

    }


    public static string[] GetSerialPorts()
    {
        var ports = SerialPort.GetPortNames();
        return ports;
    }



    public void OpenPort(string portName, int baudRate)
    {
        // Create a new SerialPort object with default settings.
        this.serialPort = new SerialPort
        {
            // Allow the user to set the appropriate properties.
            PortName = portName,
            BaudRate = baudRate
        };

        this.serialPort.Open();
        this.StartReaderThread();
    }


    public void ClosePort()
    {
        if (this.serialPort != null && this.serialPort.IsOpen)
        {
            this.StopReaderThread();
            this.serialPort.Close();
        }
    }


    private void StartReaderThread()
    {
        this.serialReaderThread = new Thread(new ThreadStart(this.SerialReader));
        this.serialReaderThread.Start();
        this.@continue = true;
    }


    private void StopReaderThread()
    {
        this.@continue = false;
        this.serialReaderThread?.Join();
    }


    private void SerialReader()
    {

        var queue = new Queue<uint>();

        while (this.@continue)
        {
            try
            {
                var b = this.serialPort?.ReadByte();
                if (b == null)
                {
                    continue;
                }

                //Console.WriteLine(b & 0xFF); // NOTE: To get unsigned int !!!
                var i = (uint)(b & 0xFF);
                queue.Enqueue(i);

                // Remove non-header bytes from start of queue
                if (queue.Count > 1 && !this.GetTelegramHandler().IsHeader(queue.Peek()))
                {
                    queue.Dequeue();
                    continue;
                }

                //log.info("Post: " + readBuffer.peek());
                while (queue.Count > 3)
                {
                    var measurement = this.GetTelegramHandler().Process(queue);
                    this.OnMeasurement(measurement);
                    //log.info("Read buffer size: " + readBuffer.size());
                }
            }
            catch (TimeoutException) { }
        }

    }

    public void Dispose()
    {
        this.ClosePort();
        GC.SuppressFinalize(this);
    }

}
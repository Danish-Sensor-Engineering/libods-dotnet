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

        if(ports == null || ports.Length < 1)
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
        if(this.serialPort != null && this.serialPort.IsOpen)
        {
            this.StopReaderThread();
            this.serialPort.Close();
        }
    }


    private void StartReaderThread()
    {

        this.serialReaderThread = new Thread(new ThreadStart(this.SerialReader));
        //serialReaderThread = new Thread(SerialReader);
        //serialReaderThread.setSerialPort(_serialPort)
        this.serialReaderThread.Start();


        this.OnMeasurementReceived(25);
        this.OnMeasurementReceived(26);
        this.OnMeasurementReceived(27);
        this.@continue = true;

    }


    private void StopReaderThread()
    {
        this.@continue = false;
        this.serialReaderThread?.Join();
    }


    private void SerialReader()
    {

        while (this.@continue)
        {
            try
            {
                var message = this.serialPort?.ReadLine();
                Console.WriteLine(message);
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
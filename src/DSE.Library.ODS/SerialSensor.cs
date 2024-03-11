namespace DSE.Library.ODS;

using System.IO.Ports;

public class SerialSensor : Sensor {


    private SerialPort? _serialPort;
    private Thread serialReaderThread;
    private bool _continue = false;



    public SerialPort? getSerialPort()
    {
        if(_serialPort != null) {
            return _serialPort;
        } else {
            return null;
        }

    }


    public static void printSerialPorts()
    {

        string[] ports = SerialPort.GetPortNames();

        if(ports.Length < 1) {
            Console.WriteLine("No serial ports found.");
        }

        foreach (string port in ports)
        {
            Console.WriteLine("Serial port: " + port);
        }

    }


    public static String[] getSerialPorts()
    {
        string[] ports = SerialPort.GetPortNames();
        return ports;
    }



    public void openPort(String portName, int baudRate)
    {
        // Create a new SerialPort object with default settings.
        _serialPort = new SerialPort();

        // Allow the user to set the appropriate properties.
        _serialPort.PortName = portName;
        _serialPort.BaudRate = baudRate;

        _serialPort.Open();
        startReaderThread();
    }


    public void closePort()
    {
        if(_serialPort != null && _serialPort.IsOpen) {
            stopReaderThread();
            _serialPort.Close();
        }
    }


    private void startReaderThread() {

        serialReaderThread = new Thread(new ThreadStart(SerialReader));
        //serialReaderThread = new Thread(SerialReader);
        //serialReaderThread.setSerialPort(_serialPort)
        serialReaderThread.Start();


        OnMeasurementReceived(25);
        OnMeasurementReceived(26);
        OnMeasurementReceived(27);
        _continue = true;

    }


    private void stopReaderThread() {
        _continue = false;
        serialReaderThread.Join();
    }


    private void SerialReader() {

        while (_continue)
        {
            try
            {
                string message = _serialPort.ReadLine();
                Console.WriteLine(message);
            }
            catch (TimeoutException) { }
        }

    }


}
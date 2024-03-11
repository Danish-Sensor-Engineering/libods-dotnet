namespace DSE.Library.ODS;

using System.IO.Ports;

public class SerialSensor : Sensor {


    /**
     * Serial Port Setup
     */

    static SerialPort? _serialPort;



    public SerialPort? getSerialPort()
    {
        if(_serialPort != null) {
            return _serialPort;
        } else {
            return null;
        }

    }


    //private Thread readerThread;
    //private SerialReader serialReader;

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

        if (_serialPort != null && _serialPort.IsOpen)
        {
            /*
            serialReader = new SerialReader(this);
            serialReader.start();
            readerThread = new Thread(serialReader);
            readerThread.start();
            */

            OnMeasurementReceived(25);
            OnMeasurementReceived(26);
            OnMeasurementReceived(27);

        }
    }


    private void stopReaderThread() {

        /*
        if (_serialPort != null && _serialPort.isOpen)
        {
            serialReader.stop();
            try
            {
                readerThread.join();
            }
            catch (InterruptedException e)
            {
                e.printStackTrace();
            }
        }
        */
    }


}
using DSE.Library.ODS;

/**
    This is an example program that used the ODS library
    to setup an event listener to receive measurements.
*/

internal sealed class Program
{

    public static void Main()
    {
        Console.WriteLine("Test Program - DSE ODS Library for .net");

        // Print available ports
        var ports = SerialSensor.GetSerialPorts();
        if (ports.Length < 1)
        {
            Console.WriteLine("No serial ports found.");
            Environment.Exit(-1);
        }


        // Ask user for port to use
        foreach (var p in ports)
        {
            Console.WriteLine("Serial port: " + p);
        }
        Console.Write("Please enter port name to use: ");
        var port = Console.ReadLine();
        //var port = "/dev/ttyUSB0";

        SerialSensor sensor = new();
        sensor.SetTelegramHandler(new TelegramHandler18Bit());  // Or TelegramHandler16Bit()

        // Register our event handler
        sensor.MeasurementReceived += OnEvent; // register with an event

        // This can throw error
        if (port != null)
        {
            Console.WriteLine("Running for 5 seconds ...");
            sensor.OpenPort(port, 115200);

            // TODO: Sleep some time
            Thread.Sleep(5000);

            sensor.ClosePort();
        }

    }


    // event handler
    public static void OnEvent(object sender, uint measurement)
    {
        // TODO: Business logic for measurements
        Console.WriteLine("Measurement Event: " + measurement);
    }


}

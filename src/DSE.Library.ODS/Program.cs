using DSE.Library.ODS;

internal class Program
{

    public static void Main()
    {
        // Foo
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
        //Console.Write("Please enter port name to use: ");
        //var port = Console.ReadLine();
        var port = "/dev/ttyUSB0";

        SerialSensor sensor = new();
        sensor.SetTelegramHandler(new TelegramHandler18Bit());  // Or TelegramHandler16Bit()


        // Register our event handler
        sensor.MeasurementReceived += OnEvent; // register with an event

        // This can throw error
        if (port != null)
        {
            sensor.OpenPort(port, 115200);

            // TODO: Sleep some time

            sensor.ClosePort();
        }

        // Done.
    }


    // event handler
    public static void OnEvent(object sender, uint measurement)
    {
        // TODO: Do something with measurement result
        Console.WriteLine("Measurement Event: " + measurement);
    }


}

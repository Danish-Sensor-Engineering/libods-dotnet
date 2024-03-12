using DSE.Library.ODS;

internal class Program
{

    public static void Main()
    {
        // Foo
        Console.WriteLine("Test Program - DSE Library ODS");


        // Print available ports
        var ports = SerialSensor.GetSerialPorts();
        if (ports.Length < 1)
        {
            Console.WriteLine("No serial ports found.");
            System.Environment.Exit(-1);
        }


        // Ask user for port to use
        foreach (var p in ports)
        {
            Console.WriteLine("Serial port: " + p);
        }
        Console.Write("Please enter port name to use: ");
        var port = Console.ReadLine();


        SerialSensor sensor = new();
        sensor.SetTelegramHandler(new TelegramHandler16Bit());


        // Register our event handler
        sensor.MeasurementReceived += OnEvent; // register with an event

        // This can throw error
        if(port != null)
        {
            sensor.OpenPort(port, 115200);

            // TODO: Sleep some time

            sensor.ClosePort();
        }

        // Done.
    }


    // event handler
    public static void OnEvent(object sender, int measurement)
    {
        Console.WriteLine("Measurement Event: " + measurement);
    }


}

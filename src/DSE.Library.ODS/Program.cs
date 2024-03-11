using System;
using DSE.Library.ODS;

class Program {


    public static void Main()
    {
        // Foo
        Console.WriteLine("Test Program - DSE Library ODS");


        // Print available ports
        string[] ports = SerialSensor.getSerialPorts();
        if (ports.Length < 1)
        {
            Console.WriteLine("No serial ports found.");
            System.Environment.Exit(-1);
        }

        // Ask user for port to use
        foreach (string p in ports)
        {
            Console.WriteLine("Serial port: " + p);
        }
        Console.Write("Please enter port name to use: ");
        string port = Console.ReadLine();

        SerialSensor sensor = new();
        sensor.setTelegramHandler(new TelegramHandler16Bit());

        // Register our event handler
        sensor.MeasurementReceived += onEvent; // register with an event

        // This can throw error
        sensor.openPort(port, 115200);


        sensor.closePort();

        // Done.
    }


    // event handler
    public static void onEvent(object sender, int Measurement)
    {
        Console.WriteLine("Measurement: " + Measurement);
    }

}

using System;
using DSE.Library.ODS;

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

// This can throw error
sensor.openPort(port, 115200);

// TODO: Start and read measurements for x time

sensor.closePort();

// Done.
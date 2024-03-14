DSE ODS .NET Library
--------------------

.NET library for communicating with, and decoding measurement telegrams from Optical Displacement Sensors (ODS) made by [Danish Sensor Engineering](https://www.danish-sensor-engineering.com) (DSE).


## Build & Release


```shell
dotnet build --configuration Releas
dotnet pack --configuration Release
```

Publish to Github (not working yet), example.

```shell
dotnet nuget push "bin/Release/DSE.Library.ODS.0.0.1.nupkg" --source "github"
```


## Example Usage

```c#
using DSE.Library.ODS;

internal sealed class Program
{

    public static void Main()
    {

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
        sensor.SetTelegramHandler(new TelegramHandler18Bit());  
        // Or TelegramHandler16Bit() depending on Sensor model

        // Register our event handler
        sensor.MeasurementReceived += OnEvent;

        // This can throw error
        if (port != null)
        {
            Console.WriteLine("Running for 5 seconds ...");
            sensor.OpenPort(port, 115200);

            // TODO: Sleep some time while we recieve measurement events
            Thread.Sleep(5000);

            sensor.ClosePort();
        }

    }


    // Our event handler
    public static void OnEvent(object sender, uint measurement)
    {
        // TODO: Business logic for measurements
        Console.WriteLine("Measurement Event: " + measurement);
    }


}
```
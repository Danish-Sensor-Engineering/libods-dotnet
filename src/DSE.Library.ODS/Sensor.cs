namespace DSE.Library.ODS;


public class Sensor
{

    /**
     * Various Configurable Options
     */

    private uint doAverageOver = 10;


    /**
     * Private Fields
     */

    private uint avgIntCounter;
    private uint[] avgIntArray = new uint[10]; // Array.Empty<uint>();


    /**
     *  Telegram Handler Setup
     */

    private TelegramHandler? telegramHandler;

    public void SetTelegramHandler(TelegramHandler telegramHandler) => this.telegramHandler = telegramHandler;

    public TelegramHandler? GetTelegramHandler() => this.telegramHandler;

    public void SetAverage(uint avg)
    {
        this.doAverageOver = avg;
        this.avgIntArray = new uint[avg];
        this.avgIntCounter = 0;
    }


    /**
     * Event Handling
     */

    public event EventHandler<uint>? MeasurementReceived;

    protected virtual void OnMeasurementReceived(uint measurement) => MeasurementReceived?.Invoke(this, measurement);


    /**
     * Measurement Handling
     */


    protected void Clear()
    {
        this.avgIntCounter = 0;
        this.avgIntArray = new uint[this.doAverageOver];
    }


    protected virtual void OnMeasurement(uint measurement)
    {

        if (measurement < 99)
        {
            //sendError(measurement);
            Console.WriteLine("Error: " + measurement);
            return;
        }

        if (this.doAverageOver > 0)
        {
            //log.info("Adding to avg. buffer: " + measurement);
            this.avgIntArray[this.avgIntCounter] = measurement;
            this.avgIntCounter++;
        }
        else
        {
            //log.info("Send event: " + measurement);
            Console.WriteLine("Measurement: " + measurement);
            //sendEvent(measurement);
            this.OnMeasurementReceived(measurement);
        }

        if (this.doAverageOver > 0 && this.avgIntCounter >= this.avgIntArray.Length)
        {
            this.avgIntCounter = 0;
            var avg = DoAverage(this.avgIntArray);
            //log.info("Send event: " + avg.intValue());
            this.OnMeasurementReceived(avg);
            Console.WriteLine("Avg. Measurement: " + avg);

        }

    }


    private static uint DoAverage(uint[] input)
    {
        uint sum = 0;
        for (uint i = 0; i < input.Length; i++)
        {
            sum += input[i];
        }

        return (uint)(sum / input.Length);
    }

}

namespace DSE.Library.ODS;


public class Sensor
{

    /**
     * Various Configurable Options
     */

    private int doAverageOver = 10;


    /**
     * Private Fields
     */

    private int avgIntCounter;
    private int[] avgIntArray = Array.Empty<int>();


    /**
     *  Telegram Handler Setup
     */

    private TelegramHandler? telegramHandler;

    public void SetTelegramHandler(TelegramHandler telegramHandler) => this.telegramHandler = telegramHandler;

    public TelegramHandler? GetTelegramHandler() => this.telegramHandler;

    public void SetAverage(int avg) => this.doAverageOver = avg;


    /**
     * Event Handling
     */

    public event EventHandler<int>? MeasurementReceived;

    protected virtual void OnMeasurementReceived(int measurement) => MeasurementReceived?.Invoke(this, measurement);


    /**
     * Measurement Handling
     */


    protected void Clear()
    {
        this.avgIntCounter = 0;
        this.avgIntArray = new int[this.doAverageOver];
    }


    protected virtual void OnMeasurement(int measurement)
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
            var avg = this.avgIntArray.Average();
            //log.info("Send event: " + avg.intValue());
            this.OnMeasurementReceived((int)avg);
            Console.WriteLine("Avg. Measurement: " + avg);

        }

    }

}

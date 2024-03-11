namespace DSE.Library.ODS;



public class Sensor
{

    /**
     * Various Configurable Options
     */

    public int doAverageOver = 10;

    

    /**
     * Private Fields
     */

    private int avgIntCounter;
    private int[] avgIntArray;


    /**
     *  Telegram Handler Setup
     */
    protected TelegramHandler? telegramHandler;

    public void setTelegramHandler(TelegramHandler telegramHandler)
    {
        this.telegramHandler = telegramHandler;
    }

    public TelegramHandler getTelegramHandler()
    {
        return telegramHandler;
    }




    /**
     * Event Handling
     */

    
    public event EventHandler<int>? MeasurementReceived; 


    protected virtual void OnMeasurementReceived(int Measurement)
    {
        MeasurementReceived?.Invoke(this, Measurement);
    }



    /**
     * Measurement Handling
     */


    protected void clear()
    {
        avgIntCounter = 0;
        avgIntArray = new int[this.doAverageOver];
    }


    protected virtual void onMeasurement(int measurement)
    {

        if (measurement < 99)
        {
            //sendError(measurement);
            Console.WriteLine("Error: " + measurement);
            return;
        }

        if (doAverageOver > 0)
        {
            //log.info("Adding to avg. buffer: " + measurement);
            avgIntArray[avgIntCounter] = measurement;
            avgIntCounter++;
        }
        else
        {
            //log.info("Send event: " + measurement);
            Console.WriteLine("Measurement: " + measurement);
            //sendEvent(measurement);
            OnMeasurementReceived(measurement);
        }

        if (doAverageOver > 0 && avgIntCounter >= avgIntArray.Length)
        {
            avgIntCounter = 0;
            double avg = avgIntArray.Average();
            //log.info("Send event: " + avg.intValue());
            //sendEvent((int)avg);
            OnMeasurementReceived((int)avg); 
            Console.WriteLine("Avg. Measurement: " + avg);

        }

    }

}

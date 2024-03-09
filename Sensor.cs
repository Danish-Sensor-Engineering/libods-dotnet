namespace DSE.Library.ODS;

using System.Collections;


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
     * Event Listener Configuration
     */

/*
    private List<TelegramListener> eventListeners = new List<TelegramListener>();


    public void addEventListener(TelegramListener l)
    {
        eventListeners.Add(l);
    }

    public void removeEventListener(TelegramListener l)
    {
        eventListeners.Remove(l);
    }
*/



    /**
     * Measurement Handling
     */


    protected void clear()
    {
        avgIntCounter = 0;
        avgIntArray = new int[this.doAverageOver];
    }


    protected void onMeasurement(int measurement)
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
        }

        if (doAverageOver > 0 && avgIntCounter >= avgIntArray.Length)
        {
            avgIntCounter = 0;
            double avg = avgIntArray.Average();
            //log.info("Send event: " + avg.intValue());
            //sendEvent((int)avg);
            Console.WriteLine("Avg. Measurement: " + avg);

        }

    }

}

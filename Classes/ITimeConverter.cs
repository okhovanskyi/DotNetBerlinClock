namespace BerlinClock
{
    public interface ITimeConverter
    {
        string convertTime(string aTime);
        string ConvertSeconds(int secondsStringRepresentstion);
        string ConvertMinutes(int minutesStringRepresentstion);
        string ConvertHours(int hoursStringRepresentstion);
    }
}

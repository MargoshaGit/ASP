namespace ASP_MVC_PROJ.Models
{
    public class WeatherData
    {
        public List<WeatherItem> Items { get; set; }
    }

    public class WeatherItem
    {
        public DateTime Date { get; set; }
       
        public TemperatureDetails Temperature { get; set; }
    }


    public class TemperatureDetails
    {
        public int Avg { get; set; }
    }
}

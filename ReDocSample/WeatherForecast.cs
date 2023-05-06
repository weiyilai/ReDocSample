namespace ReDocSample
{
    /// <summary>
    /// Weather Forecast
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// ���
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// ���
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// �ؤ�
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// �K�n
        /// </summary>
        public string? Summary { get; set; }
    }
}
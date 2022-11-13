namespace HomeWorCore_MVC_DataBase.Models
{
    public class Sensors
    {
        public int ID { get; set; }
        public decimal Temp_Sensor { get; set; }
        public decimal Humid_Sensor { get; set; }
        public bool Motion_Sensor { get; set; }
        public int Light_Sensor { get; set; }

        public int CO_Sensor { get; set; }

        public DateTime Data_Time { get; set; }
    }
}
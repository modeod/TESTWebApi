using System.ComponentModel.DataAnnotations;

namespace TESTDBAccessLib.Models
{
    public class CurrentWeatherModel
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public float Temp { get; set; }
        public float MinTemp { get; set; }
        public float MaxTemp { get; set; }

    }
}

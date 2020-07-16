using System;

namespace BlazorAppDemo2.Servicio
{
    public class Weather
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public int Grade { get; set; }

        public string Summary { get; set; }
    }
}
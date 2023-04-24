using System;

namespace api_SIF.Clases
{
    public class Funciones
    {
        public static string HoraAString(TimeOnly hora)
        {
            return hora.ToString("HH:mm:ss");
        }
    }
}

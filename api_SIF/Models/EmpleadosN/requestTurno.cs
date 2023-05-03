using System;

namespace api_SIF.Models.EmpleadosN
{
    public class requestTurno
    {
        public int id_turno { get; set; }
        public int disponible { get; set; }

        public string turno { get; set; }
       
        public string entrada { get; set; }
       
        public string salida { get; set; }
        
        public int horas { get; set; }
       
        public string entradaF { get; set; }
        
        public string salidaF { get; set; }
        
        public int horasF { get; set; }
      
        public string descanso { get; set; }
       
        public string comida { get; set; }
        public double horas_trabajadas { get; set; }
       
        public int nocturno { get; set; }
    }
}

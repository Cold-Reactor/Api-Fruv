using System;

namespace api_SIF.Models.EmpleadosN
{
    public class requestTurno
    {
        public int id_turno { get; set; }
       
        public string turno { get; set; }
       
        public TimeOnly entrada { get; set; }
       
        public TimeOnly salida { get; set; }
        
        public int horas { get; set; }
       
        public TimeOnly entradaF { get; set; }
        
        public TimeOnly salidaF { get; set; }
        
        public int horasF { get; set; }
      
        public string descanso { get; set; }
       
        public TimeOnly comida { get; set; }
        public double horas_trabajadas { get; set; }
       
        public int nocturno { get; set; }
    }
}

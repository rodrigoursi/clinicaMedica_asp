using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Horarios
    {
        public int id { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFin { get; set; }
        public Turno turnoAsociado { get; set; }
        public Horarios() { }
        public Horarios(DateTime inicio)
        {
            this.horaInicio = inicio;
            this.horaFin = horaInicio.AddHours(1);
        }
    }
}

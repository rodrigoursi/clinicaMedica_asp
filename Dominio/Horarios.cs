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
        public Usuario idMedico { get; set; }
        public DiaSemana idDia { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFin { get; set; }
        public Turno turnoAsociado { get; set; }
        public Horarios()
        {
            idMedico = new Usuario();
            idDia = new DiaSemana();
        }
        public Horarios(DateTime inicio)
        {
            this.horaInicio = inicio;
            this.horaFin = horaInicio.AddHours(1);
        }

    }
}

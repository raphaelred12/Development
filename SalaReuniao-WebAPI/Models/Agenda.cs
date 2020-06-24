using System.Collections.Generic;

namespace SalaReuniao_WebAPI.Models
{
    public class Agenda
    {
        public Agenda()
        {

        }
        public Agenda(int id, string titulo, string data, string horaInicio, string horaFim, int salaId)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Data = data;
            this.HoraInicio = horaInicio;
            this.HoraFim = horaFim;
            this.SalaId = salaId;
        }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Data { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public int SalaId { get; set; }
        public Sala Sala { get; set; }
    }
}
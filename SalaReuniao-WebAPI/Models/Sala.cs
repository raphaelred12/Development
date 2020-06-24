using System.Collections.Generic;

namespace SalaReuniao_WebAPI.Models
{
    public class Sala
    {
        public Sala()
        {

        }
        public Sala(int id, string descricao, int capacidade)
        {
            this.id = id;
            this.descricao = descricao;
            this.capacidade = capacidade;

        }
        public int id { get; set; }
        public string descricao { get; set; }
        public int capacidade { get; set; }
        public IEnumerable<Agenda> Agenda { get; set; }
    }
}
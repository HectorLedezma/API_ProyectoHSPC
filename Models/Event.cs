using System.Text.Json;

public class Event
    {
        public Ticket? Ticket_paciente { get; set; }
        public Estado? Estado { get; set; }
        public Especialista? Especialista { get; set; }
        public Modulo? Modulo { get; set; }
        public Department? Depto { get; set; }
        public DateTime cambio { get; set; }
    }
namespace MauiAppHotel.Models
{
    public class Evento
    {
        public string Nome { get; set; } = string.Empty;
        public string Local { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int NumeroParticipantes { get; set; }
        public double CustoPorParticipante { get; set; }

        public int DuracaoEmDias => (DataTermino - DataInicio).Days;

        public double CustoTotal => NumeroParticipantes * CustoPorParticipante * (DuracaoEmDias > 0 ? DuracaoEmDias : 1);
    }
}
using ClubeLeitura.ConsoleApp.Dominio;
using ClubeLeitura.ConsoleApp.Dominio.Base;

namespace ClubeDaLeitura.ConsoleApp.Dominio;

public class Reserva : EntidadeBase
{
    public Revista Revista { get; set; }
    public Amigo Amigo { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataConclusao { get; set; }
    public StatusReserva Status { get; set; }

    public Reserva(Revista revista, Amigo amigo)
    {
        Revista = revista;
        Amigo = amigo;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (Amigo == null)
            erros += "O campo \"Amigo\" é obrigatório;";

        if (Revista == null)
            erros += "O campo \"Revista\" é obrigatório;";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }

    public override void Atualizar(EntidadeBase registroAtualizado)
    {
        Reserva reservaAtualizada = (Reserva)registroAtualizado;

        Amigo = reservaAtualizada.Amigo;
        Revista = reservaAtualizada.Revista;
    }

    public void IniciarReserva()
    {
        Revista.Reservar();

        DataInicio = DateTime.Now;
        Status = StatusReserva.Ativa;
    }

    public void ConcluirReserva()
    {
        Revista.Devolver();

        DataConclusao = DateTime.Now;
        Status = StatusReserva.Concluida;
    }
}
namespace ClubeLeitura.ConsoleApp.Dominio;

public class Caixa
{
    public string Etiqueta { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public int DiasEmprestimo { get; set; } = 7;

    public Caixa(string etiqueta, string cor, int diasEmprestimo = 7)
    {
        Etiqueta = etiqueta;
        Cor = cor;
        DiasEmprestimo = diasEmprestimo;
    }
}
using ClubeLeitura.ConsoleApp.Dominio;

namespace ClubeLeitura.ConsoleApp.Intraestrutura;

public abstract class RepositorioBase
{
    protected EntidadeBase?[] registros = new EntidadeBase[100];
}
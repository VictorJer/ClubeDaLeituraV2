using System.Security.Cryptography;

namespace ClubeLeitura.ConsoleApp.Dominio.Base;

public abstract class EntidadeBase
{
    public string Id { get; set; }

    public EntidadeBase()
    {
        Id = Convert
            .ToHexString(RandomNumberGenerator.GetBytes(20))
            .ToLower()
            .Substring(0, 7);
    }

    public abstract void Atualizar(EntidadeBase entidadeAtualizada);
    public abstract string[] Validar();

}
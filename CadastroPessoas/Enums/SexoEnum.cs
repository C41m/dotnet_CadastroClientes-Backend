using System.Text.Json.Serialization;

namespace CadastroPessoas.Enums
{

    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum SexoEnum
    {
        Masculino,
        Feminino,
        Outro
    }
}

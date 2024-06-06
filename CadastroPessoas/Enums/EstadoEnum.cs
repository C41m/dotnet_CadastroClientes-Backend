using System.Text.Json.Serialization;

namespace CadastroPessoas.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EstadoEnum
    {
        AC,
        AL,
        AP,
        AM,
        BA,
        CE,
        ES,
        GO,
        MA,
        MT,
        MS,
        MG,
        PA,
        PB,
        PR,
        PE,
        PI,
        RJ,
        RN,
        RS,
        RO,
        RR,
        SC,
        SP,
        SE,
        TO
    }
}

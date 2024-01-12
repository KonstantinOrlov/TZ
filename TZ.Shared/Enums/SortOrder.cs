using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TZ.Shared.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SortOrder : byte
    {
        [EnumMember(Value = "ASC")]
        ASC,
        [EnumMember(Value = "DESC")]
        DESC
    }
}

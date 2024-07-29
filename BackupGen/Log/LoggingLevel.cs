using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BackupGen.Settings;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LoggingLevel
{
    [EnumMember(Value = "Error")]
    Error, 
    [EnumMember(Value = "Info")]
    Info, 
    [EnumMember(Value = "Debug")]
    Debug
}
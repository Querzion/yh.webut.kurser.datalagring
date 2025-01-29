using System.Text.Json;

namespace Business.Helpers;

public static class CustomJsonSerializerOptions
{
    public static readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true,
        ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
    };
}
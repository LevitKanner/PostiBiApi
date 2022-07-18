namespace Api.Entities.Settings;

public class JwtSettings
{
    public string? ValidIssuer { get; set; }
    public string? ValidAudience { get; set; }
}
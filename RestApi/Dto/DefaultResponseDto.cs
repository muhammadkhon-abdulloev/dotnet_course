namespace RestApi.Dto;

public class DefaultResponseDto
{
    public bool Ok { get; set; }
    public string? Comment { get; set; }
    public object? Data { get; set; }
}
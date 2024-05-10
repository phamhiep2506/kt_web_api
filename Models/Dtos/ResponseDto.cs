namespace Models.Dtos;

public class ResponseDto<T>
{
    public string? status { get; set; }
    public string? message { get; set; }
    public List<T>? items { get; set; }
}

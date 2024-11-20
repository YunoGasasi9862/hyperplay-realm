using BLL.Enums;

public interface IResult
{
    public string? Message { get; set; }

    public bool IsSuccessfull { get; set; }
    public void SetResultMessage(ResultEnum result, bool isSuccessful);
}
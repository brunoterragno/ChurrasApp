namespace Churras.Domain.Models
{
  public enum ErrorResultType
  {
    invalid_parameter,
    not_found,
    server_error
  }

  public class ValidationError
  {
    public ErrorResultType Type { get; set; }

    public string Field { get; set; }

    public string Message { get; set; }

    public ValidationError() { }

    public ValidationError(string field, string message, ErrorResultType type)
    {
      this.Field = field;
      this.Message = message;
      this.Type = type;
    }
  }
}
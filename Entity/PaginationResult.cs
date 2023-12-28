namespace webapi_test.Entity;

public class PaginationResult<T>
{
    public IEnumerable<T>? List { get; set; }
    
    public int Total { get; set; }
}
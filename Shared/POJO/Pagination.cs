namespace Shared.POJO;

public interface IPagination
{
    public int skip { get; set; }
    public int limit { get; set; }
    public string sortBy { get; set; }
    public string sortDir { get; set; }
    public int getPageStart();
    public int getPageEnd();
}
public class Pagination
{
    public int skip { get; set; }
    public int limit { get; set; }
    public string sortBy { get; set; }
    public string sortDir { get; set; }
    public int getPageEnd()
    {
        return skip * limit;
    }
    public int getPageStart()
    {
        var page =  (skip - 1) * limit;
        return page;
    }
    
}
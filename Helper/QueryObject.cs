namespace morningclassonapi.Helper
{
    public class QueryObject
    {

        //filtering
        public string? Symbol { get; set; }
        public string? CompanyName { get; set; }

        //sorting
        public string? SortBy { get; set; }

        public bool isDescending { get; set; } = false;

        //paginantion
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10000;

    }
}

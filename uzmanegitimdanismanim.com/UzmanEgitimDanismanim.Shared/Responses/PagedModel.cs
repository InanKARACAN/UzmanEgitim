namespace UzmanEgitimDanismanim.Shared.Responses
{
    public class PagedModel<TModel>
    {
        const int MaxPageSize = 500;
        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int PageStart
        {
            get { return ((CurrentPage - 1) * PageSize + 1); }
        }
        //last item number in the page
        public int PageEnd
        {
            get
            {
                int currentTotal = (CurrentPage - 1) * PageSize + PageSize;
                return (currentTotal < TotalItems ? currentTotal : TotalItems);
            }
        }
        public int LastPage
        {
            get
            {
                if (PageSize != 0)
                    return (int)Math.Ceiling((decimal)TotalItems / PageSize);
                return 0;
            }
        }
        public IList<TModel> Items { get; set; }

        public PagedModel()
        {
            Items = new List<TModel>();
        }
    }
}
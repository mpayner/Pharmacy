using Pharmacy.Data.Repository;
using System.Runtime.InteropServices;

namespace Pharmacy.Data.Utils
{
    public class Pagination
    {
        public readonly int CurPage;
        public readonly int ItemsCount;
        public readonly int ItemsPerPage;
        public readonly int PagesBefore;
        public readonly int PagesAfter;
      

        public Pagination(int CurPage,int ItemsCount,int ItemsPerPage, int PagesBefore, int PagesAfter)
        {

            this.CurPage = CurPage;
			this.ItemsCount = ItemsCount;
            this.ItemsPerPage = ItemsPerPage;
			this.PagesBefore = PagesBefore;
			this.PagesAfter = PagesAfter;
        }
        
        public int NumberOfPages()
        {
            return (int)Math.Ceiling((double)ItemsCount / (double)ItemsPerPage);
        }

        public int StartPage()
        {
            return Math.Max(1, CurPage - PagesBefore);

        }

        public int EndPage()
        {
            return Math.Min(NumberOfPages(), CurPage + PagesAfter);

        }

    }
}

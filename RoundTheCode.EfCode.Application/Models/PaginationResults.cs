

namespace RoundTheCode.EFCore.Application.Models
{
    public class PaginationResults<TModel>
    {
        public PaginationResults(List<TModel>? results, int take, int totalResultsCount) {

            Results = results;
            TotalResultsCount = totalResultsCount;

            if(TotalResultsCount == 0 || take == 0)
             {   TotalPageCount = 0;
                return;
            }
            TotalPageCount = (int)Math.Ceiling((decimal)TotalResultsCount/take);
        
        }
        public List<TModel>? Results { get; }

        public int TotalResultsCount { get; }

        public int TotalPageCount { get; }
    }
}

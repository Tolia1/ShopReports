using System.Collections.ObjectModel;

namespace ShopReports.Reports
{
    public abstract class ReportBase<T>
        where T : class
    {
        private readonly IReadOnlyList<T> lines;

        protected ReportBase(IList<T> lines, DateTime reportGenerationDate)
        {
            this.lines = new ReadOnlyCollection<T>(lines);
            this.ReportGenerationDate = reportGenerationDate;
        }

        public IReadOnlyList<T> Lines { get => this.lines; }

        public int LinesCount { get => this.lines.Count; }

        public DateTime ReportGenerationDate { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_18
{
    public class Journal
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }
        public int PageCount { get; set; }
    }

    public class JournalWithArticles : Journal
    {
        public List<Article> Articles { get; set; }
    }
}

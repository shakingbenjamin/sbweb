namespace sbweb.Umbraco.Models.ViewModels
{
    using System.Collections.Generic;

    public class LatestBlogViewModel
    {
        public string Header { get; set; }
        public string Introduction { get; set; }
        public List<ArticleViewModel> Articles { get; set; }
    }
}
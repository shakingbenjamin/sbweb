using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sbweb.Umbraco.Models.ViewModels
{
    public class ArticleViewModel
    {
        public string Header { get; set; }
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        public string ArticleUrl { get; set; }
        public string Category { get; set; }
        public string CategoryUrl { get; set; }
        public string Author { get; set; }
        public string PublishedDate { get; set; }
    }
}
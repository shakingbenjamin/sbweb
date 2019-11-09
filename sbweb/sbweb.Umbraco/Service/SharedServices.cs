namespace sbweb.Umbraco.Service
{
    using global::Umbraco.Core.Models.PublishedContent;
    using global::Umbraco.Web;
    using sbweb.Umbraco.Interface;
    using sbweb.Umbraco.Models.ViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using Web.Models.ContentModels;

    public class SharedServices : ISharedService
    {
        public List<ArticleViewModel> GetLatestBlogPosts(IPublishedContent content)
        {
            var latestBlogPosts = new List<ArticleViewModel>();
            var home = content.AncestorOrSelf(1);
            var blogs = home.Children.Where(x => x.IsDocumentType("blog"));
            var articles = new List<Article>();

            foreach (var b in blogs)
            {
                var allArticles = b.Children.Where(x => x.IsDocumentType("article")).ToList();

                foreach (var a in allArticles)
                {
                    articles.Add(new Article(a));
                }
            }

            articles = articles.GroupBy(a => a.PublishedDate).SelectMany(group => group.Take(3)).ToList();

            if (articles == null)
            {
                return latestBlogPosts;
            }

            foreach (var a in articles)
            {
                var blogPost = new ArticleViewModel
                {
                    Header = a.Title,
                    ShortDescription = a.ShortDescription,
                    ArticleUrl = a.Url,
                    Image = a.Image == null ? string.Empty : a.Image.Url,
                    PublishedDate = a.PublishedDate.ToString("MMMM, dd yyyy"),
                    Author = a.CreatorName,
                    Category = a.Parent.Name,
                    CategoryUrl = a.Parent.Url
                };
                latestBlogPosts.Add(blogPost);
            }
            
            return latestBlogPosts;
        }

        public HeroBannerViewModel GetHeroBanner(IPublishedContent content)
        {
            var heroBanner = new HeroBanner(content);
            return new HeroBannerViewModel
            {
                ImageUrl = heroBanner.HeroImage != null ? heroBanner.HeroImage.Url : string.Empty,
                HeaderText = heroBanner.PageTitle
            };
        }
    }
}
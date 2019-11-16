namespace sbweb.Umbraco.Interface
{
    using sbweb.Umbraco.Models.ViewModels;
    using System.Collections.Generic;
    using global::Umbraco.Core.Models.PublishedContent;

    public interface ISharedService
    {
        List<NavigationMenuViewModel> GetMenuItems(IPublishedContent content);
        LatestBlogViewModel GetLatestBlogPosts(IPublishedContent content);
        HeroBannerViewModel GetHeroBanner(IPublishedContent content);
        List<ArticleViewModel> GetBlogPostsByCategory(IPublishedContent content);
    }
}
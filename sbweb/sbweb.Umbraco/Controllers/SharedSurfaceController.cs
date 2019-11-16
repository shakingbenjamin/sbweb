using sbweb.Umbraco.Interface;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace sbweb.Umbraco.Controllers
{
    public class SharedSurfaceController : SurfaceController
    {
        private readonly ISharedService _sharedService;

        public SharedSurfaceController(ISharedService sharedService)
        {
            _sharedService = sharedService;
        }

        public ActionResult RenderNavigation()
        {
            var menu = this._sharedService.GetMenuItems(this.CurrentPage);
            return PartialView("~/Views/Partials/Shared/Navigation.cshtml", menu);
        }

        public ActionResult RenderHeroBanner()
        {
            var hero = this._sharedService.GetHeroBanner(this.CurrentPage);
            return PartialView("~/Views/Partials/Shared/HeroBanner.cshtml", hero);
        }

        public ActionResult RenderLatestPosts()
        {
            // create sservice to sift through the latest posts from all three blogs
            var latestBlogPosts = this._sharedService.GetLatestBlogPosts(this.CurrentPage);
            return PartialView("~/Views/Partials/Shared/LatestPosts.cshtml", latestBlogPosts);
        }

        public ActionResult RenderBlogPostsByCategory()
        {
            var posts = this._sharedService.GetBlogPostsByCategory(this.CurrentPage);
            return PartialView("~/Views/Partials/Shared/PostsByCategory.cshtml", posts);
        }

        public ActionResult RenderFooter()
        {
            return PartialView("~/Views/Partials/Shared/Footer.cshtml");
        }
    }
}
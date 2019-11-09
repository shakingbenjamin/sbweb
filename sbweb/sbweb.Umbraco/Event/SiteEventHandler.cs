namespace sbweb.Umbraco.Event
{
    using global::Umbraco.Core;
    using global::Umbraco.Core.Composing;
    using sbweb.Umbraco.Interface;
    using sbweb.Umbraco.Service;

    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class SiteComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<ISharedService, SharedServices>();
            //composition.Register<IGenericControlsService, GenericControlsService>();
            //composition.Register<IDestinationsControlsService, DestinationsControlService>();
            //composition.Register<IUmbracoHelperWrapper, UmbracoHelperWrapper>();
        }
    }

    public class MyComponent : IComponent
    {
        public void Initialize()
        {
        }

        public void Terminate()
        {
        }
    }
}
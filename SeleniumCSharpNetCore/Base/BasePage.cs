namespace SeleniumCSharpNetCore.Base
{
    public abstract class BasePage:Base
    {
        public BasePage()
        {
        }
        private IWebDriver Driver { get; set; }
        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            TPage pageInstance = new TPage()
            {
                Driver = DriverContext.Driver
            };

            return pageInstance;
        }
        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}

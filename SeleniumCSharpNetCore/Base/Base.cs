namespace SeleniumCSharpNetCore.Base
{
    public class Base
    {
        public BasePage CurrentPage { get; set; }

        //private IWebDriver Driver { get; set; }

        //protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        //{
        //    TPage pageInstance = new TPage()
        //    {
        //        Driver = DriverContext.Driver
        //    };

        //    return pageInstance;
        //}

        //public TPage As<TPage>() where TPage : BasePage
        //{
        //    return (TPage)this;
        //}
    }
}

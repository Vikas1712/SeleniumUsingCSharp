namespace SeleniumCSharpNetCore.Base
{
    public abstract class BasePage:Base
    {
        //public WaitActionPage _waitActions=new WaitActionPage();
        public BasePage()
        {
            //_driver = DriverContext.Driver;
            // _waitActions = new WaitActionPage();
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

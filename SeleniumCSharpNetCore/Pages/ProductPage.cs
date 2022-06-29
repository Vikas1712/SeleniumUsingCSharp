namespace SeleniumCSharpNetCore.Pages
{
    public class ProductPage
    {
        private IWebDriver _driver;
        private WaitActionPage _waitActions;
        public ProductPage(IWebDriver driver)
        {
            this._driver = driver;
            _waitActions = new WaitActionPage(driver);
        }
        private readonly By dropDownWomenProductCategory = By.CssSelector("a[title='Women']");
        private readonly By linkTShirts = By.CssSelector("li[class='sfHover'] a[title='T-shirts']");
        private readonly By imgProductIcon = By.CssSelector("img[title='Faded Short Sleeve T-shirts']");
        private readonly By quickView = By.CssSelector("a[class='quick-view'] span");
        private readonly By txtProductDescription = By.Id("short_description_block");
        private readonly By btnAddToCart = By.Id("add_to_cart");
        private readonly By checkBoxSizeCategory = By.CssSelector("ul[id='ul_layered_id_attribute_group_1'] li:nth-child(2)");

        public void SelectProductCategory()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(_driver.FindElement(dropDownWomenProductCategory)).Perform();
            actions.MoveToElement(_driver.FindElement(linkTShirts)).Click().Perform();
        }

        public void SelectProduct()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(_driver.FindElement(imgProductIcon)).Perform();
            actions.MoveToElement(_driver.FindElement(quickView)).Click().Perform();
        }

        public void ViewProductDetail()
        {
            _waitActions.SwitchToIFrame();
            _waitActions.WaitForElementDisplayed(btnAddToCart);
            _waitActions.WaitForElementDisplayed(txtProductDescription);
            _driver.SwitchTo().DefaultContent();
        }

        public int CountNumberOfProducts() => _driver.FindElements(By.ClassName("product-image-container")).Count();

        public void SetFilterBasedOnCategory()
        {
            _waitActions.WaitForElementClickable(checkBoxSizeCategory);
            _waitActions.ClickElement(checkBoxSizeCategory);
            Thread.Sleep(5000);
        }
        
        public void ClickAddToCart()
        {
            _waitActions.SwitchToIFrame();
            _waitActions.ClickElement(btnAddToCart);
            _driver.SwitchTo().DefaultContent();
        }
    }
}

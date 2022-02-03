using OpenQA.Selenium;

namespace PageObjectModelPattern.ProcessCreationPOM._005.Base
{
    public abstract class PageBase
    {
        public IWebDriver Driver;

        public PageBase(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebElement Element(By by)
        {
            return Driver.FindElement(by);
        }

        public void Click(By by)
        {
            Element(by).Click();
        }

        public void Clear(By by)
        {
            Element(by).Clear();
        }

        public void SendKeys(By by, string text)
        {
            Element(by).SendKeys(text);
        }

        public string GetText(By by)
        {
            return Element(by).Text;
        }
    }
}

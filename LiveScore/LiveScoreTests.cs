using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace LiveScore
{
    public class LiveScoreTests
    {
        private const string baseUrl = @"https://www.livescore.com/en/";
        private WebDriver driver;
        private WebDriverWait wait;



        [SetUp]
        public void Setup()
        {

            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();  

        }

        [Test]
        public void Test1()
        {
            driver.Url = baseUrl;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            var acceptButton = wait.Until(d =>
            {
                return d.FindElement(By.Id("onetrust-accept-btn-handler"));

            });

            acceptButton.Click();
                              
            var searchButton = driver.FindElement(By.XPath("//input[contains(@data-testid,'search_modal-input')]"));
            searchButton.SendKeys("Belgium");

            Thread.Sleep(2000);

            var belgiumSelect = driver.FindElement(By.XPath("(//div[@class='Kj'][contains(.,'Belgium')])[1]"));
            belgiumSelect.Click();

            Thread.Sleep(2000);

            var belgianProLeague = driver.FindElement(By.XPath("(//div[@class='Kj'][contains(.,'Belgian Pro League')])[1]"));
            belgianProLeague.Click();

            Thread.Sleep(2000);

            var tableButton = driver.FindElement(By.XPath("(//a[@href='/en/football/belgium/belgian-pro-league/table/'])[1]"));
            tableButton.Click();

            Thread.Sleep(2000);

            var mechelenSelect = driver.FindElement(By.XPath("(//a[contains(.,'KV Mechelen')])[2]"));

            Assert.That(mechelenSelect.Text.Contains("KV Mechelen"));
        }
    }
}
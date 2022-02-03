using NUnit.Framework;

namespace PageObjectModelPattern.ProcessCreationPOM._003
{
    [TestFixture]
    public class LoginExampleTest3 : TestBase
    {

        [Test]
        public void WhenLoginWithValidNameAndPassword_SuccessMessageShouldAppear()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.LoginWithNameAndPassword("user@email.com", "demo");
            mainPage.CheckThatAlertMessageContainsText("logged in as John Doe.");
        }
    }
}
using NUnit.Framework;
using PageObjectModelPattern.ProcessCreationPOM._005.Base;
using PageObjectModelPattern.ProcessCreationPOM._005.Pages;

namespace PageObjectModelPattern.ProcessCreationPOM._005.Test
{
    [TestFixture]
    public class LoginExampleTest5 : TestBase
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
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace ParallelLTSelenium
{
    [TestFixture("chrome", "96.0", "Windows 10")]
    [TestFixture("firefox", "95.0.2", "Windows 10")]
    [TestFixture("Edge", "96.0.1054.62", "Windows 10")]
    [TestFixture("chrome", "96.0", "macOS BigSur")]
    [TestFixture("safari", "12", "macOS Mojave")]
    [Parallelizable(ParallelScope.Children)]
    public class ParallelLTTests
    {
        #region Declaration
        private const string userName = "demandgen";
        private const string accessKey = "7Ysirb1F9B1MHsS422DcS0kHidXRVewtPE6AqQ25DCVbzqDgkF";
        private const string build = "ThriveForms";
        private static IWebDriver driver;
        private string browser;
        private string version;
        private string os;
        private string expectedContactForm = "https://thriveagency.com/thank-you/";
        private string expectedReferralForm = "https://thriveagency.com/thank-you-12/";
        private string expectedNewsletter = "https://thriveagency.com/newsletter-thank-you/";
        private string expectedGmbform = "https://thriveagency.com/free-strategy-session/";
        private string expectedPdf = "https://thriveagency.com/files/How-to-Build-a-Strong-Online-Foundation-and-Get-More-Leads-2.pdf";
        private string expectedThriveAgencies = "https://thriveagency.com/thank-you/";
        private string expectedSubmitResult = "Thanks for submitting your results. We’ll review and let you know any questions.";

        //Rize Reviews forms Expected Result
        private string expectedRizeContact = "https://rizereviews.com/thank-you/#gf_3";
        private string expectedFreedemo = "https://rizereviews.com/thank-you-for-requesting-a-free-demo/";
        private string expectedRizenewsletter = "https://rizereviews.com/thank-you-for-subscribing/#gf_5";
        private string expectedFreeguide = "https://rizereviews.com/thank_you/";
        private string expectedFreetrial = "https://rizereviews.com/thank-you-for-requesting-a-trial-tim/";
        private string expectedRequesttrial = "https://rizereviews.com/thank-you-for-requesting-a-trial-tim/";
        private string expectedWebinar = "https://rizereviews.com/thank-you-for-signing-up-for-webinar/";
        private string expectedDownloadReport = "https://rizereviews.com/thank-you-for-downloading-reputation-report/";

        //SeoBlog forms Expected Result

        private string expectedSeocontact = "Thanks for contacting us! We will get in touch with you shortly.";
        private string expectedAdvertise = "https://www.seoblog.com/thank/";
        private string expectedBadges = "https://www.seoblog.com/thank/";
        private string expectedDirectory = "https://www.seoblog.com/thank/";
        private string expectedContribute = "Thanks for contacting us! We will get in touch with you shortly.";
        private string expectedAgency = "Thanks for contacting us! We will get in touch with you shortly.";
        #endregion

        #region Constructor to intialize the Settings
        public ParallelLTTests(string browser, string version, string os)
        {
            this.browser = browser;
            this.version = version;
            this.os = os;
        }
        #endregion

        #region Desired Capabilities for Chrome and Setup.
        [SetUp]
        [Obsolete]
        public void Init()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, browser);
            capabilities.SetCapability(CapabilityType.Version, version);
            capabilities.SetCapability(CapabilityType.Platform, os);

            capabilities.SetCapability("user", userName);
            capabilities.SetCapability("accessKey", accessKey);
            capabilities.SetCapability("name",
               string.Format("{0}:{1}: [{2}]",
               TestContext.CurrentContext.Test.ClassName,
               TestContext.CurrentContext.Test.MethodName,
               TestContext.CurrentContext.Test.Properties.Get("Description")));

            if (build != null)
                capabilities.SetCapability("build", build);
            string seleniumUri = "https://hub.lambdatest.com/wd/hub";

            driver = new RemoteWebDriver(new Uri(seleniumUri), capabilities, TimeSpan.FromSeconds(600));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

        }

        #endregion

        #region  Thrive Test Methods
        [Test]
        [Obsolete]
        public void ThriveContact()
        {
            driver.Url = "https://thriveagency.com/contact/";
            driver.Manage().Window.Maximize();
            //Thread.Sleep(2000);
            //WaitUntilElementVisible
            IWebElement FirstName = driver.FindElement(By.Id("input_15_1_3"));
            FirstName.SendKeys("Himshikha");
            IWebElement LastName = driver.FindElement(By.Id("input_15_1_6"));
            LastName.SendKeys("Shah");
            IWebElement EmailAddress = driver.FindElement(By.Id("input_15_2"));
            EmailAddress.SendKeys("himshikha@thriveagency.com");
            Thread.Sleep(5000);
            IWebElement flag = driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/main[1]/section[2]/div[2]/article[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/form[1]/div[1]/ul[1]/li[3]/div[1]/div[1]/div[1]/div[1]/div[1]"));
            flag.Click();
            Thread.Sleep(3000);
            IWebElement flagSelect = driver.FindElement(By.Id("iti-0__item-in-preferred"));
            flagSelect.Click();
            IWebElement Phone = driver.FindElement(By.Id("input_15_37"));
            Phone.SendKeys("9874563214");
            IWebElement Company = driver.FindElement(By.Id("input_15_11"));
            Company.SendKeys("Thrive");
            IWebElement website = driver.FindElement(By.Id("input_15_7"));
            website.SendKeys("https://thriveagency.com/");
            IWebElement OptimizationCheck = driver.FindElement(By.Id("label_15_8_1"));
            OptimizationCheck.Click();
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            js1.ExecuteScript("window.scrollBy(0,200)");
            Thread.Sleep(3000);
            SelectElement MonthlyBudget = new SelectElement(driver.FindElement(By.Id("input_15_20")));
            MonthlyBudget.SelectByValue("$1,500-$3,000 per month");
            IWebElement Message = driver.FindElement(By.Id("input_15_10"));
            Message.SendKeys("Testing");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,600)");
            Thread.Sleep(3000);
            IWebElement ReferredCheckbox = driver.FindElement(By.Id("label_15_35_1"));
            ReferredCheckbox.Click();
            IWebElement ReferredName = driver.FindElement(By.Id("input_15_36"));
            ReferredName.SendKeys("Kritika");
            Thread.Sleep(3000);
            IWebElement SubmitButton = driver.FindElement(By.Id("gform_submit_button_15"));
            Thread.Sleep(3000);
            SubmitButton.Click();
            Thread.Sleep(3000);
            string cuurentURL = driver.Url;
            Assert.AreEqual(expectedContactForm, cuurentURL);

            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedContactForm, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedContactForm, cuurentURL);
            }
        }

        [Test]
        public void ThriveReferralForm()
        {
            driver.Url = "https://thriveagency.com/referral/";
            Thread.Sleep(2000);
            driver.Manage().Window.Maximize();
            IWebElement FirstName = driver.FindElement(By.Id("input_13_1_3"));
            FirstName.SendKeys("Kritika");
            IWebElement LastName = driver.FindElement(By.Id("input_13_1_6"));
            LastName.SendKeys("Dhillon");
            IWebElement Email = driver.FindElement(By.Id("input_13_2"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement PhoneNumber = driver.FindElement(By.Id("input_13_8"));
            PhoneNumber.SendKeys("9874563210");
            IWebElement ReferralFirstName = driver.FindElement(By.Id("input_13_3_3"));
            ReferralFirstName.SendKeys("Tester");
            IWebElement ReferralLastName = driver.FindElement(By.Id("input_13_3_6"));
            ReferralLastName.SendKeys("Tester2");
            IWebElement ReferralPhone = driver.FindElement(By.Id("input_13_5"));
            ReferralPhone.SendKeys("7896541232");
            IWebElement ReferralEmail = driver.FindElement(By.Id("input_13_6"));
            ReferralEmail.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement ReferralWebsite = driver.FindElement(By.Id("input_13_4"));
            ReferralWebsite.SendKeys("https://thriveagency.com/");
            IWebElement Message = driver.FindElement(By.Id("input_13_7"));
            Message.SendKeys("Testing");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,500)");
            IWebElement SubmitButton = driver.FindElement(By.Id("gform_submit_button_13"));
            Thread.Sleep(2000);
            SubmitButton.Click();
            Thread.Sleep(3000);
            string cuurentURL = driver.Url;
            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedReferralForm, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedReferralForm, cuurentURL);
            }
        }

        [Test]
        public void ThriveSubmitResult()
        {
            driver.Url = "https://thriveagency.com/submit-results/";
            Thread.Sleep(2000);
            driver.Manage().Window.Maximize();
            driver.Navigate().Refresh();
            IWebElement PasswordFiled = driver.FindElement(By.Id("pwbox-20674"));
            PasswordFiled.SendKeys("ResultGallery@4321");
            IWebElement EnterButton = driver.FindElement(By.Name("Submit"));
            EnterButton.Click();
            SelectElement ClientNameSelect = new SelectElement(driver.FindElement(By.Id("input_64_37")));
            ClientNameSelect.SelectByValue("3915");
            SelectElement CityNameSelect = new SelectElement(driver.FindElement(By.Id("input_64_36")));
            CityNameSelect.SelectByValue("3907");
            SelectElement SpecialistNameSelect = new SelectElement(driver.FindElement(By.Id("input_64_39")));
            SpecialistNameSelect.SelectByValue("3897");
            SelectElement IndustryNameSelect = new SelectElement(driver.FindElement(By.Id("input_64_31")));
            IndustryNameSelect.SelectByValue("3910");
            // If the file is 804402.png, and testing environment is Windows OS 
            //IWebElement addFile = driver.FindElement(By.XPath(".//input[@type='file']"));
            IWebElement addFile = driver.FindElement(By.Id("input_64_14"));
            addFile.SendKeys("C:\\Users\\user\\Downloads\\500x375.png"); 


            SelectElement ServicesNameSelect = new SelectElement(driver.FindElement(By.Id("input_64_40")));
            ServicesNameSelect.SelectByValue("804");
            SelectElement AccountNameSelect = new SelectElement(driver.FindElement(By.Id("input_64_32")));
            AccountNameSelect.SelectByValue("3090");
            SelectElement BusinessNameSelect = new SelectElement(driver.FindElement(By.Id("input_64_34")));
            BusinessNameSelect.SelectByValue("3103");
            SelectElement SpendNameSelect = new SelectElement(driver.FindElement(By.Id("input_64_35")));
            SpendNameSelect.SelectByValue("3107");
            IWebElement Description = driver.FindElement(By.Id("input_64_18"));
            string Testing = "“Thrive is a much needed blessing and exceeded our expectations in every way. They are honest, straightforward, they take care of ALL your needs quickly, they are reliable, you can count on them and most of all, they do everything they say they will do, no BS.”";
            Description.SendKeys(Testing);
            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("window.scrollBy(0,1400)");
            IWebElement SubmitButton = driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/main[1]/section[2]/div[1]/article[1]/div[1]/div[1]/form[1]/div[2]/input[1]"));
            Thread.Sleep(3000);
            SubmitButton.Click();
            Thread.Sleep(3000);
            IWebElement getText = driver.FindElement(By.Id("gform_confirmation_message_64"));
            string successMessage = getText.Text;
            Assert.AreEqual(expectedSubmitResult, successMessage);
        }

        [Test]
        public void ThriveArlingtonCity()
        {
            driver.Url = "https://thriveagency.com/arlington-digital-marketing-agency/";
            driver.Manage().Window.Maximize();
            IWebElement SearchIconElement = driver.FindElement(By.Id("Capa_1"));
            SearchIconElement.Click();
            Thread.Sleep(7000);
            IWebElement Service = driver.FindElement(By.ClassName("chosen-search-input"));
            Service.Click();
            IWebElement Optimization_Service = driver.FindElement(By.XPath("//li[contains(text(),'Optimization (SEO)')]"));
            Optimization_Service.Click();
            Thread.Sleep(3000);
            IWebElement monthlyBudget = driver.FindElement(By.XPath("//*[@id='input_49_20_chosen']"));
            monthlyBudget.Click();
            Thread.Sleep(4000);
            var budgetList = driver.FindElement(By.XPath("//*[@id='input_49_20_chosen']/div/ul"));
            var options = budgetList.FindElements(By.TagName("li"));
            var selectedValue = options[2];
            selectedValue.Click();
            IWebElement websiteAddress = driver.FindElement(By.Id("input_49_36"));
            websiteAddress.SendKeys("https://thriveagency.com/");
            IWebElement Business = driver.FindElement(By.Id("input_49_10"));
            Business.SendKeys("Testing");
            IWebElement GetStartedButton = driver.FindElement(By.Id("gform_next_button_49_31"));
            GetStartedButton.Click();
            Thread.Sleep(5000);
            IWebElement firstName = driver.FindElement(By.Id("input_49_1_3"));
            firstName.SendKeys("Kritika");
            IWebElement lastName = driver.FindElement(By.Id("input_49_1_6"));
            lastName.SendKeys("Dhillon");
            IWebElement company = driver.FindElement(By.Id("input_49_11"));
            company.SendKeys("Thrive");
            IWebElement phone = driver.FindElement(By.Id("input_49_12"));
            phone.SendKeys("9875420125");
            IWebElement email = driver.FindElement(By.Id("input_49_2"));
            email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement conclusionButton = driver.FindElement(By.Id("gform_submit_button_49"));
            conclusionButton.Click();
            Thread.Sleep(3000);
            string cuurentURL = driver.Url;
            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedContactForm, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedContactForm, cuurentURL);
            }
        }

        [Test]
        public void ThriveWebinar()
        {
            driver.Url = "https://thriveagency.com/webinar/digital-marketing-tips-to-help-businesses-thrive-during-covid-19/";
            Thread.Sleep(2000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);
            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("window.scrollBy(0,2200)");
            Thread.Sleep(3000);
            IWebElement firstName = driver.FindElement(By.Id("input_67_1_3"));
            firstName.SendKeys("kritika");
            IWebElement lastName = driver.FindElement(By.Id("input_67_1_6"));
            lastName.SendKeys("Shah");
            IWebElement Email = driver.FindElement(By.Id("input_67_4"));
            Email.SendKeys("Kritikadhillon@thriveagency.com");
            IWebElement company = driver.FindElement(By.Id("input_67_2"));
            company.SendKeys("Thrive");
            IWebElement phone = driver.FindElement(By.Id("input_67_3"));
            phone.SendKeys("9852458745");
            IWebElement registerButton = driver.FindElement(By.Id("gform_submit_button_67"));
            registerButton.Click();
        }

        [Test]
        public void ThriveOurblog()
        {
            driver.Url = "https://thriveagency.com/about/blog/";
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            IWebElement page_load = driver.FindElement(By.Id("Capa_1"));
            page_load.Click();
            Thread.Sleep(2000);
            IWebElement Email = driver.FindElement(By.Id("input_18_1"));
            Email.SendKeys("Kritikadhillon@thriveagency.com");
            IWebElement SubscribeButton = driver.FindElement(By.Id("gform_submit_button_18"));
            SubscribeButton.Click();
            Thread.Sleep(5000);
            string cuurentURL = driver.Url;
            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedNewsletter, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedNewsletter, cuurentURL);
            }
        }

        [Test]
        public void ThriveGmbguide()
        {
            driver.Url = "https://thriveagency.com/gmb-guide/";
            Thread.Sleep(1500);
            IWebElement load_page = driver.FindElement(By.Id("MTE0NDoxODI=-1"));
            load_page.Click();
            Thread.Sleep(4000);
            IWebElement Downloadbutton = driver.FindElement(By.XPath("/html/body/div[4]/div/div/main/section[2]/div/article/div/div[1]/div[2]/div/div/div/div/div/div[2]/div/div/div/div[2]/div[2]/a"));
            Downloadbutton.Click();
            Thread.Sleep(2500);
            IWebElement FirstName = driver.FindElement(By.Id("input_74_1"));
            FirstName.SendKeys("Kritika Dhillon");
            IWebElement Email = driver.FindElement(By.Id("input_74_3"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement Accessbutton = driver.FindElement(By.Id("gform_submit_button_74"));
            Accessbutton.Click();
            Thread.Sleep(3000);
            string cuurentURL = driver.Url;
            Assert.AreEqual(expectedGmbform, cuurentURL);

            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedGmbform, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedGmbform, cuurentURL);
            }
        }

        [Test]
        public void ThrivePdfguide()
        {
            driver.Url = "https://thriveagency.com/free-pdf-guide-2/";
            driver.Manage().Window.Maximize();
            Wait(2000);
            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("window.scrollBy(0,1500)");
            Thread.Sleep(2500);
            IWebElement Name = driver.FindElement(By.Name("FNAME"));
            Name.SendKeys("Kritika Dhillon");
            IWebElement Email = driver.FindElement(By.Name("EMAIL"));
            Email.SendKeys("himshikhadhillon@gmail.com");
            IWebElement Freeguidebutton = driver.FindElement(By.XPath("//*[@id='mc4wp-form-1']/div[1]/p/input"));
            Freeguidebutton.Click();
            Wait(3000);
            string cuurentURL = driver.Url;
            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedPdf, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedPdf, cuurentURL);
            }
        }

        [Test]
        public void PdfGuide2()
        {
            driver.Navigate().GoToUrl("https://thriveagency.com/free-pdf-guide/");
            Wait(2000);
            driver.Manage().Window.Maximize();
            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("window.scrollBy(0,500)");
            Wait(2500);
            IWebElement Name = driver.FindElement(By.Name("FNAME"));
            Name.SendKeys("Himshikha Shah");
            // If the email address is already registered you have to change the email address(One email address is only used only one time)
            IWebElement Email = driver.FindElement(By.Name("EMAIL"));
            Email.SendKeys("himshikha@gmail.com");
            IWebElement Freeguidebutton = driver.FindElement(By.XPath("//*[@id='mc4wp-form-1']/div[1]/p/input"));
            Freeguidebutton.Click();
            Wait(5000);
            string cuurentURL = driver.Url;
            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedPdf, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedPdf, cuurentURL);
            }
        }

        [Test]
        public void ThriveForAgencies()
        {
            driver.Url = "https://thriveagency.com/digital-marketing-services/thrive-for-agencies/";
            Wait(12000);
            driver.Manage().Window.Maximize();
            Wait(12000);
            IWebElement searchicon = driver.FindElement(By.Id("Capa_1"));
            searchicon.Click();
            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("window.scrollBy(0,4100)");
            Wait(3000);
            IWebElement firstName = driver.FindElement(By.Id("input_40_1_3"));
            firstName.SendKeys("Kritika");
            Wait(2000);
            IWebElement lastName = driver.FindElement(By.Id("input_40_1_6"));
            lastName.SendKeys("Dhillon");
            Wait(2000);
            IWebElement Email = driver.FindElement(By.Id("input_40_2"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement Phone = driver.FindElement(By.Id("input_40_30"));
            Phone.SendKeys("9852012587");
            IWebElement Company = driver.FindElement(By.Id("input_40_11"));
            Company.SendKeys("Thrive");
            IWebElement website = driver.FindElement(By.Id("input_40_7"));
            website.SendKeys("thriveagency.com");
            Wait(2000);
            IWebElement message = driver.FindElement(By.Id("input_40_10"));
            message.SendKeys("Testing");
            Wait(2000);
            IWebElement SubmitButton = driver.FindElement(By.Id("gform_submit_button_40"));
            SubmitButton.Click();
            Wait(3000);
            string cuurentURL = driver.Url;
            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedThriveAgencies, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedThriveAgencies, cuurentURL);
            }
        }

        #endregion

        #region Rize Reviews Test Methods

        [Test]
        public void RizeContactform()
        {
            driver.Url = "https://rizereviews.com/contact/";
            driver.Manage().Window.Maximize();
            Wait(2000);
            IWebElement FirstName = driver.FindElement(By.Id("input_3_7_3"));
            FirstName.SendKeys("Kritika");
            IWebElement LastName = driver.FindElement(By.Id("input_3_7_6"));
            LastName.SendKeys("Dhillon");
            IWebElement Company = driver.FindElement(By.Id("input_3_18"));
            Company.SendKeys("Rize");
            IWebElement Email = driver.FindElement(By.Id("input_3_5"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement Phone = driver.FindElement(By.Id("input_3_3"));
            Phone.SendKeys("9874563214");
            IWebElement Website = driver.FindElement(By.Id("input_3_17"));
            Website.SendKeys("https://thriveagency.com/");
            IWebElement Message = driver.FindElement(By.Id("input_3_4"));
            Message.SendKeys("Testing");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,300)");
            Wait(3000);
            IWebElement SendButton = driver.FindElement(By.Id("gform_submit_button_3"));
            SendButton.Click();
            Wait(4000);
            string cuurentURL = driver.Url;
            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if(index >=0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedRizeContact, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedRizeContact, cuurentURL);
            }
        }

        [Test]
        public void RizeFreeDemo()
        {
            driver.Navigate().GoToUrl("https://rizereviews.com/free-demo/");
            driver.Manage().Window.Maximize();
            Wait(2000);
            IWebElement FirstName = driver.FindElement(By.Id("input_12_7_3"));
            FirstName.SendKeys("Kritika");
            IWebElement LastName = driver.FindElement(By.Id("input_12_7_6"));
            LastName.SendKeys("Dhillon");
            IWebElement Company = driver.FindElement(By.Id("input_12_23"));
            Company.SendKeys("Rize");
            IWebElement Email = driver.FindElement(By.Id("input_12_5"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement Phone = driver.FindElement(By.Id("input_12_3"));
            Phone.SendKeys("9874563214");
            IWebElement RequestDemoButton = driver.FindElement(By.Id("gform_submit_button_12"));
            RequestDemoButton.Click();
            Wait(4000);
            string cuurentURL = driver.Url;
            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedFreedemo, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedFreedemo, cuurentURL);
            }
        }

        [Test]
        public void RizeNewsLetter()
        {
            driver.Url = "https://rizereviews.com/how-to-get-more-5-star-google-reviews/";
            Wait(2000);
            driver.Manage().Window.Maximize();
            IWebElement FirstName = driver.FindElement(By.Id("input_5_7_3"));
            FirstName.SendKeys("Kritika");
            IWebElement LastName = driver.FindElement(By.Id("input_5_7_6"));
            LastName.SendKeys("Dhillon");
            IWebElement Email = driver.FindElement(By.Id("input_5_5"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement SubscribeButton = driver.FindElement(By.Id("gform_submit_button_5"));
            SubscribeButton.Click();
            Wait(3000);
            string cuurentURL = driver.Url;
            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedRizenewsletter, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedRizenewsletter, cuurentURL);
            }
        }

        [Test]
        public void RizeFreeguide()
        {
            driver.Url = "https://rizereviews.com/free-guide/?ignorenitro=d47b8c7911834cec85363b4dc6c2e4f8";
            driver.Manage().Window.Maximize();
            Wait(2000);
            IWebElement FirstName = driver.FindElement(By.Id("input_10_1_3"));
            FirstName.SendKeys("Kritika");
            IWebElement LastName = driver.FindElement(By.Id("input_10_1_6"));
            LastName.SendKeys("Dhillon");
            IWebElement Email = driver.FindElement(By.Id("input_10_2"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement HealthCheckbox = driver.FindElement(By.Id("label_10_4_1"));
            HealthCheckbox.Click();
            IWebElement RestaurantCheckbox = driver.FindElement(By.Id("label_10_4_5"));
            RestaurantCheckbox.Click();
            IWebElement Utilitiescheckbox = driver.FindElement(By.Id("label_10_4_4"));
            Utilitiescheckbox.Click();
            IWebElement Othercheckbox = driver.FindElement(By.Id("label_10_4_8"));
            Othercheckbox.Click();
            IWebElement FreeguideButton = driver.FindElement(By.Id("gform_submit_button_10"));
            FreeguideButton.Click();
            Wait(4000);
            string cuurentURL = driver.Url;
            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedFreeguide, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedFreeguide, cuurentURL);
            }
        }

        [Test]
        public void RizeFreetrial()
        {
            driver.Url = "https://rizereviews.com/free-trial/";
            driver.Manage().Window.Maximize();
            Wait(2000);
            IWebElement FirstName = driver.FindElement(By.Id("input_9_7_3"));
            FirstName.SendKeys("Kritika");
            IWebElement LastName = driver.FindElement(By.Id("input_9_7_6"));
            LastName.SendKeys("Dhillon");
            IWebElement Email = driver.FindElement(By.Id("input_9_5"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement Company = driver.FindElement(By.Id("input_9_23"));
            Company.SendKeys("Rize");
            IWebElement Phone = driver.FindElement(By.Id("input_9_3"));
            Phone.SendKeys("9874563214");
            IWebElement Code = driver.FindElement(By.Id("input_9_22"));
            Code.SendKeys("Rize");
            IWebElement Message = driver.FindElement(By.Id("input_9_4"));
            Message.SendKeys("Testing");
            IWebElement FreeTrailButton = driver.FindElement(By.Id("gform_submit_button_9"));
            FreeTrailButton.Click();
            Wait(3000);
            string cuurentURL = driver.Url;
            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedFreetrial, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedFreetrial, cuurentURL);
            }
        }

        [Test]
        public void RizeRequestTrail()
        {
            driver.Url = "https://rizereviews.com/request-trial/?cache=12";
            driver.Manage().Window.Maximize();
            Wait(8000);
            IWebElement FirstName = driver.FindElement(By.Id("input_6_7_3"));
            FirstName.SendKeys("Kritika");
            IWebElement LastName = driver.FindElement(By.Id("input_6_7_6"));
            LastName.SendKeys("Dhillon");
            IWebElement Email = driver.FindElement(By.Id("input_6_5"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement Company = driver.FindElement(By.Id("input_6_19"));
            Company.SendKeys("Rize");
            IWebElement Phone = driver.FindElement(By.Id("input_6_3"));
            Phone.SendKeys("9874563214");
            IWebElement Website = driver.FindElement(By.Id("input_6_18"));
            Website.SendKeys("https://rizereviews.com/");
            IWebElement Message = driver.FindElement(By.Id("input_6_4"));
            Message.SendKeys("Testing");
            Thread.Sleep(3000);
            IWebElement RequestTrailButton = driver.FindElement(By.Id("gform_submit_button_6"));
            RequestTrailButton.Click();
            Wait(7000);
            string cuurentURL = driver.Url;
            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedRequesttrial, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedRequesttrial, cuurentURL);
            }
        }

        [Test]
        public void RizeWebinarsignup()
        {
            driver.Url = "https://rizereviews.com/webinar-signup/";
            driver.Manage().Window.Maximize();
            Wait(2000);
            IWebElement FirstName = driver.FindElement(By.Id("input_7_7_3"));
            FirstName.SendKeys("Kritika");
            IWebElement LastName = driver.FindElement(By.Id("input_7_7_6"));
            LastName.SendKeys("Dhillon");
            IWebElement Email = driver.FindElement(By.Id("input_7_5"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement Phone = driver.FindElement(By.Id("input_7_3"));
            Phone.SendKeys("9874563214");
            IWebElement Website = driver.FindElement(By.Id("input_7_18"));
            Website.SendKeys("https://rizereviews.com/");
            IWebElement Message = driver.FindElement(By.Id("input_7_4"));
            Message.SendKeys("Testing");
            IWebElement SignupButton = driver.FindElement(By.Id("gform_submit_button_7"));
            SignupButton.Click();
            Wait(5000);
            string cuurentURL = driver.Url;
            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedWebinar, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedWebinar, cuurentURL);
            }
        }

        [Test]
        public void RizeDownloadReport()
        {
            driver.Url = "https://rizereviews.com/download-reputation-report/";
            driver.Manage().Window.Maximize();
            Wait(2000);
            IWebElement FirstName = driver.FindElement(By.Id("input_11_7_3"));
            FirstName.SendKeys("Kritika");
            IWebElement LastName = driver.FindElement(By.Id("input_11_7_6"));
            LastName.SendKeys("Dhillon");
            IWebElement Email = driver.FindElement(By.Id("input_11_5"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement Company = driver.FindElement(By.Id("input_11_19"));
            Company.SendKeys("Rize");
            IWebElement Phone = driver.FindElement(By.Id("input_11_3"));
            Phone.SendKeys("9874563214");
            IWebElement Website = driver.FindElement(By.Id("input_11_18"));
            Website.SendKeys("https://rizereviews.com/");
            IWebElement DownloadButton = driver.FindElement(By.Id("gform_submit_button_11"));
            DownloadButton.Click();
            Wait(6000);
            string cuurentURL = driver.Url;
            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedDownloadReport, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedDownloadReport, cuurentURL);
            }
        }
        #endregion

        #region SEO Blog Methods

        [Test]
        public void SeoblogContact()
        {
            driver.Url = "https://www.seoblog.com/contact/";
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            IWebElement FirstName = driver.FindElement(By.Id("input_4_1_3"));
            FirstName.SendKeys("Kritika");
            IWebElement LastName = driver.FindElement(By.Id("input_4_1_6"));
            LastName.SendKeys("Dhillon");
            IWebElement Email = driver.FindElement(By.Id("input_4_3"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement Phone = driver.FindElement(By.Id("input_4_2"));
            Phone.SendKeys("9874563214");
            IWebElement Message = driver.FindElement(By.Id("input_4_4"));
            Message.SendKeys("Testing");
            IWebElement SubmitButton = driver.FindElement(By.Id("gform_submit_button_4"));
            SubmitButton.Click();
            Wait(6000);
            IWebElement confirmation = driver.FindElement(By.Id("gform_confirmation_message_4"));
            string confirmation_text = confirmation.Text;
            Assert.AreEqual(expectedSeocontact, confirmation_text);
        }

        [Test]
        public void SeoblogAdvertise()
        {
            driver.Url = "https://www.seoblog.com/advertise/";
            driver.Manage().Window.Maximize();
            Wait(2000);
            driver.Navigate().Refresh();
            Wait(5000);
            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("window.scrollBy(0,4900)");
            Wait(5000);
            IWebElement Name = driver.FindElement(By.Id("input_5_1"));
            Name.SendKeys("Kritika");
            Wait(2000);
            IWebElement Email = driver.FindElement(By.Id("input_5_2"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            Wait(2000);
            IWebElement Phone = driver.FindElement(By.Id("input_5_3"));
            Phone.SendKeys("9874563214");
            Wait(2000);
            IWebElement Company = driver.FindElement(By.Id("input_5_4"));
            Company.SendKeys("SeoBlog");
            Wait(2000);
            IWebElement Website = driver.FindElement(By.Id("input_5_5"));
            Website.SendKeys("https://www.seoblog.com/advertise/");
            Wait(2000);
            IWebElement Sponsrship = driver.FindElement(By.Id("choice_5_6_1"));
            Sponsrship.Click();

            //Wait until condition for the element
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.ElementExists(By.Id("input_5_7")));
            IWebElement Comment = driver.FindElement(By.Id("input_5_7"));
            Comment.SendKeys("Testing");

            //Wait until condition for the element
            WebDriverWait w1 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            w1.Until(ExpectedConditions.ElementToBeClickable(By.Id("gform_submit_button_5")));
            IWebElement submitButton = driver.FindElement(By.Id("gform_submit_button_5"));
            submitButton.Click();
            Wait(7000);
            string cuurentURL = driver.Url;

            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedAdvertise, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedAdvertise, cuurentURL);
            }
        }

        [Test]
        public void SeoblogBadges()
        {
            driver.Url = "https://www.seoblog.com/badges/";
            driver.Manage().Window.Maximize();
            Wait(2000);
            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("window.scrollBy(0,4200)");
            Wait(5000);
            IWebElement Name = driver.FindElement(By.Id("input_3_1"));
            Name.SendKeys("Kritika");
            IWebElement agencyName = driver.FindElement(By.Id("input_3_2"));
            agencyName.SendKeys("Advertise");
            IWebElement cities = driver.FindElement(By.Id("input_3_3"));
            cities.SendKeys("Washington D.C.");
            IWebElement Email = driver.FindElement(By.Id("input_3_4"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement Phone = driver.FindElement(By.Id("input_3_5"));
            Phone.SendKeys("9874563214");
            IWebElement Website = driver.FindElement(By.Id("input_3_6"));
            Website.SendKeys("https://www.seoblog.com/badges/");
            IWebElement badgescheckbox = driver.FindElement(By.Id("choice_3_7_1"));
            badgescheckbox.Click();
            IWebElement submitButton = driver.FindElement(By.Id("gform_submit_button_3"));
            submitButton.Click();
            Wait(5000);
            string cuurentURL = driver.Url;
            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedBadges, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedBadges, cuurentURL);
            }

        }
        //search-btn
        [Test]
        public void SeoblogContribute()
        {
            driver.Navigate().GoToUrl("https://www.seoblog.com/contribute/");
            Thread.Sleep(2000);
            driver.Manage().Window.Maximize();
            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("window.scrollBy(0,800)");
            Thread.Sleep(5000);
            IWebElement firstName = driver.FindElement(By.Id("input_1_1_3"));
            firstName.SendKeys("Kritika");
            IWebElement lastName = driver.FindElement(By.Id("input_1_1_6"));
            lastName.SendKeys("Dhillon");
            IWebElement Email = driver.FindElement(By.Id("input_1_2"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement Website = driver.FindElement(By.Id("input_1_4"));
            Website.SendKeys("https://www.seoblog.com/contribute/");
            IWebElement company = driver.FindElement(By.Id("input_1_5"));
            company.SendKeys("seoblog");
            IWebElement jobTitle = driver.FindElement(By.Id("input_1_6"));
            jobTitle.SendKeys("QA");
            IWebElement contributecheckbox = driver.FindElement(By.Id("label_1_14_0"));
            contributecheckbox.Click();
            IWebElement linkedinProfile = driver.FindElement(By.Id("input_1_13"));
            linkedinProfile.SendKeys("QA");
            IWebElement bio = driver.FindElement(By.Id("input_1_8"));
            bio.SendKeys("Testing");
            IWebElement topic = driver.FindElement(By.Id("input_1_15"));
            topic.SendKeys("1.Best Effective Ways to Build a Powerful Brand with SEO. 2. Importance Of Branding in Digital Marketing. 3. How to Rank Extremely High on Google");
            IWebElement submitButton = driver.FindElement(By.Id("gform_submit_button_1"));
            submitButton.Click();
            Wait(5000);
            IWebElement confirmation = driver.FindElement(By.Id("gform_confirmation_message_1"));
            string confirmation_text = confirmation.Text;
            Assert.AreEqual(expectedContribute, confirmation_text);
        }

        [Test]
        public void SeoblogAgency()
        {
            driver.Url = "https://www.seoblog.com/best-seo-companies/austin/";
            Wait(2000);
            driver.Manage().Window.Maximize();
            Wait(4000);

            WebDriverWait searchicon_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            searchicon_wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("hdr-search")));
            IWebElement searchicon = driver.FindElement(By.ClassName("hdr-search"));
            searchicon.Click();
            Wait(4000);

            WebDriverWait service_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            service_wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("input_9_7_chosen")));
            IWebElement service = driver.FindElement(By.Id("input_9_7_chosen"));
            service.Click();
            Wait(2000);

            IWebElement service_optimization = driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div/div[2]/div/form/div[1]/div/div[2]/div/div/div/ul/li[1]"));
            service_optimization.Click();

            IWebElement firstName = driver.FindElement(By.Id("input_9_2_3"));
            firstName.SendKeys("Kritika");
            IWebElement lastName = driver.FindElement(By.Id("input_9_2_6"));
            lastName.SendKeys("Dhillon");
            IWebElement Email = driver.FindElement(By.Id("input_9_3"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement Website = driver.FindElement(By.Id("input_9_5"));
            Website.SendKeys("https://www.seoblog.com/");
            SelectElement budgetNameSelect = new SelectElement(driver.FindElement(By.Id("input_9_6")));
            budgetNameSelect.SelectByValue("$3,000-$5,000 per month");
            IWebElement submitbutton = driver.FindElement(By.Id("gform_submit_button_9"));
            submitbutton.Click();
            Wait(3000);
            IWebElement confirmation = driver.FindElement(By.Id("gform_confirmation_message_9"));
            string confirmation_text = confirmation.Text;
            Assert.AreEqual(expectedAgency, confirmation_text);
        }

        [Test]
        public void SeoblogDirectory()
        {
            driver.Url = "https://www.seoblog.com/directory/";
            Wait(2000);
            driver.Manage().Window.Maximize();
            Wait(4000);

            WebDriverWait search_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            search_wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("hdr-search")));
            IWebElement search = driver.FindElement(By.ClassName("hdr-search"));
            search.Click();
            Wait(4000);


            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("window.scrollBy(0,3800)");
            Wait(7000);

            WebDriverWait requestButton_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            requestButton_wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/section/section/div[5]/div/div/div[2]/div/div/button")));
            IWebElement requestButton = driver.FindElement(By.XPath("/html/body/div[1]/section/section/div[5]/div/div/div[2]/div/div/button"));
            requestButton.Click();
            Wait(5000);


            WebDriverWait firstName_wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            firstName_wait.Until(ExpectedConditions.ElementExists(By.Id("input_8_1_3")));
            IWebElement firstName = driver.FindElement(By.Id("input_8_1_3"));
            firstName.SendKeys("Kritika");

            IWebElement lastName = driver.FindElement(By.Id("input_8_2_6"));
            lastName.SendKeys("Dhillon");
            IWebElement company = driver.FindElement(By.Id("input_8_3"));
            company.SendKeys("seoblog");
            IWebElement Email = driver.FindElement(By.Id("input_8_4"));
            Email.SendKeys("kritikadhillon@thriveagency.com");
            IWebElement budget = driver.FindElement(By.Id("input_8_5"));
            budget.SendKeys("$1000");
            IWebElement phone = driver.FindElement(By.Id("input_8_6"));
            phone.SendKeys("9852012541");
            IWebElement requestbutton = driver.FindElement(By.Id("gform_submit_button_8"));
            requestbutton.Click();
            Wait(4000);
            string cuurentURL = driver.Url;

            if (cuurentURL.Contains("?"))
            {
                int index = cuurentURL.IndexOf("?");
                if (index >= 0)
                    cuurentURL = cuurentURL.Substring(0, index);
                Assert.AreEqual(expectedDirectory, cuurentURL);
            }
            else
            {
                Assert.AreEqual(expectedDirectory, cuurentURL);
            }

        }
        #endregion

        #region Private Method(s)
        private static void Wait(int time) => Thread.Sleep(time);
        #endregion

        #region Teardown Method
        [TearDown]
        public void Cleanup()
        {
            bool passed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed;
            try
            {
                // Logs the result to Lambdatest
                ((IJavaScriptExecutor)driver).ExecuteScript("lambda-status=" + (passed ? "passed" : "failed"));
            }
            finally
            {
                // Terminates the remote webdriver session
                driver.Quit();
            }
        }

        #endregion

    }
}
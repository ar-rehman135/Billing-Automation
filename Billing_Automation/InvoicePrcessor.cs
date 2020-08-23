namespace Billing_Automation
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.WaitHelpers;
    using System;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading;

    public class InvoicePrcessor : IDisposable
    {
        private int screenshot_no = 1;
        private string invoice_no;
        private PhantomJSDriver driver;
        private int submit_wait = 300;
        private int web_el_wait = 20;
        private bool is_takescreenshot = true;
        private string SignInUrl = "https://apps.fleetone.com/FleetDocs/User/Login";
        private string SignOut = "https://apps.fleetone.com/FleetDocs/User/Logout";
        private string CreateBillUrl = "https://apps.fleetone.com/FleetDocs/Billing/CreateBillingFiles";
        private string HomePageUrl = "https://apps.fleetone.com/FleetDocs/";
        private string DownloadLink = "https://apps.fleetone.com/FleetDocs/DownloadFile/{0}?download=true";
        private string FormFillingErrorMSG;

        public bool attachFiles(InvoiceInfo info)
        {
            bool flag2;
            try
            {
                IWebElement element4;
                IWebElement objA = this.FindElementIfExists(By.CssSelector("#tbd_docs > tr:nth-child(1) > td:nth-child(1) > img:nth-child(1)"));
                if (!ReferenceEquals(objA, null))
                {
                    objA.Click();
                    Thread.Sleep(0x7d0);
                    IWebElement element2 = this.FindElementIfExists(By.Id("rd_doc_file"));
                    if (!ReferenceEquals(element2, null))
                    {
                        element2.Click();
                        IWebElement element3 = this.FindElementIfExists(By.Id("FileUpload"));
                        if (!ReferenceEquals(element3, null))
                        {
                            element3.SendKeys(info.invFile);
                            element4 = this.FindElementIfExists(By.CssSelector(".attach-doc-submit"));
                            if (!ReferenceEquals(element4, null))
                            {
                                goto TR_002B;
                            }
                            else
                            {
                                element4 = this.FindElementIfExists(By.XPath("/html/body/div[1]/div/div/div[3]/button[2]"));
                                if (!ReferenceEquals(element4, null))
                                {
                                    goto TR_002B;
                                }
                                else
                                {
                                    this.FormFillingErrorMSG = "Invoice File Submit Button Not found";
                                    flag2 = false;
                                }
                            }
                        }
                        else
                        {
                            this.FormFillingErrorMSG = "File Upload Input Not found";
                            flag2 = false;
                        }
                    }
                    else
                    {
                        this.FormFillingErrorMSG = "Attach File From PC Button Not found";
                        flag2 = false;
                    }
                }
                else
                {
                    this.FormFillingErrorMSG = "Invoice Attach Button Not found";
                    flag2 = false;
                }
                return flag2;
            TR_002B:
                element4.Click();
                Thread.Sleep(0xfa0);
                this.takescreenshot("invoiceFileAttached");
                try
                {
                    IWebElement element8;
                    IWebElement element5 = this.FindElementIfExists(By.CssSelector("#tbd_docs > tr:nth-child(2) > td:nth-child(1) > img:nth-child(1)"));
                    if (!ReferenceEquals(element5, null))
                    {
                        element5.Click();
                        Thread.Sleep(0x7d0);
                        IWebElement element6 = this.FindElementIfExists(By.Id("rd_doc_file"));
                        if (!ReferenceEquals(element6, null))
                        {
                            element6.Click();
                            IWebElement element7 = this.FindElementIfExists(By.Id("FileUpload"));
                            if (!ReferenceEquals(element7, null))
                            {
                                element7.SendKeys(info.RateConfFile);
                                element8 = this.FindElementIfExists(By.CssSelector(".attach-doc-submit"));
                                if (!ReferenceEquals(element8, null))
                                {
                                    goto TR_001E;
                                }
                                else
                                {
                                    element8 = this.FindElementIfExists(By.XPath("/html/body/div[1]/div/div/div[3]/button[2]"));
                                    if (!ReferenceEquals(element8, null))
                                    {
                                        goto TR_001E;
                                    }
                                    else
                                    {
                                        this.FormFillingErrorMSG = "Invoice File Submit Button Not found";
                                        flag2 = false;
                                    }
                                }
                            }
                            else
                            {
                                this.FormFillingErrorMSG = "File Upload Input Not found";
                                flag2 = false;
                            }
                        }
                        else
                        {
                            this.FormFillingErrorMSG = "Attach File From PC Button Not found";
                            flag2 = false;
                        }
                    }
                    else
                    {
                        this.FormFillingErrorMSG = "Invoice Attach Button Not found";
                        flag2 = false;
                    }
                    return flag2;
                TR_001E:
                    element8.Click();
                    Thread.Sleep(0xfa0);
                    this.takescreenshot("RateFileAttached");
                    try
                    {
                        IWebElement element12;
                        IWebElement element9 = this.FindElementIfExists(By.CssSelector("#tbd_docs > tr:nth-child(3) > td:nth-child(1) > img:nth-child(1)"));
                        if (!ReferenceEquals(element9, null))
                        {
                            element9.Click();
                            Thread.Sleep(0x7d0);
                            IWebElement element10 = this.FindElementIfExists(By.Id("rd_doc_file"));
                            if (!ReferenceEquals(element10, null))
                            {
                                element10.Click();
                                IWebElement element11 = this.FindElementIfExists(By.Id("FileUpload"));
                                if (!ReferenceEquals(element11, null))
                                {
                                    element11.SendKeys(info.BOLFile);
                                    element12 = this.FindElementIfExists(By.CssSelector(".attach-doc-submit"));
                                    if (!ReferenceEquals(element12, null))
                                    {
                                        goto TR_0011;
                                    }
                                    else
                                    {
                                        element12 = this.FindElementIfExists(By.XPath("/html/body/div[1]/div/div/div[3]/button[2]"));
                                        if (!ReferenceEquals(element12, null))
                                        {
                                            goto TR_0011;
                                        }
                                        else
                                        {
                                            this.FormFillingErrorMSG = "Invoice File Submit Button Not found";
                                            flag2 = false;
                                        }
                                    }
                                }
                                else
                                {
                                    this.FormFillingErrorMSG = "File Upload Input Not found";
                                    flag2 = false;
                                }
                            }
                            else
                            {
                                this.FormFillingErrorMSG = "Attach File From PC Button Not found";
                                flag2 = false;
                            }
                        }
                        else
                        {
                            this.FormFillingErrorMSG = "Invoice Attach Button Not found";
                            flag2 = false;
                        }
                        return flag2;
                    TR_0011:
                        element12.Click();
                        Thread.Sleep(0xfa0);
                        this.takescreenshot("BOLAttached");
                        return true;
                    }
                    catch
                    {
                        this.takescreenshot("ErrorBOLAttached");
                        this.FormFillingErrorMSG = "Erro attaching BOL File";
                        flag2 = false;
                    }
                    return flag2;
                }
                catch
                {
                    this.takescreenshot("ErrorRateFileAttached");
                    this.FormFillingErrorMSG = "Erro attaching Rate File";
                    flag2 = false;
                }
                return flag2;
            }
            catch
            {
                this.takescreenshot("errorInvoiceFileAttached");
                this.FormFillingErrorMSG = "Erro attaching Invoice File";
                flag2 = false;
            }
            return flag2;
        }

        public bool createBillAndDownloadFile(InvoiceInfo info)
        {
            bool flag3;
            try
            {
                IWebElement objA = this.FindElementIfExists(By.CssSelector(".create-billing-file-row > div:nth-child(1) > a:nth-child(1)"));
                if (!ReferenceEquals(objA, null))
                {
                    objA.Click();
                    Thread.Sleep(0x7d0);
                    IWebElement element2 = this.FindElementIfExists(By.CssSelector("#span-billing-file-link > a:nth-child(1)"));
                    if (ReferenceEquals(element2, null))
                    {
                        Thread.Sleep(0x3e8);
                        element2 = this.FindElementIfExists(By.CssSelector("#span-billing-file-link > a:nth-child(1)"));
                        if (ReferenceEquals(element2, null))
                        {
                            this.FormFillingErrorMSG = "Billing File Link not found";
                            return false;
                        }
                    }
                    this.takescreenshot("downloadLinkElemCreated");
                    string text = element2.Text;
                    string url = string.Format(this.DownloadLink, text);
                    if (this.TryDownloadFile(url, Path.Combine(Path.GetDirectoryName(info.BOLFile), text)))
                    {
                        flag3 = true;
                    }
                    else
                    {
                        this.FormFillingErrorMSG = "Billing Created Unable to download Billing File";
                        flag3 = false;
                    }
                }
                else
                {
                    this.FormFillingErrorMSG = "Create Bill from supported Doc button not found";
                    flag3 = false;
                }
            }
            catch (Exception)
            {
                flag3 = false;
            }
            return flag3;
        }

        public void Dispose()
        {
            if (this.driver != null)
            {
                this.driver.Quit();
            }
        }

        public bool FillCreateBillForm(InvoiceInfo info)
        {
            bool flag2;
            try
            {
                IWebElement objA = this.FindElementIfExists(By.Id("txt_load"));
                if (!ReferenceEquals(objA, null))
                {
                    objA.SendKeys(info.loadNmber);
                    Thread.Sleep(500);
                    this.takescreenshot("Load # enterred");
                    IWebElement element2 = this.FindElementIfExists(By.Id("txt_invoice"));
                    if (!ReferenceEquals(element2, null))
                    {
                        element2.Click();
                        element2.SendKeys(info.invoice);
                        Thread.Sleep(500);
                        this.takescreenshot("Invoice no enterred");
                        Thread.Sleep(0x7d0);
                        IWebElement element3 = this.FindElementIfExists(By.Id("myModal"));
                        if ((element2 == null) || !element3.Displayed)
                        {
                            IWebElement element4 = this.FindElementIfExists(By.Id("txt_inv_date"));
                            if (!ReferenceEquals(element4, null))
                            {
                                this.driver.ExecuteScript("document.getElementById('txt_inv_date').removeAttribute('readonly')", Array.Empty<object>());
                                element4.SendKeys(info.date);
                                Thread.Sleep(500);
                                this.takescreenshot("invoice date enterred");
                                IWebElement element5 = this.FindElementIfExists(By.Id("txt_inv_amt"));
                                if (!ReferenceEquals(element5, null))
                                {
                                    element5.SendKeys(info.totalAmount);
                                    Thread.Sleep(500);
                                    this.takescreenshot("total amount enterred");
                                    IWebElement element6 = this.FindElementIfExists(By.XPath("/html/body/div[3]/a"));
                                    if (!ReferenceEquals(element6, null))
                                    {
                                        element6.Click();
                                        Thread.Sleep(500);
                                        this.takescreenshot("search button clicked");
                                        IWebElement element7 = this.FindElementIfExists(By.Id("txtDbName"));
                                        if (ReferenceEquals(element7, null))
                                        {
                                            element7 = this.FindElementIfExists(By.Id("txtDbName"));
                                            if (ReferenceEquals(element7, null))
                                            {
                                                this.FormFillingErrorMSG = "Debtor Name Input Not found";
                                                return false;
                                            }
                                        }
                                        element7.SendKeys(info.debtorName);
                                        Thread.Sleep(500);
                                        this.takescreenshot("debtor name enterred");
                                        if (this.SearchDebtorandGetCount() > 1)
                                        {
                                            IWebElement element10 = this.FindElementIfExists(By.Id("txtDbPostalCode"));
                                            if (!ReferenceEquals(element10, null))
                                            {
                                                element10.SendKeys(info.debtorPostalCode);
                                                Thread.Sleep(500);
                                                this.takescreenshot("debtor postal code enterred");
                                                IWebElement element11 = this.FindElementIfExists(By.XPath("/html/body/div[1]/div/div/div[2]/center/button"));
                                                if (!ReferenceEquals(element11, null))
                                                {
                                                    element11.Click();
                                                    Thread.Sleep(0x9c4);
                                                    this.takescreenshot("search debtor clicked");
                                                }
                                                else
                                                {
                                                    this.FormFillingErrorMSG = "Search Debtor Dialog Search Button Not Found";
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                this.FormFillingErrorMSG = "Postal Code Input Not Found";
                                                return false;
                                            }
                                        }
                                        IWebElement element8 = this.FindElementIfExists(By.Id("span_debtors"));
                                        if (ReferenceEquals(element8, null))
                                        {
                                            element8 = this.FindElementIfExists(By.Id("span_debtors"));
                                            if (ReferenceEquals(element8, null))
                                            {
                                                this.FormFillingErrorMSG = "List Debtors Not Found";
                                                return false;
                                            }
                                        }
                                        ReadOnlyCollection<IWebElement> onlys = element8.FindElements(By.CssSelector("input"));
                                        if (onlys.Count == 0)
                                        {
                                            this.FormFillingErrorMSG = "Debtor Not Found";
                                            flag2 = false;
                                        }
                                        else
                                        {
                                            onlys[0].Click();
                                            Thread.Sleep(0x5dc);
                                            this.takescreenshot("debtor radio clicked");
                                            IWebElement element9 = this.FindElementIfExists(By.XPath("/html/body/div[1]/div/div/div[3]/button[3]"));
                                            if (ReferenceEquals(element9, null))
                                            {
                                                this.FormFillingErrorMSG = "debtor select button not found";
                                                flag2 = false;
                                            }
                                            else
                                            {
                                                element9.Click();
                                                Thread.Sleep(0x9c4);
                                                this.takescreenshot("debtor selected");
                                                this.takescreenshot("Form Filled");
                                                flag2 = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.FormFillingErrorMSG = "search Debtor Button Not found";
                                        flag2 = false;
                                    }
                                }
                                else
                                {
                                    this.FormFillingErrorMSG = "Amount Input Not found";
                                    flag2 = false;
                                }
                            }
                            else
                            {
                                this.FormFillingErrorMSG = "Date Input Not found";
                                flag2 = false;
                            }
                        }
                        else
                        {
                            this.FormFillingErrorMSG = "Billing Load Number Already Exists";
                            flag2 = false;
                        }
                    }
                    else
                    {
                        this.FormFillingErrorMSG = "Invoice Input Not found";
                        flag2 = false;
                    }
                }
                else
                {
                    this.FormFillingErrorMSG = "Load Inut Not found";
                    flag2 = false;
                }
            }
            catch (Exception)
            {
                this.takescreenshot("Error Form Filling");
                this.FormFillingErrorMSG = "Error in Filling Create Bill Form";
                flag2 = false;
            }
            return flag2;
        }

        ~InvoicePrcessor()
        {
            if (this.driver != null)
            {
                this.driver.Quit();
            }
        }

        private IWebElement FindElementIfExists(By by)
        {
            try
            {
                new WebDriverWait(this.driver, TimeSpan.FromSeconds((double) this.web_el_wait)).Until<IWebElement>(ExpectedConditions.ElementExists(by));
                ReadOnlyCollection<IWebElement> source = this.driver.FindElements(by);
                return ((source.Count < 1) ? null : source.First<IWebElement>());
            }
            catch
            {
                return null;
            }
        }

        public bool Login(InvoiceInfo info)
        {
            bool flag = false;
            try
            {
                this.driver.Navigate().GoToUrl(this.SignInUrl);
                if (this.driver.Url == this.HomePageUrl)
                {
                    this.ShowDriverState();
                    return true;
                }
                else
                {
                    this.takescreenshot("login screen");
                    this.ShowDriverState();
                    IWebElement objA = this.FindElementIfExists(By.Id("UserName"));
                    if (!ReferenceEquals(objA, null))
                    {
                        objA.SendKeys(info.username);
                        IWebElement element2 = this.FindElementIfExists(By.Id("Password"));
                        if (!ReferenceEquals(objA, null))
                        {
                            element2.SendKeys(info.password);
                            this.driver.FindElementByCssSelector("button.btn.btn-default[type='submit']").Click();
                            bool flag2 = new WebDriverWait(this.driver, TimeSpan.FromSeconds((double) this.submit_wait)).Until<bool>(ExpectedConditions.UrlToBe(this.HomePageUrl));
                            if (this.driver.Url != this.HomePageUrl)
                            {
                                this.ShowDriverState();
                                flag = false;
                            }
                            else
                            {
                                this.ShowDriverState();
                                flag = true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception exception)
            {
                this.takescreenshot("exception login");
                this.ShowDriverState();
                Console.WriteLine(exception.Message);
                flag = false;
            }
            this.takescreenshot("afterLoginScreen");
            return flag;
        }

        public bool OpenCreateBillPage()
        {
            bool flag2;
            try
            {
                this.driver.Navigate().GoToUrl(this.CreateBillUrl);
                if (this.driver.Url != this.CreateBillUrl)
                {
                    this.ShowDriverState();
                    flag2 = true;
                }
                else
                {
                    this.ShowDriverState();
                    this.takescreenshot("createBillPage");
                    flag2 = true;
                }
            }
            catch
            {
                flag2 = false;
            }
            return flag2;
        }

        public string ProcessInvoice(InvoiceInfo info)
        {
            this.invoice_no = info.invoice;
            Console.WriteLine(info.Display());
            this.RefreshDriver();
            bool flag = false;
            int num = 0;
            while (true)
            {
                string formFillingErrorMSG;
                if (num < 3)
                {
                    flag = this.Login(info);
                    if (!flag)
                    {
                        num++;
                        continue;
                    }
                }
                if (!flag)
                {
                    formFillingErrorMSG = "unable to do Login";
                }
                else if (!this.OpenCreateBillPage())
                {
                    formFillingErrorMSG = "Unable to open Create Bill Page";
                }
                else if (!this.FillCreateBillForm(info))
                {
                    this.takescreenshot(this.FormFillingErrorMSG);
                    formFillingErrorMSG = this.FormFillingErrorMSG;
                }
                else if (!this.attachFiles(info))
                {
                    this.takescreenshot(this.FormFillingErrorMSG);
                    formFillingErrorMSG = this.FormFillingErrorMSG;
                }
                else if (this.createBillAndDownloadFile(info))
                {
                    formFillingErrorMSG = "Bill Created";
                }
                else
                {
                    this.takescreenshot(this.FormFillingErrorMSG);
                    formFillingErrorMSG = this.FormFillingErrorMSG;
                }
                return formFillingErrorMSG;
            }
        }

        private void RefreshDriver()
        {
            try
            {
                if (this.driver != null)
                {
                    this.driver.Quit();
                }
                PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService(Environment.CurrentDirectory);
                service.WebSecurity = false;
                service.HideCommandPromptWindow = true;
                this.driver = new PhantomJSDriver(service, new PhantomJSOptions(), TimeSpan.FromSeconds((double) this.submit_wait));
                this.driver.Manage().Window.Size = new Size(0x4d8, 0x4d8);
            }
            catch
            {
                throw;
            }
        }

        private int SearchDebtorandGetCount()
        {
            int count;
            IWebElement objA = this.FindElementIfExists(By.XPath("/html/body/div[1]/div/div/div[2]/center/button"));
            if (!ReferenceEquals(objA, null))
            {
                objA.Click();
                Thread.Sleep(0x9c4);
                this.takescreenshot("search debtor clicked");
                IWebElement element2 = this.FindElementIfExists(By.Id("span_debtors"));
                if (ReferenceEquals(element2, null))
                {
                    element2 = this.FindElementIfExists(By.Id("span_debtors"));
                    if (ReferenceEquals(element2, null))
                    {
                        this.FormFillingErrorMSG = "List Debtors Not Found";
                        return 0;
                    }
                }
                count = element2.FindElements(By.CssSelector("input")).Count;
            }
            else
            {
                this.FormFillingErrorMSG = "Search Debtor Dialog Search Button Not Found";
                count = 0;
            }
            return count;
        }

        private void ShowDriverState()
        {
            if (this.is_takescreenshot)
            {
                Console.WriteLine(this.driver.Url);
                Console.WriteLine(this.driver.Title);
                Console.WriteLine(this.driver.SessionId);
            }
        }

        private void takescreenshot(string name)
        {
            if (this.is_takescreenshot)
            {
                DirectoryInfo info = Directory.CreateDirectory("screenshots " + this.invoice_no);
                object[] objArray1 = new object[] { info.FullName, Path.DirectorySeparatorChar.ToString(), this.screenshot_no, "-", name, ".jpg" };
                this.driver.GetScreenshot().SaveAsFile(string.Concat(objArray1));
                this.screenshot_no++;
            }
        }

        private bool TryDownloadFile(string url, string fileName)
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(new Uri(url));
                request.ProtocolVersion = HttpVersion.Version10;
                request.CookieContainer = new CookieContainer();
                foreach (OpenQA.Selenium.Cookie cookie in this.driver.Manage().Cookies.AllCookies)
                {
                    System.Net.Cookie cookie2 = new System.Net.Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain);
                    request.CookieContainer.Add(cookie2);
                }
                using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (FileStream stream2 = System.IO.File.Create(fileName))
                        {
                            byte[] buffer = new byte[0x1000];
                            while (true)
                            {
                                int count = stream.Read(buffer, 0, buffer.Length);
                                if (count <= 0)
                                {
                                    break;
                                }
                                stream2.Write(buffer, 0, count);
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception exception1)
            {
                Console.WriteLine(exception1.Message);
                return false;
            }
        }
    }
}


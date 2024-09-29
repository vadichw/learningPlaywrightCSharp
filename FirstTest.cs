//using Microsoft.Playwright;

//namespace LearningPlaywrightCSharp;

//public class Tests
//{
//    [SetUp]
//    public void Setup()
//    {
//    }

//    [Test]
//    public async Task Test1()
//    {
//        // Initilization Playwright 
//        using var playwright = await Playwright.CreateAsync();
//        // Initilization Browser
//        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { 
//            Headless = false, 
//        });
//        // Initilization page
//        var page = await browser.NewPageAsync();
//        // Go to url
//        await page.GotoAsync("http://www.eaapp.somee.com");
//        // Click on Login
//        await page.ClickAsync("text=Login");
//        // Make screen
//        /* await page.ScreenshotAsync(new PageScreenshotOptions { 
//            Path = "C:\\Vadim\\learningPlaywrightCSharp\\NewScreen.jpg" 
//        }); */

//        await page.FillAsync("#UserName", "admin");
//        await page.FillAsync("#Password", "password");
//        await page.ClickAsync("text=Log in");
//        var isExist = await page.Locator("text=Employee Details").IsVisibleAsync();
//        Assert.IsTrue(isExist);
//    }
//}
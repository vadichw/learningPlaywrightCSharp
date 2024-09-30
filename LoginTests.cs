using LearningPlaywrightCSharp.Pages;
using Microsoft.Playwright;

namespace LearningPlaywrightCSharp.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    //[Test]
    //public async Task TestLogin()
    //{ 
    //    using var playwright = await Playwright.CreateAsync();
    //    await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    //    {
    //        Headless = false,
    //    });
    //    var page = await browser.NewPageAsync();
    //    await page.GotoAsync("http://www.eaapp.somee.com");

    //    LoginPage loginPage = new LoginPage(page);

    //    await loginPage.ClickLogin();
    //    await loginPage.Login("admin", "password");

    //    var isExist = await loginPage.IsEmployeeDetailsExist();
    //    Assert.IsTrue(isExist);

    //}

    [Test]
    public async Task TestNetwork()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var page = await browser.NewPageAsync();
        LoginPage loginPage = new LoginPage(page);

        await page.GotoAsync("http://www.eaapp.somee.com");
        await loginPage.ClickLogin();

        await loginPage.Login("admin", "password");

        ////// GET
        //var waitForRequest = page.WaitForRequestAsync("**/Employee");
        //await loginPage.ClickEmployeeList();
        //var getRequest = await waitForRequest;

        ////// 200 status
        //var waitForResponse = page.WaitForResponseAsync("**/Employee");
        //await loginPage.ClickEmployeeList();
        //var getResponse = await waitForResponse;

        var response = await page.RunAndWaitForResponseAsync(async () =>
        {
            await loginPage.ClickEmployeeList();
        }, response => response.Url.Contains("/Employee") && response.Status == 200);
        Console.WriteLine(response.Status);

        var isExist = await loginPage.IsEmployeeDetailsExist();
        Assert.IsTrue(isExist);

    }
}
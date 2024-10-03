using LearningPlaywrightCSharp.Pages;
using Microsoft.Playwright;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

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

    //[Test]
    //public async Task TestNetwork()
    //{
    //    using var playwright = await Playwright.CreateAsync();
    //    await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    //    {
    //        Headless = false,
    //    });
    //    var page = await browser.NewPageAsync();

    //    LoginPage loginPage = new LoginPage(page);

    //    await page.GotoAsync("http://www.eaapp.somee.com");
    //    await loginPage.ClickLogin();

    //    await loginPage.Login("admin", "password");

    //    ////// GET
    //    //var waitForRequest = page.WaitForRequestAsync("**/Employee");
    //    //await loginPage.ClickEmployeeList();
    //    //var getRequest = await waitForRequest;

    //    ////// 200 status
    //    //var waitForResponse = page.WaitForResponseAsync("**/Employee");
    //    //await loginPage.ClickEmployeeList();
    //    //var getResponse = await waitForResponse;

    //    var response = await page.RunAndWaitForResponseAsync(async () =>
    //    {
    //        await loginPage.ClickEmployeeList();
    //    }, response => response.Url.Contains("/Employee") && response.Status == 200);
    //    Console.WriteLine(response.Status);

    //    var isExist = await loginPage.IsEmployeeDetailsExist();
    //    Assert.IsTrue(isExist);

    //}


    //[Test]
    //[Description("Block all images on page")]
    //public async Task? TestFlipNetwork()
    //{
    //    using var playwright = await Playwright.CreateAsync();
    //    await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    //    {
    //        Headless = false,
    //    });
    //    var context = await browser.NewContextAsync();
    //    var page = await context.NewPageAsync();


    //    await page.RouteAsync("**/*", async route =>
    //    {
    //        if (route.Request.ResourceType == "image")
    //            await route.AbortAsync();
    //        else
    //            await route.ContinueAsync();
    //    });


    //    await page.GotoAsync("https://www.flipkart.com/", new PageGotoOptions
    //    {
    //        WaitUntil = WaitUntilState.NetworkIdle,
    //    });



    //[Test]
    //public async Task? TestFlipNetwork2()
    //{
    //    using var playwright = await Playwright.CreateAsync();
    //    await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    //    {
    //        Headless = false,
    //    });
    //    var context = await browser.NewContextAsync();
    //    var page = await context.NewPageAsync();

    //    // Block Image
    //    await page.RouteAsync("**/*", async route =>
    //    {
    //        if (route.Request.ResourceType == "image")
    //            await route.AbortAsync();
    //        else
    //            await route.ContinueAsync();
    //    });

    //    page.Request += (_, request) => Console.WriteLine(request.Method + "---" + request.Url);
    //    page.Response += (_, response) => Console.WriteLine(response.Status + "---" + response.Url);


    //    await page.GotoAsync("https://www.flipkart.com/", new PageGotoOptions
    //    {
    //        WaitUntil = WaitUntilState.NetworkIdle,
    //    });
    //}


    [Test]
    public async Task TestResxFooter()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        await page.GotoAsync("https://avto.pro/");

        var actualsiteConditionsFooterName = await page.
            Locator("body > footer > div:nth-child(3) > div > div > div > ul:nth-child(1) > li:nth-child(1) > a").InnerTextAsync();

        string siteConditionsFooterName = Resources.ResourceManager.GetString("page.footer.useTerms", null);

        Assert.That(siteConditionsFooterName, Is.EqualTo(actualsiteConditionsFooterName));

        Console.WriteLine($"Resource: {siteConditionsFooterName}");
        Console.WriteLine($"Actual text: {actualsiteConditionsFooterName}");
    }

}


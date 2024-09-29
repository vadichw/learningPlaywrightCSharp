using LearningPlaywrightCSharp.Pages;
using Microsoft.Playwright;

namespace LearningPlaywrightCSharp.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task TestLogin()
    { 
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://www.eaapp.somee.com");

        LoginPage loginPage = new LoginPage(page);

        await loginPage.ClickLogin();
        await loginPage.Login("admin", "password");

        var isExist = await loginPage.IsEmployeeDetailsExist();
        Assert.IsTrue(isExist);

    }
}
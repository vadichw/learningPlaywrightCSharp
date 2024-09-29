using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace LearningPlaywrightCSharp;

public class NUnitPlaywright: PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("http://www.eaapp.somee.com", new PageGotoOptions { 
            WaitUntil = WaitUntilState.DOMContentLoaded
        });
    }

    [Test]
    public async Task Test1()
    {
        var lnkLogin = Page.Locator("text=Login");
        await lnkLogin.ClickAsync();

        await Page.FillAsync("#UserName", "admin");
        await Page.FillAsync("#Password", "password");

        var btnLogin = Page.Locator("input", new PageLocatorOptions { HasTextString = "log In" });
        await btnLogin.ClickAsync();

        await Expect(Page.Locator("text=Employee Details")).ToBeVisibleAsync();
    }
}
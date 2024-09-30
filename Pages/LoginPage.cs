using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LearningPlaywrightCSharp.Pages
{
    public class LoginPage
    {
        private IPage _page;
        public LoginPage(IPage page) => _page = page;
        private ILocator _lnkLogin => _page.Locator("text=Login");
        private ILocator _txtUserName => _page.Locator("#UserName");
        private ILocator _txtPassword => _page.Locator("#Password");
        private ILocator _btnLogin => _page.Locator("text=Log in");
        private ILocator _lnkEmployeeList => _page.Locator("text=Employee List");

        public async Task ClickLogin() // better use PageWaitForURLOptions
        {
            await _page.RunAndWaitForNavigationAsync(async () =>
            {
                await _lnkLogin.ClickAsync();
            }, new PageRunAndWaitForNavigationOptions
            {
                UrlRegex = new Regex(".*/Login")
            });
        }

        public async Task ClickEmployeeList()
        {
             await _lnkEmployeeList.ClickAsync();
        }

        public async Task Login(string username, string password)
        {
            await _txtUserName.FillAsync(username);
            await _txtPassword.FillAsync(password);
            await _btnLogin.ClickAsync();
        }

        public async Task<bool> IsEmployeeDetailsExist() => await _lnkEmployeeList.IsVisibleAsync();
    }

}

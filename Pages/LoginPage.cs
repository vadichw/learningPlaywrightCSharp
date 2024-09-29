using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private ILocator _lnkEmployeeDetaild => _page.Locator("text=Employee Details");

        public async Task ClickLogin() => await _lnkLogin.ClickAsync();

        public async Task Login(string username, string password)
        {
            await _txtUserName.FillAsync(username);
            await _txtPassword.FillAsync(password);
            await _btnLogin.ClickAsync();
        }

        public async Task<bool> IsEmployeeDetailsExist() => await _lnkEmployeeDetaild.IsVisibleAsync();
    }

}

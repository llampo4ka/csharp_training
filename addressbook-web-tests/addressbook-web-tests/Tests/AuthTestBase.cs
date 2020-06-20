﻿using NUnit.Framework;

namespace addressbook_web_tests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            app.Auth.Login(new AccountData("admin", "secret"));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActumDigitalDemo.Frameworks.Attributes;
using ActumDigitalDemo.Selenium;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ActumDigitalDemo.PageObjects
{
    internal class HomePage : BasePage
    {

        [FindsById("itemc")]
        public List<IWebElement> Categories { get; set; }

        public HomePage() {
            url = "https://www.demoblaze.com/index.html";
        }
    }
}

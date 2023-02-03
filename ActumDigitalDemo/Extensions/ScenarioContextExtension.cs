using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActumDigitalDemo.Selenium;
using TechTalk.SpecFlow;

namespace ActumDigitalDemo.Extensions
{
    internal static class ScenarioContextExtension
    {

        public static void SetCurrentPage (this ScenarioContext context, BasePage page) {
            context["currentPage"] = page;
        }
        
        public static T GetCurrentPage<T>(this ScenarioContext context) where T : BasePage {
            return context["currentPage"] as T;
        }
    }
}

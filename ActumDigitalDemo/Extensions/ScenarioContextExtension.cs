using ActumDigitalDemo.Selenium;

namespace ActumDigitalDemo.Extensions;

internal static class ScenarioContextExtension
{
    public static void SetCurrentPage(this ScenarioContext context, BasePage page) {
        context["currentPage"] = page;
    }

    public static T GetCurrentPage<T>(this ScenarioContext context) where T : BasePage => context["currentPage"] as T;
}
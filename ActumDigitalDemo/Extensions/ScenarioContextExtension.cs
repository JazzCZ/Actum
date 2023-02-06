using ActumDigitalDemo.Selenium;

namespace ActumDigitalDemo.Extensions;

internal static class ScenarioContextExtension
{
    public static void SetCurrentPage(this ScenarioContext context, BasePage page) {
        context["currentPage"] = page;
    }

    public static void SetCurrentComponent(this ScenarioContext context, BaseComponent component) {
        context["currentComponent"] = component;
    }

    public static T GetCurrentPage<T>(this ScenarioContext context) where T : BasePage => context["currentPage"] as T;

    public static T GetCurrentComponent<T>(this ScenarioContext context) where T : BaseComponent => context["currentComponent"] as T;
}
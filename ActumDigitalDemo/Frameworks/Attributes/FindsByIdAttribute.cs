using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ActumDigitalDemo.Frameworks.Attributes;

[Binding]
internal class FindsByIdAttribute : AbstractFindsByAttribute
{
    public override By Finder => By.Id(_id);
    private readonly string _id;

    public FindsByIdAttribute(string id) {
        _id = id ?? throw new ArgumentNullException(nameof(id));
    }
}
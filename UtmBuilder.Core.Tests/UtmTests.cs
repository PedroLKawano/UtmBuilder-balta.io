using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests;

[TestClass]
public class UtmTests
{
    private const string Result = "https://balta.io/" +
                                  "?utm_source=src" +
                                  "&utm_medium=med" +
                                  "&utm_campaign=nme" +
                                  "&utm_id=id" +
                                  "&utm_term=ter" +
                                  "&utm_content=ctn";
    private readonly Url _url = new(address: "https://balta.io/");
    private readonly Campaign _campaign = new(
            source: "src",
            medium: "med",
            name: "nme",
            id: "id",
            term: "ter",
            content: "ctn");

    [TestMethod]
    public void ShouldReturnUrlFromUtm()
    {
        var utm = new Utm(_url, _campaign);

        Assert.AreEqual(expected: Result, actual: utm.ToString());
        Assert.AreEqual(expected: Result, actual: (string)utm);
    }

    [TestMethod]
    public void ShouldReturnUtmFromUrl()
    {
        Utm utm = Result;
        Assert.AreEqual(expected: "https://balta.io/", actual: utm.Url.Address);
        Assert.AreEqual(expected: "src", actual: utm.Campaign.Source);
        Assert.AreEqual(expected: "med", actual: utm.Campaign.Medium);
        Assert.AreEqual(expected: "nme", actual: utm.Campaign.Name);
        Assert.AreEqual(expected: "id", actual: utm.Campaign.Id);
        Assert.AreEqual(expected: "ter", actual: utm.Campaign.Term);
        Assert.AreEqual(expected: "ctn", actual: utm.Campaign.Content);
    }
}
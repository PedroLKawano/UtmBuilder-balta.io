using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects;

[TestClass]
public class UrlTests
{
    private const string InvalidUrl = "banana";
    private const string ValidUrl = "https://balta.io";

    [TestMethod]
    [ExpectedException(typeof(InvalidUrlException))]
    public void ShouldReturnExceptionWhenUrlIsInvalid()
    {
        new Url(address: InvalidUrl);
    }

    [TestMethod]
    public void ShouldNotReturnExceptionWhenUrlIsValid()
    {
        new Url(ValidUrl);
        Assert.IsTrue(true);
    }

    [TestMethod]
    [DataRow(data1: " ", moreData: true)]
    [DataRow(data1: "http", moreData: true)]
    [DataRow(data1: "banana", moreData: true)]
    [DataRow(data1: "https://balta.io", moreData: false)]
    public void TestUrl(
        string link,
        bool expectException)
    {
        if (expectException)
        {
            try
            {
                new Url(link);
                Assert.Fail();
            }
            catch (InvalidUrlException)
            {
                Assert.IsTrue(true);
            }
        }
        else
        {
            new Url(link);
            Assert.IsTrue(true);
        }
    }
}
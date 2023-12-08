using Microsoft.AspNetCore.Mvc;

namespace route_bug.Controllers;

public class HomeController : Controller
{
	private string CreateUrl(string templateId) {
		return this.Url.Action(nameof(Do), new {templateId});
	}

    public IActionResult Index()
    {
		// Redirect to "/do/SomeTemplate"
		return Redirect(this.CreateUrl("SomeTemplate"));
    }

	[Route("do/{templateId}")]
    public IActionResult Do(string templateId)
    {
		// The view creates a link to "/do/SomeTemplate/Bar":
        return View("Do", templateId);
    }

	[Route("do/{templateId}/{mode}")]
    public IActionResult Do(string templateId, Mode mode)
    {
		Console.WriteLine($"Do with mode ({mode})), redirecting to regular do.");
		var redirectUrl =  this.CreateUrl(templateId);
		Console.WriteLine("Will redirect to: " + redirectUrl);
		// this will result in an infinite redirect loop, as the URL created is "/do/SomeTemplate/Bar" instead of
		// "/do/SomeTemplate":
        return Redirect(redirectUrl);
    }
}

public enum Mode {
	Foo,
	Bar,
	Baz,
}

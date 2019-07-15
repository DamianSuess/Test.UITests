using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Test.UITests.UITestBench.Helpers
{
  public static class UIHelpers
  {
    public static void EnterText(Query textEntryQuery, string text, IApp app)
    {
      app.ClearText(textEntryQuery);
      app.EnterText(textEntryQuery, text);
      app.DismissKeyboard();
    }
  }
}
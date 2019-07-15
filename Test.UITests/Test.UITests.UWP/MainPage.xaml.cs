namespace Test.UITests.UWP
{
  public sealed partial class MainPage
  {
    public MainPage()
    {
      this.InitializeComponent();

      LoadApplication(new Test.UITests.Client.App());
    }
  }
}

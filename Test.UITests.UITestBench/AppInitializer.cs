using Xamarin.UITest;

namespace Test.UITests.UITestBench
{
  public class AppInitializer
  {
    public static IApp StartApp(Platform platform)
    {
      if (platform == Platform.Android)
      {
        return ConfigureApp
          .Android
          // Cannot specify both InstalledApp/ApkFile. Choose one
          .InstalledApp("com.companyname.Test.UITests")
          //.ApkFile(@"C:\work\labs\Test.UITests\Test.UITests\Test.UITests.Android\bin\Debug\com.companyname.Test.UITests.apk")

          .EnableLocalScreenshots()
          .DeviceSerial("emulator-5554") // To run specific device
          .StartApp();
      }

      return ConfigureApp.iOS.StartApp();
    }
  }
}
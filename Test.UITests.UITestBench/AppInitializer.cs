using Xamarin.UITest;

namespace Test.UITests.UITestBench
{
  public class AppInitializer
  {
    public static IApp StartApp(Platform platform)
    {
      switch (platform)
      {
        case Platform.Android:
          return ConfigureApp
            .Android

            // Which app is this test for
            // Cannot specify both InstalledApp/ApkFile. Choose one
            .InstalledApp("com.companyname.Test.UITests")
            //.ApkFile(@"C:\work\labs\Test.UITests\Test.UITests\Test.UITests.Android\bin\Debug\com.companyname.Test.UITests.apk")

            .EnableLocalScreenshots()

            // Use to specify our local emulator
            // Comment out to pick actively running emulator
            // .DeviceSerial("emulator-5554") // To run specific device

            // Start app and clear AppData
            .StartApp(Xamarin.UITest.Configuration.AppDataMode.Clear);

        case Platform.iOS:
          return ConfigureApp.iOS.StartApp();

        default:
          throw new System.NotSupportedException();
      }
    }
  }
}
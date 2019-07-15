# Xamarin UITest Sample

This is a sample project for Xamarin.Forms UITests and aims to provide a simple setup and configuration guide

## NuGet Requirements
* NUnit (v3)
* NUnit3TestAdapters
* Xamarin.UITest

## Step 1 - Setup Environment
1. Set your Environment Variables
    * ANDROID_HOME=``"C:\Program Files (x86)\Android\android-sdk"``
    * JAVA_HOME=``"C:\Program Files\Android\jdk\microsoft_dist_openjdk_1.8.0.25"``
2. Create a main Xamarin.Forms project
3. Create your UTests project
    * Include the required NuGet packages above!
4. Create your first test

## Step 2 - Creating a Test
1. Create your ``AppInitializer.cs``
2. Create tests with the *AAA* principal
    * Arrange - _your variables_
    * Act - _perform actions_
    * Assert - _validate your actions_


# Pain Points
* See step 1
    * ANDROID_HOME
    * JAVA_HOME
* ``The running adb server is incompatible with the Android SDK version in use by UITest``
```
Message: System.Exception : The running adb server is incompatible with the Android SDK version in use by UITest:
    C:\Program Files (x86)\Android\android-sdk

You probably have multiple installations of the Android SDK and should update them or ensure that your IDE, simulator and shell all use the same instance.  The ANDROID_HOME environment variable can effect this.
```

* Choosing the right emulator
```
Message: System.Exception : Configured device serial 'emulator-5554' not found. DeviceSerial does not need to be specified if only 1 device is connected. Devices found: emulator-5556
```

# Further Learning
## Resources
* [Working with Xamarin.UITest](https://docs.microsoft.com/en-us/appcenter/test-cloud/uitest/working-with)
* https://theconfuzedsourcecode.wordpress.com/2018/10/28/getting-your-xamarin-uitests-to-actually-work-not-thanks-to-xamarin-docs/

### Learn
* [Using UITest](https://developer.xamarin.com/samples/xamarin-forms/UsingUITest/)
* Samples
    * https://medium.com/@frankiefoo/xamarin-forms-how-to-perform-automated-ui-test-254a01c87648
        * [Sample 1](https://github.com/xyfoo/learn-xamarin-ui-test/blob/master/XamarinFormsHelloWorld.UITest/Tests.cs)
    * https://github.com/brminnick/UITestSampleApp
    * https://theconfuzedsourcecode.wordpress.com/2018/10/28/getting-your-xamarin-uitests-to-actually-work-not-thanks-to-xamarin-docs/

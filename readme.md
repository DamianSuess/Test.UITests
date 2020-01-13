# Xamarin UITest Sample

This is a sample project for Xamarin.Forms UITests and aims to provide a simple setup and configuration guide

Author: [Damian Suess](https://www.linkedin.com/in/damiansuess/)

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
Did you ever get, ``The running adb server is incompatible with the Android SDK version in use by UITest``?

This message is CRAP because it can mean a number of problems

## Some Solutions
### Environemnt Variables
* Make sure your environment variable ``ANDROID_HOME`` is set correctly
* Make sure your environment variable ``JAVA_HOME`` is set correctly

### ADB Version
Ensure you have the right ADB version running. Currently Xamarin.UITest v3.0 wants to use ADB v1.0.39. Even better, they don't tell you which one it wants?!

But wait, it's July-2019 and the latest ADB is v1.0.40?!  Yes, i know. You may have to do the following

1. Navigate to %ANDROID_HOME%\
2. Validate your ADB version in the ``platform-tools`` folder
    * PowerShell: ``adb version``
    * Output: ``Android Debug Bridge version 1.0.40``
3. Find the right version in the obscurely named "platform-tools.old#######" folders
    * Currently, it wants ``v1.0.39``. Find it
4. Backup your old ``platform-tools`` folder by renaming it
5. Rename your ``..old-..`` as your **platform-tools**
    * I did a copy of the old folder & renamed it

### Generic Error Bullcrap
```
Message: System.Exception : The running adb server is incompatible with the Android SDK version in use by UITest:
    C:\Program Files (x86)\Android\android-sdk

You probably have multiple installations of the Android SDK and should update them or ensure that your IDE, simulator and shell all use the same instance.  The ANDROID_HOME environment variable can effect this.
```
### Choosing the right emulator
If you ever get the following
```
Message: System.Exception : Configured device serial 'emulator-5554' not found. DeviceSerial does not need to be specified if only 1 device is connected. Devices found: emulator-5556
```

Try setting the ``.DeviceSerial("emulator-5554")`` in your ``AppInitializer.cs`` file
```cs
  return ConfigureApp
    .Android
    .InstalledApp("com.companyname.Test.UITests")
    .EnableLocalScreenshots()
    .DeviceSerial("emulator-5554") // To run specific device
    .StartApp(Xamarin.UITest.Configuration.AppDataMode.Clear);
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

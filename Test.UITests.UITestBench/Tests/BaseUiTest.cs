/* Copyright Xeno Innovations, Inc. 2019
 * Author:  Damian Suess
 * Date:    2019-7-14
 * File:    BaseUiTest.cs
 * Description:
 *  Base UITest class
 */

using NUnit.Framework;
using Test.UITests.UITestBench.Helpers;
using Xamarin.UITest;

namespace Test.UITests.UITestBench
{
  [TestFixture(Platform.Android)]
  // [TestFixture(Platform.iOS)]
  public abstract class BaseUiTest
  {
    private readonly Platform _platform;

    protected IApp _app { get; private set; }

    protected BaseUiTest(Platform platform) => _platform = platform;

    [SetUp]
    virtual public void BeforeEachTest()
    {
      UIHelpers.AppContext = AppInitializer.StartApp(_platform);
      _app = UIHelpers.AppContext;
    }
  }
}
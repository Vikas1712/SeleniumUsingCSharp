using System;
using System.Diagnostics;

namespace SeleniumCSharpNetCore.Extensions
{
    public static class WebDriverExtension
    {
        internal static void WaitForPageToLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(drv =>
            {
                string state = drv.ExecuteJs("return document.readyState").ToString().ToLower();
                return state == "complete";
            }, Settings.DefaultWait);
        }

        internal static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            bool execute(T arg)
            {
                try
                {
                    return condition(arg);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }

            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }

        internal static object ExecuteJs(this IWebDriver driver, string script) => ((IJavaScriptExecutor)driver).ExecuteScript(script);

        internal static void SwitchToIFrame(this IWebDriver driver)
        {
            IWebElement iframe = driver.FindElement(By.TagName("iframe"));
            DriverContext.Driver.SwitchTo().Frame(iframe);
        }
    }
}
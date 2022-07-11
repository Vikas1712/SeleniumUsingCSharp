/*
ConfigReader file read the custom XML file
We are using System.XML namespace and will be using
XPathItem and XPathDocument classes to perform operations.
*/

using System;
using System.IO;
using System.Xml.XPath;

namespace SeleniumCSharpNetCore.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            XPathItem aut, username, password, browser, testtype, islog, isreport, buildname, defaultWait;

            string strFilename = Environment.CurrentDirectory.ToString() + "\\Config\\GlobalConfig.xml";
            FileStream stream = new(strFilename, FileMode.Open);
            XPathDocument document = new(stream);
            XPathNavigator navigator = document.CreateNavigator();

            //Get XML Details and pass it in XPathItem type variables
            aut = navigator.SelectSingleNode("SeleniumCSharpFramework/RunSettings/AUT");
            username = navigator.SelectSingleNode("SeleniumCSharpFramework/RunSettings/Username");
            password = navigator.SelectSingleNode("SeleniumCSharpFramework/RunSettings/Password");
            browser = navigator.SelectSingleNode("SeleniumCSharpFramework/RunSettings/Browser");
            buildname = navigator.SelectSingleNode("SeleniumCSharpFramework/RunSettings/BuildName");
            testtype = navigator.SelectSingleNode("SeleniumCSharpFramework/RunSettings/TestType");
            islog = navigator.SelectSingleNode("SeleniumCSharpFramework/RunSettings/IsLog");
            isreport = navigator.SelectSingleNode("SeleniumCSharpFramework/RunSettings/IsReport");
            defaultWait = navigator.SelectSingleNode("SeleniumCSharpFramework/RunSettings/DefaultWait");
            //Set XML Details in the property to be used accross framework
            Settings.AUT = aut.Value.ToString();
            Settings.UserName = username.Value.ToString();
            Settings.Password = password.Value.ToString();
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), browser.Value.ToString());
            Settings.BuildName = buildname.Value.ToString();
            Settings.TestType = testtype.Value.ToString();
            Settings.IsLog = islog.Value.ToString();
            Settings.IsReport = isreport.Value.ToString();
            Settings.DefaultWait = int.Parse(defaultWait.Value);
        }
    }
}
/*
Selenium support different browser like chrome, firefox, edge etc
Strongly-typed code, we can do using enum by creating browser type with enum
and call them with it own class
*/

namespace SeleniumCSharpNetCore.Base
{
    public class Browser
    {
        public Browser Type { get; set; }
    }

    public enum BrowserType
    {
        Edge,
        Firefox,
        Chrome,
        Opera
    }
}
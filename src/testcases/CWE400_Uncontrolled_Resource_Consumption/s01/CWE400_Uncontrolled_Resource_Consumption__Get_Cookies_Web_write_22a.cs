/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE400_Uncontrolled_Resource_Consumption__Get_Cookies_Web_write_22a.cs
Label Definition File: CWE400_Uncontrolled_Resource_Consumption.label.xml
Template File: sources-sinks-22a.tmpl.cs
*/
/*
 * @description
 * CWE: 400 Uncontrolled Resource Consumption
 * BadSource: Get_Cookies_Web Read count from the first cookie using Cookies
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: write
 *    GoodSink: Write to a file count number of times, but first validate count
 *    BadSink : Write to a file count number of times
 * Flow Variant: 22 Control flow: Flow controlled by value of a public static variable. Sink functions are in a separate file from sources.
 *
 * */

using TestCaseSupport;
using System;

using System.Web;


namespace testcases.CWE400_Uncontrolled_Resource_Consumption
{
class CWE400_Uncontrolled_Resource_Consumption__Get_Cookies_Web_write_22a : AbstractTestCaseWeb
{

    /* The public static variable below is used to drive control flow in the sink function. */
    public static bool badPublicStatic = false;
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        int count = 0;
        count = int.MinValue; /* initialize count in case there are no cookies */
        /* Read count from cookies */
        {
            HttpCookieCollection cookieSources = req.Cookies;
            if (cookieSources != null)
            {
                /* POTENTIAL FLAW: Read count from the first cookie value */
                string stringNumber = cookieSources[0].Value;
                try
                {
                    count = int.Parse(stringNumber.Trim());
                }
                catch (FormatException exceptNumberFormat)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception reading count from cookie");
                }
            }
        }
        badPublicStatic = true;
        CWE400_Uncontrolled_Resource_Consumption__Get_Cookies_Web_write_22b.BadSink(count , req, resp);
    }
#endif //omitbad
    /* The public static variables below are used to drive control flow in the sink functions. */
    public static bool goodB2G1PublicStatic = false;
    public static bool goodB2G2PublicStatic = false;
    public static bool goodG2BPublicStatic = false;
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodB2G1(req, resp);
        GoodB2G2(req, resp);
        GoodG2B(req, resp);
    }

    /* goodB2G1() - use badsource and goodsink by setting the static variable to false instead of true */
    private void GoodB2G1(HttpRequest req, HttpResponse resp)
    {
        int count = 0;
        count = int.MinValue; /* initialize count in case there are no cookies */
        /* Read count from cookies */
        {
            HttpCookieCollection cookieSources = req.Cookies;
            if (cookieSources != null)
            {
                /* POTENTIAL FLAW: Read count from the first cookie value */
                string stringNumber = cookieSources[0].Value;
                try
                {
                    count = int.Parse(stringNumber.Trim());
                }
                catch (FormatException exceptNumberFormat)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception reading count from cookie");
                }
            }
        }
        goodB2G1PublicStatic = false;
        CWE400_Uncontrolled_Resource_Consumption__Get_Cookies_Web_write_22b.GoodB2G1Sink(count , req, resp);
    }

    /* goodB2G2() - use badsource and goodsink by reversing the blocks in the if in the sink function */
    private void GoodB2G2(HttpRequest req, HttpResponse resp)
    {
        int count = 0;
        count = int.MinValue; /* initialize count in case there are no cookies */
        /* Read count from cookies */
        {
            HttpCookieCollection cookieSources = req.Cookies;
            if (cookieSources != null)
            {
                /* POTENTIAL FLAW: Read count from the first cookie value */
                string stringNumber = cookieSources[0].Value;
                try
                {
                    count = int.Parse(stringNumber.Trim());
                }
                catch (FormatException exceptNumberFormat)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception reading count from cookie");
                }
            }
        }
        goodB2G2PublicStatic = true;
        CWE400_Uncontrolled_Resource_Consumption__Get_Cookies_Web_write_22b.GoodB2G2Sink(count , req, resp);
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        int count = 0;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        count = 2;
        goodG2BPublicStatic = true;
        CWE400_Uncontrolled_Resource_Consumption__Get_Cookies_Web_write_22b.GoodG2BSink(count , req, resp);
    }
#endif //omitgood
}
}

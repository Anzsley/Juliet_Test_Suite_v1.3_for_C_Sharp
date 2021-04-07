/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE81_XSS_Error_Message__Web_QueryString_Web_17.cs
Label Definition File: CWE81_XSS_Error_Message__Web.label.xml
Template File: sources-sink-17.tmpl.cs
*/
/*
* @description
* CWE: 81 Cross Site Scripting (XSS) in Error Message
* BadSource: QueryString_Web Parse id param out of the URL query string (without using getParameter())
* GoodSource: A hardcoded string
* BadSink: ErrorStatusCode XSS in StatusCode
* Flow Variant: 17 Control flow: for loops
*
* */

using TestCaseSupport;
using System;

using System.Web;


namespace testcases.CWE81_XSS_Error_Message
{

class CWE81_XSS_Error_Message__Web_QueryString_Web_17 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    /* uses badsource and badsink */
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
        data = ""; /* initialize data in case id is not in query string */
        /* POTENTIAL FLAW: Parse id param out of the URL querystring (without using getParameter()) */
        {
            if (req.QueryString["id"] != null)
            {
                data = req.QueryString["id"];
            }
        }
        for (int i = 0; i < 1; i++)
        {
            if (data != null)
            {
                /* POTENTIAL FLAW: script code (e.g. id=<script>alert('xss')</script>) is sent to the client; */
                resp.StatusCode = 404;
                resp.StatusDescription = "<br>Bad() - Parameter name has value " + data;
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink by reversing the block outside the
     * for statement with the one in the for statement */
    private void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        string data;
        /* FIX: Use a hardcoded string */
        data = "foo";
        for (int i = 0; i < 1; i++)
        {
            if (data != null)
            {
                /* POTENTIAL FLAW: script code (e.g. id=<script>alert('xss')</script>) is sent to the client; */
                resp.StatusCode = 404;
                resp.StatusDescription = "<br>Bad() - Parameter name has value " + data;
            }
        }
    }

    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B(req, resp);
    }
#endif //omitgood
}
}

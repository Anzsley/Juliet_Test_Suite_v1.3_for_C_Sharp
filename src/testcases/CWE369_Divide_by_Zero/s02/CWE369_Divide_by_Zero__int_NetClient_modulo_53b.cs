/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE369_Divide_by_Zero__int_NetClient_modulo_53b.cs
Label Definition File: CWE369_Divide_by_Zero__int.label.xml
Template File: sources-sinks-53b.tmpl.cs
*/
/*
 * @description
 * CWE: 369 Divide by zero
 * BadSource: NetClient Read data from a web server with WebClient
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: modulo
 *    GoodSink: Check for zero before modulo
 *    BadSink : Modulo by a value that may be zero
 * Flow Variant: 53 Data flow: data passed as an argument from one method through two others to a fourth; all four functions are in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE369_Divide_by_Zero
{
class CWE369_Divide_by_Zero__int_NetClient_modulo_53b
{
#if (!OMITBAD)
    public static void BadSink(int data )
    {
        CWE369_Divide_by_Zero__int_NetClient_modulo_53c.BadSink(data );
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(int data )
    {
        CWE369_Divide_by_Zero__int_NetClient_modulo_53c.GoodG2BSink(data );
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(int data )
    {
        CWE369_Divide_by_Zero__int_NetClient_modulo_53c.GoodB2GSink(data );
    }
#endif
}
}

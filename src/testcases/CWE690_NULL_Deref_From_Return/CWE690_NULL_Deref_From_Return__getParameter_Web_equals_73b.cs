/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE690_NULL_Deref_From_Return__getParameter_Web_equals_73b.cs
Label Definition File: CWE690_NULL_Deref_From_Return.label.xml
Template File: sources-sinks-73b.tmpl.cs
*/
/*
 * @description
 * CWE: 690 Unchecked return value is null, leading to a null pointer dereference.
 * BadSource: getParameter_Web Set data to return of getParameter_Web
 * GoodSource: Set data to fixed, non-null String
 * Sinks: equals
 *    GoodSink: Call equals() on string literal (that is not null)
 *    BadSink : Call equals() on possibly null object
 * Flow Variant: 73 Data flow: data passed in a LinkedList from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;
using System.Collections.Generic;

using System.Web;

namespace testcases.CWE690_NULL_Deref_From_Return
{
class CWE690_NULL_Deref_From_Return__getParameter_Web_equals_73b
{
#if (!OMITBAD)
    public static void BadSink(LinkedList<string> dataLinkedList , HttpRequest req, HttpResponse resp)
    {
        string data = dataLinkedList.Last.Value;
        /* POTENTIAL FLAW: data could be null */
        if(data.Equals("CWE690"))
        {
            IO.WriteLine("data is CWE690");
        }
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use GoodSource and BadSink */
    public static void GoodG2BSink(LinkedList<string> dataLinkedList , HttpRequest req, HttpResponse resp)
    {
        string data = dataLinkedList.Last.Value;
        /* POTENTIAL FLAW: data could be null */
        if(data.Equals("CWE690"))
        {
            IO.WriteLine("data is CWE690");
        }
    }

    /* goodB2G() - use BadSource and GoodSink */
    public static void GoodB2GSink(LinkedList<string> dataLinkedList , HttpRequest req, HttpResponse resp)
    {
        string data = dataLinkedList.Last.Value;
        /* FIX: call equals() on string literal (that is not null) */
        if("CWE690".Equals(data))
        {
            IO.WriteLine("data is CWE690");
        }
    }
#endif
}
}

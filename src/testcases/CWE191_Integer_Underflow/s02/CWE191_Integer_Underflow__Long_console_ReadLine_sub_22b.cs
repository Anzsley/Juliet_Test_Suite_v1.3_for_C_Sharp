/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE191_Integer_Underflow__Long_console_ReadLine_sub_22b.cs
Label Definition File: CWE191_Integer_Underflow.label.xml
Template File: sources-sinks-22b.tmpl.cs
*/
/*
 * @description
 * CWE: 191 Integer Underflow
 * BadSource: console_ReadLine Read data from the console using ReadLine
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: sub
 *    GoodSink: Ensure there will not be an underflow before subtracting 1 from data
 *    BadSink : Subtract 1 from data, which can cause an Underflow
 * Flow Variant: 22 Control flow: Flow controlled by value of a public static variable. Sink functions are in a separate file from sources.
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE191_Integer_Underflow
{
class CWE191_Integer_Underflow__Long_console_ReadLine_sub_22b
{
#if (!OMITBAD)
    public static void BadSink(long data )
    {
        if (CWE191_Integer_Underflow__Long_console_ReadLine_sub_22a.badPublicStatic)
        {
            /* POTENTIAL FLAW: if data == long.MinValue, this will overflow */
            long result = (long)(data - 1);
            IO.WriteLine("result: " + result);
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0L;
        }
    }
#endif

#if (!OMITGOOD)
    /* goodB2G1() - use badsource and goodsink by setting the static variable to false instead of true */
    public static void GoodB2G1Sink(long data )
    {
        if (CWE191_Integer_Underflow__Long_console_ReadLine_sub_22a.goodB2G1PublicStatic)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0L;
        }
        else
        {
            /* FIX: Add a check to prevent an overflow from occurring */
            if (data > long.MinValue)
            {
                long result = (long)(data - 1);
                IO.WriteLine("result: " + result);
            }
            else
            {
                IO.WriteLine("data value is too small to perform subtraction.");
            }
        }
    }

    /* goodB2G2() - use badsource and goodsink by reversing the blocks in the if in the sink function */
    public static void GoodB2G2Sink(long data )
    {
        if (CWE191_Integer_Underflow__Long_console_ReadLine_sub_22a.goodB2G2PublicStatic)
        {
            /* FIX: Add a check to prevent an overflow from occurring */
            if (data > long.MinValue)
            {
                long result = (long)(data - 1);
                IO.WriteLine("result: " + result);
            }
            else
            {
                IO.WriteLine("data value is too small to perform subtraction.");
            }
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0L;
        }
    }

    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(long data )
    {
        if (CWE191_Integer_Underflow__Long_console_ReadLine_sub_22a.goodG2BPublicStatic)
        {
            /* POTENTIAL FLAW: if data == long.MinValue, this will overflow */
            long result = (long)(data - 1);
            IO.WriteLine("result: " + result);
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0L;
        }
    }
#endif
}
}

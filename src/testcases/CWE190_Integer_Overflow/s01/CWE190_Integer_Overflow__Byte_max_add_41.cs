/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE190_Integer_Overflow__Byte_max_add_41.cs
Label Definition File: CWE190_Integer_Overflow.label.xml
Template File: sources-sinks-41.tmpl.cs
*/
/*
 * @description
 * CWE: 190 Integer Overflow
 * BadSource: max Set data to the max value for byte
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: add
 *    GoodSink: Ensure there will not be an overflow before adding 1 to data
 *    BadSink : Add 1 to data, which can cause an overflow
 * Flow Variant: 41 Data flow: data passed as an argument from one method to another in the same class
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE190_Integer_Overflow
{
class CWE190_Integer_Overflow__Byte_max_add_41 : AbstractTestCase
{
#if (!OMITBAD)
    private static void BadSink(byte data )
    {
        /* POTENTIAL FLAW: if data == byte.MaxValue, this will overflow */
        byte result = (byte)(data + 1);
        IO.WriteLine("result: " + result);
    }

    public override void Bad()
    {
        byte data;
        /* POTENTIAL FLAW: Use the maximum size of the data type */
        data = byte.MaxValue;
        BadSink(data  );
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    private static void GoodG2BSink(byte data )
    {
        /* POTENTIAL FLAW: if data == byte.MaxValue, this will overflow */
        byte result = (byte)(data + 1);
        IO.WriteLine("result: " + result);
    }

    /* goodG2B() - use goodsource and badsink */
    private static void GoodG2B()
    {
        byte data;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        data = 2;
        GoodG2BSink(data  );
    }

    private static void GoodB2GSink(byte data )
    {
        /* FIX: Add a check to prevent an overflow from occurring */
        if (data < byte.MaxValue)
        {
            byte result = (byte)(data + 1);
            IO.WriteLine("result: " + result);
        }
        else
        {
            IO.WriteLine("data value is too large to perform addition.");
        }
    }

    /* goodB2G() - use badsource and goodsink */
    private static void GoodB2G()
    {
        byte data;
        /* POTENTIAL FLAW: Use the maximum size of the data type */
        data = byte.MaxValue;
        GoodB2GSink(data  );
    }
#endif //omitgood
}
}

/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE197_Numeric_Truncation_Error__float_Environment_to_long_66a.cs
Label Definition File: CWE197_Numeric_Truncation_Error__float.label.xml
Template File: sources-sink-66a.tmpl.cs
*/
/*
 * @description
 * CWE: 197 Numeric Truncation Error
 * BadSource: Environment Read data from an environment variable
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: to_long
 *    BadSink : Convert data to a long
 * Flow Variant: 66 Data flow: data passed in an array from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;

namespace testcases.CWE197_Numeric_Truncation_Error
{

class CWE197_Numeric_Truncation_Error__float_Environment_to_long_66a : AbstractTestCase
{
#if (!OMITBAD)
    public override  void Bad()
    {
        float data;
        data = float.MinValue; /* Initialize data */
        /* get environment variable ADD */
        /* FLAW: Read data from an environment variable */
        {
            string stringNumber = Environment.GetEnvironmentVariable("ADD");
            if (stringNumber != null) // avoid NPD incidental warnings
            {
                try
                {
                    data = float.Parse(stringNumber.Trim());
                }
                catch (FormatException exceptNumberFormat)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception parsing data from string");
                }
            }
        }
        float[] dataArray = new float[5];
        dataArray[2] = data;
        CWE197_Numeric_Truncation_Error__float_Environment_to_long_66b.BadSink(dataArray  );
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
    }

    /* goodG2B() - use goodsource and badsink */
    private static void GoodG2B()
    {
        float data;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        data = 2;
        float[] dataArray = new float[5];
        dataArray[2] = data;
        CWE197_Numeric_Truncation_Error__float_Environment_to_long_66b.GoodG2BSink(dataArray  );
    }
#endif //omitgood
}
}

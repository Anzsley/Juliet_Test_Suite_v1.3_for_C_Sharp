/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE486_Compare_Classes_by_Name__basic_07.cs
Label Definition File: CWE486_Compare_Classes_by_Name__basic.label.xml
Template File: point-flaw-07.tmpl.cs
*/
/*
* @description
* CWE: 486 Compare Classes by Name
* Sinks:
*    GoodSink: properly compare class
*    BadSink : Compare class names
* Flow Variant: 07 Control flow: if(privateFive==5) and if(privateFive!=5)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE486_Compare_Classes_by_Name
{
class CWE486_Compare_Classes_by_Name__basic_07 : AbstractTestCase
{
    /* The variable below is not declared "readonly", but is never assigned
     * any other value so a tool should be able to identify that reads of
     * this will always give its initialized value.
     */
    private int privateFive = 5;
#if (!OMITBAD)
    public override void Bad()
    {
        if (privateFive == 5)
        {
            /* FLAW: Differentiating by name is not enough, since different classes in different packages may use the same name */
            testcases.CWE486_Compare_Classes_by_Name.HelperClass.CWE486_Compare_Classes_by_Name__Helper helperClass = new testcases.CWE486_Compare_Classes_by_Name.HelperClass.CWE486_Compare_Classes_by_Name__Helper();
            testcases.CWE486_Compare_Classes_by_Name.CWE486_Compare_Classes_by_Name__Helper helperClassRoot = new testcases.CWE486_Compare_Classes_by_Name.CWE486_Compare_Classes_by_Name__Helper();
            if (helperClassRoot.GetType().Name.Equals(helperClass.GetType().Name))
            {
                IO.WriteLine("Classes are the same");
            }
            else
            {
                /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
                IO.WriteLine("Classes are different");
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes privateFive==5 to privateFive!=5 */
    private void Good1()
    {
        if (privateFive != 5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            testcases.CWE486_Compare_Classes_by_Name.HelperClass.CWE486_Compare_Classes_by_Name__Helper helperClass = new testcases.CWE486_Compare_Classes_by_Name.HelperClass.CWE486_Compare_Classes_by_Name__Helper();
            testcases.CWE486_Compare_Classes_by_Name.CWE486_Compare_Classes_by_Name__Helper helperClassRoot = new testcases.CWE486_Compare_Classes_by_Name.CWE486_Compare_Classes_by_Name__Helper();
            /* FIX: Compare the class types and not the names */
            if (helperClassRoot.ToString().Equals(helperClass.ToString()))
            {
                /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
                IO.WriteLine("Classes are the same");
            }
            else
            {
                IO.WriteLine("Classes are different");
            }
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (privateFive == 5)
        {
            testcases.CWE486_Compare_Classes_by_Name.HelperClass.CWE486_Compare_Classes_by_Name__Helper helperClass = new testcases.CWE486_Compare_Classes_by_Name.HelperClass.CWE486_Compare_Classes_by_Name__Helper();
            testcases.CWE486_Compare_Classes_by_Name.CWE486_Compare_Classes_by_Name__Helper helperClassRoot = new testcases.CWE486_Compare_Classes_by_Name.CWE486_Compare_Classes_by_Name__Helper();
            /* FIX: Compare the class types and not the names */
            if (helperClassRoot.ToString().Equals(helperClass.ToString()))
            {
                /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
                IO.WriteLine("Classes are the same");
            }
            else
            {
                IO.WriteLine("Classes are different");
            }
        }
    }

    public override void Good()
    {
        Good1();
        Good2();
    }
#endif //omitgood
}
}

/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE476_NULL_Pointer_Dereference__null_check_after_deref_09.cs
Label Definition File: CWE476_NULL_Pointer_Dereference.pointflaw.label.xml
Template File: point-flaw-09.tmpl.cs
*/
/*
* @description
* CWE: 476 NULL Pointer Dereference
* Sinks: null_check_after_deref
*    GoodSink: Do not check for null after the object has been dereferenced
*    BadSink : Check for null after the object has already been dereferenced
* Flow Variant: 09 Control flow: if(IO.STATIC_READONLY_TRUE) and if(IO.STATIC_READONLY_FALSE)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE476_NULL_Pointer_Dereference
{
class CWE476_NULL_Pointer_Dereference__null_check_after_deref_09 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.STATIC_READONLY_TRUE)
        {
            {
                string myString = null;
                myString = "Hello";
                IO.WriteLine(myString.Length);
                /* FLAW: Check for null after dereferencing the object. This null check is unnecessary. */
                if (myString != null)
                {
                    myString = "my, how I've changed";
                }
                IO.WriteLine(myString.Length);
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes IO.STATIC_READONLY_TRUE to IO.STATIC_READONLY_FALSE */
    private void Good1()
    {
        if (IO.STATIC_READONLY_FALSE)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            {
                string myString = null;
                myString = "Hello";
                IO.WriteLine(myString.Length);
                /* FIX: Don't check for null since we wouldn't reach this line if the object was null */
                myString = "my, how I've changed";
                IO.WriteLine(myString.Length);
            }
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.STATIC_READONLY_TRUE)
        {
            {
                string myString = null;
                myString = "Hello";
                IO.WriteLine(myString.Length);
                /* FIX: Don't check for null since we wouldn't reach this line if the object was null */
                myString = "my, how I've changed";
                IO.WriteLine(myString.Length);
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

/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE510_Trapdoor__network_connection_04.cs
Label Definition File: CWE510_Trapdoor.badonly.label.xml
Template File: point-flaw-badonly-04.tmpl.cs
*/
/*
* @description
* CWE: 510 Trapdoor
* Sinks: network_connection
*    BadSink : Presence of a network connection
*    BadOnly (No GoodSink)
* Flow Variant: 04 Control flow: if(PRIVATE_CONST_TRUE)
*
* */

using TestCaseSupport;
using System;

using System.IO;
using System.Net;

namespace testcases.CWE510_Trapdoor
{
class CWE510_Trapdoor__network_connection_04 : AbstractTestCaseBadOnly
{
    /* The variable below are is "const", so a tool should
     * be able to identify that reads of it will always return its
     * initialized value.
     */
    private const bool PRIVATE_CONST_TRUE = true;
#if (!OMITBAD)
    public override void Bad()
    {
        if (PRIVATE_CONST_TRUE)
        {
            Stream streamInput = null;
            try
            {
                /* FLAW: direct usage of URI */
                Uri url = new Uri("http://123.123.123.123:80");
                WebRequest request = WebRequest.Create(url);
                streamInput = request.GetRequestStream();
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "caught IOException");
            }
            finally
            {
                try
                {
                    if (streamInput != null)
                    {
                        streamInput.Close();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "caught IOException");
                }
            }
        }
    }
#endif //omitbad
}
}

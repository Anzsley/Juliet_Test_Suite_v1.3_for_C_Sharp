/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE506_Embedded_Malicious_Code__screen_capture_14.cs
Label Definition File: CWE506_Embedded_Malicious_Code.badonly.label.xml
Template File: point-flaw-badonly-14.tmpl.cs
*/
/*
* @description
* CWE: 506 Embedded Malicious Code
* Sinks: screen_capture
*    BadSink : Perform a screen capture and save it to a file
*    BadOnly (No GoodSink)
* Flow Variant: 14 Control flow: if(IO.staticFive==5)
*
* */

using TestCaseSupport;
using System;

using System.Drawing;

namespace testcases.CWE506_Embedded_Malicious_Code
{
class CWE506_Embedded_Malicious_Code__screen_capture_14 : AbstractTestCaseBadOnly
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.staticFive == 5)
        {
            try
            {
                using (Bitmap memoryImage = new Bitmap(1000, 900))
                {
                    Size s = new Size(memoryImage.Width, memoryImage.Height);
                    Graphics memoryGraphics = Graphics.FromImage(memoryImage);
                    /* FLAW: Capture the screen shot of the area of the screen defined by the rectangle */
                    memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);
                    string str = string.Format(Environment.CurrentDirectory + @"\Screenshot.png");
                    memoryImage.Save(str);
                }
            }
            catch (ArgumentNullException exception)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exception, "Image is null or string format is null");
            }
            catch (System.ComponentModel.Win32Exception exception)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exception, "Screen capture failed");
            }
            catch (FormatException exception)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exception, "The string format for path to save screen capture is invalid");
            }
            catch (System.Runtime.InteropServices.ExternalException exception)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exception, "The image was saved with the wrong image format");
            }
        }
    }
#endif //omitbad
}
}

/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE315_Cleartext_Storage_in_Cookie__Web_81a.cs
Label Definition File: CWE315_Cleartext_Storage_in_Cookie__Web.label.xml
Template File: sources-sinks-81a.tmpl.cs
*/
/*
 * @description
 * CWE: 315 Cleartext storage of data in a cookie
 * BadSource:  Set data to credentials (without hashing or encryption)
 * GoodSource: Set data to a hash of credentials
 * Sinks:
 *    GoodSink: Hash data before storing in cookie
 *    BadSink : Store data directly in cookie
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */

using TestCaseSupport;
using System;

using System.Security.Cryptography;
using System.Text;
using System.Web;

using System.Security;

namespace testcases.CWE315_Cleartext_Storage_in_Cookie
{
class CWE315_Cleartext_Storage_in_Cookie__Web_81a : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
        using (SecureString securePwd = new SecureString())
        {
            using (SecureString secureUser = new SecureString())
            {
                for (int i = 0; i < "AP@ssw0rd".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("AP@ssw0rd"[i]);
                }
                for (int i = 0; i < "user".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("user"[i]);
                }
                /* POTENTIAL FLAW: Set data to credentials (without hashing or encryption) */
                data = secureUser.ToString() + ":" + securePwd.ToString();
            }
        }
        CWE315_Cleartext_Storage_in_Cookie__Web_81_base baseObject = new CWE315_Cleartext_Storage_in_Cookie__Web_81_bad();
        baseObject.Action(data , req, resp);
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B(req, resp);
        GoodB2G(req, resp);
    }

    /* goodG2B() - use GoodSource and BadSink */
    private void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        string data;
        using (SecureString securePwd = new SecureString())
        {
            using( SecureString secureUser = new SecureString())
            {
                for (int i = 0; i < "AP@ssw0rd".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("AP@ssw0rd"[i]);
                }
                for (int i = 0; i < "user".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("user"[i]);
                }
                /* FIX: Set data to a hash of credentials */
                {
                    string salt = "ThisIsMySalt";
                    using (SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider())
                    {
                        string credentialsToHash = secureUser.ToString() + ":" + securePwd.ToString();
                        byte[] buffer = Encoding.UTF8.GetBytes(string.Concat(salt, credentialsToHash));
                        byte[] hashedCredsAsBytes = sha512.ComputeHash(buffer);
                        data = IO.ToHex(hashedCredsAsBytes);
                    }
                }
            }
        }
        CWE315_Cleartext_Storage_in_Cookie__Web_81_base baseObject = new CWE315_Cleartext_Storage_in_Cookie__Web_81_goodG2B();
        baseObject.Action(data , req, resp);
    }

    /* goodB2G() - use BadSource and GoodSink */
    private void GoodB2G(HttpRequest req, HttpResponse resp)
    {
        string data;
        using (SecureString securePwd = new SecureString())
        {
            using (SecureString secureUser = new SecureString())
            {
                for (int i = 0; i < "AP@ssw0rd".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("AP@ssw0rd"[i]);
                }
                for (int i = 0; i < "user".Length; i++)
                {
                    /* INCIDENTAL: CWE-798 Use of Hard-coded Credentials */
                    securePwd.AppendChar("user"[i]);
                }
                /* POTENTIAL FLAW: Set data to credentials (without hashing or encryption) */
                data = secureUser.ToString() + ":" + securePwd.ToString();
            }
        }
        CWE315_Cleartext_Storage_in_Cookie__Web_81_base baseObject = new CWE315_Cleartext_Storage_in_Cookie__Web_81_goodB2G();
        baseObject.Action(data , req, resp);
    }
#endif //omitgood
}
}

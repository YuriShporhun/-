using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public static class RequiredSoftwareChecker
    {
        public static void CheckApplicationShortcut()
        {
            try
            {
                ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

                if (ad.IsFirstRun)
                {
                    Assembly code = Assembly.GetExecutingAssembly();

                    string company = string.Empty;
                    string description = string.Empty;

                    if (Attribute.IsDefined(code, typeof(AssemblyCompanyAttribute)))
                    {
                        AssemblyCompanyAttribute ascompany = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(code,
                            typeof(AssemblyCompanyAttribute));
                        company = ascompany.Company;
                    }

                    if (Attribute.IsDefined(code, typeof(AssemblyDescriptionAttribute)))
                    {
                        AssemblyDescriptionAttribute asdescription = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(code,
                            typeof(AssemblyDescriptionAttribute));
                        description = asdescription.Description;
                    }

                    if (company != string.Empty && description != string.Empty)
                    {
                        string desktopPath = string.Empty;
                        desktopPath = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                            "\\", description, ".appref-ms");

                        string shortcutName = string.Empty;
                        shortcutName = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs),
                            "\\", company, "\\", description, ".appref-ms");

                        System.IO.File.Copy(shortcutName, desktopPath, true);
                    }
                }
            }
            catch (Exception) { }
        }

        public static bool IsAdobeReaderInstalled()
        {
            RegistryKey adobe = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Adobe");
            if (null == adobe)
            {
                var policies = Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Policies");
                if (null == policies)
                {
                    return false;
                }
                adobe = policies.OpenSubKey("Adobe");
            }
            if (adobe == null)
            {
                return false;
            }
            else
            {
                RegistryKey acroRead = adobe.OpenSubKey("Acrobat Reader");
                if (acroRead == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

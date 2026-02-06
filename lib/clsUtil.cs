using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVLDBusinessLayer
{
    public class clsUtil
    {
        private static string _UsernameValueName = "Username";
        private static string _PasswordValueName = "Password";

        public static string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            try
            {
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }

                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            string fileName = sourceFile;
            FileInfo fileInfo = new FileInfo(fileName);
            string extn = fileInfo.Extension;
            return GenerateGUID() + extn;
        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            string destinationFolder = @"D:\DVLD\Images\";
            if(!CreateFolderIfDoesNotExist(destinationFolder))
            {
                return false;
            }

            string destinationFile = destinationFolder + ReplaceFileNameWithGUID(sourceFile);

            try
            {
                File.Copy(sourceFile, destinationFile, true);
                sourceFile = destinationFile;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static void SaveCredentials(string Username, string Password)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(clsGlobal.KeyPath))
                {
                    key.SetValue(_UsernameValueName, Username, RegistryValueKind.String);
                    key.SetValue(_PasswordValueName, Password, RegistryValueKind.String);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static (string Username, string Password) LoadCredentails()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(clsGlobal.KeyPath))
                {
                    if (key == null)
                        return (null, null);

                    string username = key.GetValue(_UsernameValueName) as string;
                    string password = key.GetValue(_PasswordValueName) as string;

                    return (username, password);
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (null, null);
            }
        }

        public static void DeleteCredentials()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(clsGlobal.KeyPath, true))
                {
                    if (key == null)
                        return;

                    key.DeleteValue(_UsernameValueName, false);
                    key.DeleteValue(_PasswordValueName, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

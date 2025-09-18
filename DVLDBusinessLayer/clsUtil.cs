using System;
using System.IO;

namespace DVLDBusinessLayer
{
    public class clsUtil
    {
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
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Recruitment.Application.Candidates.Common
{
   public static class UploadResume
    {
        public static string uploadResumeDoc(string filePath, string fileName, string resume, string userName, string password)
        {
            string ftpFilePath = string.Format("{0}/{1}", filePath, fileName);
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(ftpFilePath);
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

            ftpRequest.Credentials = new NetworkCredential(userName, password);

            var fileContents = Convert.FromBase64String(resume);
            ftpRequest.ContentLength = fileContents.Length;

            Stream requestStream = ftpRequest.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            response.Close();
            return ftpFilePath;
        }

    }
}

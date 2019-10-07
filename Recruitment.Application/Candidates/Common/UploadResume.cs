using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Recruitment.Application.Candidates.Common
{
   public static class UploadResume
    {
        #region FTP Upload
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
        #endregion
        #region Local Upload
        public static string uploadResumeDoc(string fileName, string resume)
        {
            if (resume == null || resume.Length == 0)
                return "No file selected";

           resume = resume.Split(',')[1];
           string filePath =  Path.Combine(Directory.GetCurrentDirectory(), "Resumes/");

            
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            var fileImageName = Guid.NewGuid().ToString();
            var fileExtension = Path.GetExtension(fileName);
            var bytes = Convert.FromBase64String(resume);
            var fileLocationWithName = filePath + fileImageName + fileExtension;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                IFormFile file = new FormFile(ms, 0, bytes.Length, null, fileImageName);
                using (var stream = new FileStream(fileLocationWithName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            
            return fileLocationWithName;
        }
        #endregion

        public static string downloadResumeDoc(string filePath)
        {
            try
            {
               WebClient downloadRequest = new WebClient();
                if (!System.IO.File.Exists(filePath))
                    throw new FileNotFoundException("Document not found.");
                byte[] fileContents = System.IO.File.ReadAllBytes(filePath);
                return Convert.ToBase64String(fileContents);
            }
            catch (Exception ex)
            {
               return null;
            }
        }
    }
}

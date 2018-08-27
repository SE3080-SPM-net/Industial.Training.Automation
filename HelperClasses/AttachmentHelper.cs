﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HelperClasses
{
    public class AttachmentHelper
    {
        public string SaveAttachment(int erpId, int customerId, int issueId, string serverPath, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var folderPath = Path.Combine(serverPath, erpId.ToString(), customerId.ToString(), issueId.ToString());

                //Create the directories if do not exist
                Directory.CreateDirectory(folderPath);


                var fileName = GetAutoGeneratedFileName(file.FileName);
                var path = Path.Combine(serverPath, erpId.ToString(), customerId.ToString(), issueId.ToString(), fileName);

                file.SaveAs(path);
                return fileName;
            }
            else
            {
                throw new ArgumentException("Invalid file size", "ContentLength");
            }
        }

        public string GetAutoGeneratedFileName(string filename)
        {
            return string.Concat(DateTime.Now.ToFileTime().ToString(), Path.GetExtension(filename));
        }

        public void CustomerGetAttachments(int erpId, int customerId, int issueId, string serverPath)
        {
            var folderPath = Path.Combine(serverPath, erpId.ToString(), customerId.ToString(), issueId.ToString());

            if (File.Exists(folderPath))
            {
                // This path is a file
                string[] dirs = Directory.GetFiles(folderPath);

                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                }

            }
        }
    }
}

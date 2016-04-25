using System;
using System.Collections.Specialized;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using NUnit.Framework;

namespace ClassLibrary1
{
    public class FileUploadTest
    {
        [Test]
        public void Test()
        {
            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent())
            {
                // Make sure to change API address  
                client.BaseAddress = new Uri("http://localhost:8278/");

                // Add  file content  
                var fileContent = new ByteArrayContent(File.ReadAllBytes(@"C:\Users\Administrator\Desktop\Sample.txt"));
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "Sample.txt"
                };
                content.Add(fileContent);

                //Add Parames content
                //NameValueCollection collection=new NameValueCollection()
                //{
                //    {"AttachmentCategoryId","9"}
                //};
                //foreach (var key in collection.AllKeys)
                //{
                //    var dataContent = new ByteArrayContent(Encoding.UTF8.GetBytes(collection[key]));
                //    dataContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                //    {
                //        Name = key
                //    };
                //    content.Add(dataContent);
                //} 
                

                // Make a call to Web API  
                var result = client.PostAsync("api/Service/File/AttachmentUpload", content).Result;

                Console.WriteLine(result.StatusCode);
                Console.ReadLine();
            }  
        }
    }
}
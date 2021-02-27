using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string AddAsync(IFormFile file)
        {

            var result = newPath(file);
            try
            {
                var sourcePath = Path.GetTempFileName();
                if (file.Length > 0)
                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                        file.CopyTo(stream);

                File.Move(sourcePath, result);
            }
            catch (Exception exception)
            {

                return exception.Message;
            }

            return result;
        }
        public static IResult DeleteAsync(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            var result = newPath(file);

            try
            {
                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(result, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                File.Delete(sourcePath);
            }
            catch (Exception excepiton)
            {
                return excepiton.Message;
            }

            return result;
        }

        public static string newPath(IFormFile file)
        {
            System.IO.FileInfo ff = new System.IO.FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var creatingUniqueFilename = Guid.NewGuid().ToString("D")
               + "-" + DateTime.Now.Month + "-"
               + DateTime.Now.Day + "-"
               + DateTime.Now.Year + fileExtension;

            string path = Path.Combine(Environment.CurrentDirectory + @"/wwwroot/Images");

            string result = $@"{path}\{creatingUniqueFilename}";

            return result;
        }
    }
}

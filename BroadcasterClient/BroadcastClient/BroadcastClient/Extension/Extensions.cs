using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadcastClient.Extension
{
    public static class Extensions
    {
        public static string FormFileToBase64(this IFormFile file)
        {
            string base64 = "";
            if (file != null)
            {
                var fileStream = file.OpenReadStream();
                byte[] bytes = new byte[file.Length];
                fileStream.Read(bytes, 0, (int)file.Length);
                base64 = Convert.ToBase64String(bytes);
            }
            return base64;
        }
    }
}

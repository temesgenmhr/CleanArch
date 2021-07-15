using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Api.Utility
{
    public class FileResultContentTypeAttribute : Attribute
    {
        public string ContentType { get; set; }
        public FileResultContentTypeAttribute(string contentType)
        {
            ContentType = contentType;
        }
    }
}

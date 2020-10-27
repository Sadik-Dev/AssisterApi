using System;
namespace AssisterApi.Models
{

    public class File : Media
    {
        public File()
        {

        }
        public File(String name, byte[] file) : base(name, file)
        {

        }
    }


}

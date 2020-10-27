using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace AssisterApi.Models
{
	public abstract class Media
	{
		public int Id { get; set; }
		public String Name { get; set; }

		public  IList<Media> Files { get; set; }
		public byte[] File { get; set; }

		public Media()
        {

        }
		public Media(String user)
		{
			Name = user;
		}
		public Media(String user, byte[] file) 
		{
			Name = user;
			File = file;
		}
	}
}
using System;
using System.Collections.Generic;

namespace JSON_Simple
{
	public class Article
	{
		public uint ID { get; set; }
		public string Title { get; set; }
		public string Authors { get; set; }
		public DateTime DateofPublication { get; set; }
		public bool IsOpenSource { get; set; }
	}
}
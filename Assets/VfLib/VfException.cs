using System;

namespace VfLib
{
	public class VfException : Exception
	{
		public VfException(string str) : base(str) {}
		public static void Error(string str) { throw new VfException(str); }
	}
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using A1;

namespace A1UnitTests
{
	[TestClass]
	public class SubsequenceFinderTester
	{
		[TestMethod]
		public void InvalidSubsequence()
		{
			bool IsValid = SubsequenceFinder.IsValidSubsequeuce(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 },
				                                                new List<int>() { 10, 2, 4, 9 });
			Assert.IsFalse(IsValid);
		}
		[TestMethod]
		public void ValidSubsequence()
		{
			bool IsValid = SubsequenceFinder.IsValidSubsequeuce(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 },
				                                                new List<int>() { 1, 2, 3 });
			Assert.IsTrue(IsValid);
		}
	}
}

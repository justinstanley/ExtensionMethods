using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JustinStanley.Extensions;
using System.Collections.Generic;

namespace JustinStanley.Extensions.Tests
{


    [TestClass]
    public class IEnumerableExtensionTests
    {
        private List<string> _list = new List<string>();
        public IEnumerableExtensionTests()
        {
            _list.Add("Foo");
            _list.Add("Bar");
            _list.Add("Justin");
            _list.Add("Stanley");
            _list.Add("Justin Stanley");
        }


        [TestMethod]
        public void StartsWithAny_Match()
        {
            Assert.IsTrue("Foo Bar Testing this our".StartsWithAny(_list));
        }
        [TestMethod]
        public void StartsWithAny_NoMatch()
        {
            Assert.IsFalse("Woot -  Testing this our".StartsWithAny(_list));
        }
    }
}

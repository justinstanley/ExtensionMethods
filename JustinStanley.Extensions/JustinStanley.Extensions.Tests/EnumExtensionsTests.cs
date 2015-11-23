using System;
using JustinStanley.Extensions;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JustinStanley.Extensions.Tests
{

    public enum TestEnum
    {
        UNKNOWN = 0,
        Foo = 1,
        Bar = 2,
        [System.ComponentModel.Description("Justin Stanley")]
        JustinStanley = 3

    }
    [TestClass]
    public class EnumExtensionsTests
    {
        [TestMethod]
        public void GetEnumDescription_ValidDescription()
        {
            TestEnum test = TestEnum.JustinStanley;
            Assert.AreEqual(test.GetEnumDescription(), "Justin Stanley");
        }

        [TestMethod]
        public void GetEnumDescription_InvalidDescription()
        {
            TestEnum test = TestEnum.JustinStanley;
            Assert.AreNotEqual(test.GetEnumDescription(), "FooBar");
        }

        [TestMethod]
        public void GetEnumDescription_MissingValue()
        {
            TestEnum test = TestEnum.Foo;
            Assert.AreEqual(test.GetEnumDescription(), "Foo");
        }

        [TestMethod]
        public void EnumToListOfString_Extension()
        {
            TestEnum test = TestEnum.Foo;
            List<string> values = test.EnumToListOfString();
            Assert.AreEqual(values.Count, 4);


        }

        [TestMethod]
        public void ParseEnum_Match()
        {

            string value = "foo";
            var result = EnumExtensions.ParseEnum<TestEnum>(value);

            Assert.AreEqual(result, TestEnum.Foo);

        }
        [TestMethod]
        public void ParseEnum_Default()
        {

            string value = "asdfasdf";
            var result = EnumExtensions.ParseEnum<TestEnum>(value);
            Assert.AreEqual(result, TestEnum.UNKNOWN);

        }
        [TestMethod]
        public void IsEnumValueValid_True()
        {
            Assert.IsTrue(EnumExtensions.IsEnumValueValid<TestEnum>("Foo"));
        }
        [TestMethod]
        public void IsEnumValueValid_False()
        {
            Assert.IsFalse(EnumExtensions.IsEnumValueValid<TestEnum>("aasdf"));
        }

        [TestMethod]
        public void EnumToDictionary_Extension_Pass()
        {

            TestEnum test = TestEnum.Foo;
            var result = test.EnumToDictionary();
            Assert.AreEqual(result.Count, 4);
        }
        [TestMethod]
        public void EnumToDictionary_Pass()
        {
            var result = EnumExtensions.EnumToDictionary<TestEnum>();
            Assert.AreEqual(result.Count, 4);
        }
    }
}

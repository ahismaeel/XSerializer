﻿using NUnit.Framework;
using System.Xml.Serialization;

namespace XSerializer.Tests
{
    public class AttributeTests
    {
        [Test]
        public void XmlAttributeDeserializesIntoProperty()
        {
            var xml = @"<AttributeContainer SomeValue=""abc""></AttributeContainer>";

            var serializer = new CustomSerializer<AttributeContainer>(null, TestXmlSerializerOptions.Empty);

            var container = (AttributeContainer)serializer.DeserializeObject(xml);

            Assert.That(container.SomeValue, Is.EqualTo("abc"));
        }

        public class AttributeContainer
        {
            [XmlAttribute]
            public string SomeValue { get; set; }
        }
    }
}

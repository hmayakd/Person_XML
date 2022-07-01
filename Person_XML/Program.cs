using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Person_XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument xml = XDocument.Load("XMLFile1.xml");

            int maxQual = int.Parse(xml.Element("persons")
                .Elements("person")
                .Elements("teacher")
                .Elements("qualifications")
                .Elements("qualification")
                .Select(x => x)
                .Max(y => y.Element("id").Value));
            var maxQualif = xml.Element("persons")
                .Elements("person")
                .Elements("teacher")
                .Elements("qualifications")
                .Elements("qualification")
                .Where(x => int.Parse(x.Element("id").Value) == maxQual)
                .Select(y => new Qualification  
                {
                    Name = y.Element("name").Value,
                    Id = int.Parse(y.Element("id").Value)
                });
        }
    }
}

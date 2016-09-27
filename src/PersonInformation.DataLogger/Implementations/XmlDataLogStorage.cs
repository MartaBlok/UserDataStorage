using PersonInformation.DataLogger.Interfaces;
using System;
using PersonInformation.DataLogger.Models;
using System.Xml;

namespace PersonInformation.DataLogger.Implementations
{
    public class XmlDataLogStorage : IUserDataLogStorage
    {
        public XmlDataLogStorage()
        {

        }

        public void Log(UserDataLogDTO dto)
        {
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true
            };

            using (XmlWriter writer = XmlWriter.Create(Console.Out, settings))
            {
                writer.WriteStartElement("User");
                writer.WriteAttributeString("Name", dto.Name);
                writer.WriteElementString("Surname", dto.Surname);
                writer.WriteEndElement();
            }
        }
    }
}

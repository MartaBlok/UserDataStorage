using PersonInformation.DataLogger.Interfaces;
using System;
using PersonInformation.DataLogger.Models;
using System.Xml;

namespace PersonInformation.DataLogger.Implementations
{
    public class XmlDataLogStorage : IUserDataLogStorage
    {
        private XmlDocument documentLog;
        public XmlDataLogStorage()
        {
            documentLog = new XmlDocument();
            documentLog.LoadXml("<item><name>User Storage Log</name></item>");
        }

        public void Log(UserDataLogDTO user)
        {
            XmlElement newUser = documentLog.CreateElement("User");
            newUser.InnerText = $"{user.Name} {user.Surname}";
            documentLog.DocumentElement?.AppendChild(newUser);

            XmlWriter writer = XmlWriter.Create(@"C:\Temp\logXmlWriter.xml", null);
            documentLog.Save(writer);
        }
    }
}

using System;
using System.Xml;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Transforms.XPathFilter
{
    public class XpathFilter : ITransform, ISavableModule
    {
        private readonly string _XpathString;
        public XpathFilter(string regexString)
        {
            _XpathString = regexString;
        }

        public string ModuleName { get; set; }
        public string ModuleTypeName { get { return nameof(XpathFilter); } }
        public string GetSaveString()
        {
            return _XpathString;
        }

        public EmitDataHandler DataHandler
        {
            get
            {
                return (sender, args) =>
                {
                    if (EmitData != null)
                    {
                        var data = args.Data;
                        var xml = new XmlDocument();
                        try
                        {
                            xml.LoadXml(args.Data);
                        }
                        catch (XmlException ex)
                        {
                            var errorMessage = "Xpath filter error: " + ex.Message;
                            FarsightLogger.DefaultLogger.LogError(errorMessage);
                            EmitData(this, new EmitDataHandlerArgs(errorMessage));
                            return;
                        }

                        var nodes = xml.SelectNodes(_XpathString);
                        var stringToEmit = "";
                        foreach (XmlNode node in nodes)
                        {
                            stringToEmit += node.OuterXml + Environment.NewLine;
                        }

                        EmitData(this, new EmitDataHandlerArgs(stringToEmit));
                    }
                };
            }
        }

        public event EmitDataHandler EmitData;

        public void Initialize()
        {
            return;
        }
    }
}

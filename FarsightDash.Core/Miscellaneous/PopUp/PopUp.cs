using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Miscellaneous.PopUp
{
    public class PopUp : IDataConsumer, ISavableModule
    {
        private readonly string _TitleString;
        private readonly string _BodyString;
        private readonly bool _IncludeInput;
        private DateTime _ConsumptionTime;

        public PopUp(string titleString, string bodyString, bool includeInput)
        {
            _TitleString = titleString;
            _BodyString = bodyString;
            _IncludeInput = includeInput;
        }

        public string ModuleName { get; set; }
        public string ModuleTypeName { get { return nameof(PopUp); } }
        public string GetSaveString()
        {
            return _TitleString;
        }

        public EmitDataHandler DataHandler
        {
            get
            {
                _ConsumptionTime = DateTime.Now;
                return (sender, args) =>
                {
                    var ticksInAMillisecond = 10000;
                    var timeSinceMostRecentConsumption = DateTime.Now.Ticks - _ConsumptionTime.Ticks;
                    if (timeSinceMostRecentConsumption > ticksInAMillisecond * 10)
                    {
                        // Since data may be emitted to us during the consumed Module's
                        // Initialize method, we wait 10ms before doing any popups.
                        var bodyText = _BodyString;
                        if (_IncludeInput)
                        {
                            bodyText += Environment.NewLine + args.Data;
                        }
                        MessageBox.Show(bodyText, _TitleString);
                    }
                };
            }
        }

        public void Initialize()
        {
            return;
        }
    }
}

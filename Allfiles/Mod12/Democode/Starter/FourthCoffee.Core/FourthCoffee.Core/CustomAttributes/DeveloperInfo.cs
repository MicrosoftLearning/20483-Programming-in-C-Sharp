using System;

namespace FourthCoffee.Core.CustomAttributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class DeveloperInfo : Attribute
    {
        private string _emailAddress;
        private int _revision;

        public DeveloperInfo(string emailAddress, int revision)
        {
            this._emailAddress = emailAddress;
            this._revision = revision;
        }

        public string EmailAddress
        {
            get { return this._emailAddress; }
        }

        public int Revision
        {
            get { return this._revision; }
        }
    }
}

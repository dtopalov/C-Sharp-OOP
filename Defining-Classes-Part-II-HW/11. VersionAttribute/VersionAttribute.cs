using System;

namespace _11.VersionAttribute
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class |
    AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method,
    AllowMultiple = false)]

    public class VersionAttribute : Attribute
    {
        private string version;

        public string Version 
        {
            get { return this.version; }
            private set { this.version = value; }
        }

        public VersionAttribute(string version)
        {
            this.Version = version;
        }
    }
}

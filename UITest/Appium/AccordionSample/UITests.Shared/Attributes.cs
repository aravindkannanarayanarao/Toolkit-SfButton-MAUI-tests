using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordionScripts1
{ 
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class WrittenBy : Attribute
    {
        public string Name { get; set; }
        public WrittenBy(string name)
        {
            Name = name;
        }
    }
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class ValidatedBy : Attribute
    {
        public string Name { get; set; }

        public Platform Platform { get; set; }

        public ValidatedBy(string name, Platform platform)
        {
            Name = name;
            Platform = platform;
        }
    }
    public enum Platform
    {
        Both = 0,
        iOS = 2,
        Android = 4,
    }

    /// <summary>
    /// Specifies the target device UDID for a test class or individual test method.
    /// When applied at method level, it overrides the class-level attribute.
    /// Example: [TargetDevice("emulator-5554")]
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TargetDevice : Attribute
    {
        public string Udid { get; set; }
        public TargetDevice(string udid)
        {
            Udid = udid;
        }
    }
}

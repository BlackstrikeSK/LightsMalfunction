using Exiled.API.Interfaces;
using System.ComponentModel;

namespace FlickeringLights
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        //Num Values
        [Description("How Long Will The Lights Be Turned Off For.")]
        public float LightsOffDuration { get; set; } = 60f;

        [Description("Delay Time.")]
        public float Delay { get; set; } = 45f;

        [Description("Minimum Number Of Rooms That Will be Affected.")]
        public int MinRooms { get; set; } = 10;

        [Description("Maximum Number Of Rooms That Will be Affected.")]
        public int MaxRooms { get; set; } = 20;
    }
}
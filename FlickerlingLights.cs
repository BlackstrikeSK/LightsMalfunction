using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using Server = Exiled.Events.Handlers.Server;

namespace FlickeringLights
{
    public class FlickerlingLights : Plugin<Config>
    {
        private static readonly FlickerlingLights Singleton = new FlickerlingLights();

        public override PluginPriority Priority { get; } = PluginPriority.Medium;
        public override string Name { get; } = "Flickering Lights";
        public override string Author { get; } = "BlackstrikeSK";
        public override Version Version { get; } = new Version(1, 0, 2);
        public override Version RequiredExiledVersion => new Version(2, 14, 0);

        private Handlers.Player player;
        private Handlers.Server server;

        private FlickerlingLights()
        {
        }

        public static FlickerlingLights Instance => Singleton;

        

        public override void OnEnabled()
        {
            if (!Config.IsEnabled) return;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            if (Config.IsEnabled)
            {
                return;
            }
            UnregisterEvents();
            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            player = new Handlers.Player();
            server = new Handlers.Server();

            Server.RoundStarted += server.FlickerLights;
        }

        public void UnregisterEvents()
        {
            Server.RoundStarted -= server.FlickerLights;

            player = null;
            server = null;
        }
    }
}
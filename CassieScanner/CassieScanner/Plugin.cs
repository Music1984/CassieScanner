namespace CassieScanner
{
    using System;
    using Exiled.API.Features;
    using PlayerHandlers = Exiled.Events.EventArgs;
    using Handlers = Exiled.Events.Handlers;
    /// <inheritdoc />
    public class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;

        /// <inheritdoc/>
        public override string Author { get; } = "Music";

        /// <inheritdoc/>
        public override string Name { get; } = "CassieScanner";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        /// <inheritdoc/>
        public override string Prefix { get; } = "CassieScanner";

        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1, 0, 0);

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            eventHandlers = new EventHandlers(this);
            Handlers.Server.RoundStarted += eventHandlers.OnRoundStarted;
            Handlers.Server.RespawningTeam += eventHandlers.OnRespawningTeam;
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            eventHandlers = null;
            Handlers.Server.RoundStarted -= eventHandlers.OnRoundStarted;
            Handlers.Server.RespawningTeam -= eventHandlers.OnRespawningTeam;
            base.OnDisabled();
        }
    }
}
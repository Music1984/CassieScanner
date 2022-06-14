using System;
using System.Collections.Generic;
using Exiled.API.Enums;
using MEC;
using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace CassieScanner
{
    using Exiled.API.Features;

    /// <summary>
    /// General event handlers.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;
        List<string> scpList = new List<string>();
        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">The <see cref="Plugin{TConfig}"/> class reference.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void OnRoundStarted()
        {
            foreach (Player player in Player.List)
            {
                if (player.Role.Side == Side.Scp)
                {
                    if (player.Role.Type == RoleType.Scp049)
                    {
                        if (scpList.Contains("SCP 0 4 9"))
                        {
                            break;
                        }

                        scpList.Add("SCP 0 4 9");
                    }

                    if (player.Role.Type == RoleType.Scp079)
                    {
                        if (scpList.Contains("SCP 0 7 9"))
                        {
                            break;
                        }

                        scpList.Add("SCP 0 7 9");
                    }

                    if (player.Role.Type == RoleType.Scp096)
                    {
                        if (scpList.Contains("SCP 0 9 6"))
                        {
                            break;
                        }

                        scpList.Add("SCP 0 9 6");
                    }

                    if (player.Role.Type == RoleType.Scp173)
                    {
                        if (scpList.Contains("SCP 1 7 3"))
                        {
                            break;
                        }

                        scpList.Add("SCP 1 7 3");
                    }

                    if (player.Role.Type == RoleType.Scp93953)
                    {
                        if (scpList.Contains("SCP 9 3 9 5 3"))
                        {
                            break;
                        }

                        scpList.Add("SCP 9 3 9 5 3");
                    }

                    if (player.Role.Type == RoleType.Scp93989)
                    {
                        if (scpList.Contains("SCP 9 3 9 8 9"))
                        {
                            break;
                        }

                        scpList.Add("SCP 9 3 9 8 9");
                    }
                    Timing.CallDelayed(plugin.Config.StartRoundAnnouceDelay, () =>
                    {
                        if (!plugin.Config.IsGlitchy)
                            Cassie.Message($"Alert. {scpList.Count} SCPs detected. {scpList} are breached. ");
                        else
                            Cassie.GlitchyMessage($"Alert. {scpList.Count} SCPs detected. {scpList} are breached. ", plugin.Config.GlitchChance, plugin.Config.JamChance);
                    });
                }
            }
        }

        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if (ev.NextKnownTeam == Respawning.SpawnableTeamType.ChaosInsurgency)
            {
                if (!plugin.Config.IsGlitchy)
                {
                    Cassie.Message("Alert. ChaosInsurgency Detected on surface.");
                }
                else
                {
                    Cassie.GlitchyMessage("Alert. ChaosInsurgency Detected on surface.", plugin.Config.GlitchChance, plugin.Config.JamChance);
                }
            }
        }
    }
}
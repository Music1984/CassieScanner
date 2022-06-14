namespace CassieScanner
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether debug messages should be shown in the console.
        /// </summary>
        [Description("Whether debug logs should be shown in the console.")]
        public bool Debug { get; set; }

        [Description("The delay for the start of round annoucement.")]
        public float StartRoundAnnouceDelay { get; set; } = 25f;

        [Description("Should annoucements be glitchy.")]
        public bool IsGlitchy { get; set; } = false;
        [Description("Glitch chance for annoucements. Disabled if IsGlitchy is false.")]
        public float GlitchChance { get; set; } = 25f;

        [Description("Jam chance for annoucements. Disabled if IsGlitchy is false.")]
        public float JamChance { get; set; } = 25f;
    }
}
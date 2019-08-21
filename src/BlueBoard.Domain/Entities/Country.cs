namespace BlueBoard.Domain
{
    /// <summary>
    /// Country entity
    /// </summary>
    public class Country : BaseEntity
    {
        /// <summary>
        /// Gets or sets name of country
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets ISO of country
        /// </summary>
        public string Iso { get; set; }
    }
}

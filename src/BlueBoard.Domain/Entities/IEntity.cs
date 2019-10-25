namespace BlueBoard.Domain
{
    /// <summary>
    /// Base interface for entities
    /// </summary>
    public interface IEntity { }

    /// <summary>
    /// Base generic interface for entities with id
    /// </summary>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// Gets or sets entity id
        /// </summary>
        TKey Id { get; set; }
    }
}

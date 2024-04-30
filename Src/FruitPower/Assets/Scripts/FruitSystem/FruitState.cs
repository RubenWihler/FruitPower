namespace FruitSystem
{
    /// <summary>
    /// enumeration des etats possibles d'un fruit.
    /// </summary>
    public enum FruitState
    {
        /// <summary>
        /// Le fruit est desactive
        /// </summary>
        Inactive,
        /// <summary>
        /// Le fruit est attache à un FruitSpawner et peut être ramasse par le joueur.
        /// </summary>
        Attached,
        /// <summary>
        /// Le fruit est actif et peut être ramasse par le joueur. (la gravite est activee)
        /// </summary>
        Neutral,
        /// <summary>
        /// Le fruit est dans la main du joueur.
        /// </summary>
        Grabbed,
    }
}

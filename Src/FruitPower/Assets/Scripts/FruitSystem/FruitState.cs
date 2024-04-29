namespace FruitSystem
{
    /// <summary>
    /// Énumération des états possibles d'un fruit.
    /// </summary>
    public enum FruitState
    {
        /// <summary>
        /// Le fruit est desactivé
        /// </summary>
        Inactive,
        /// <summary>
        /// Le fruit est attaché à un FruitSpawner et peut être ramassé par le joueur.
        /// </summary>
        Attached,
        /// <summary>
        /// Le fruit est actif et peut être ramassé par le joueur. (la gravité est activée)
        /// </summary>
        Neutral,
        /// <summary>
        /// Le fruit est dans la main du joueur.
        /// </summary>
        Grabbed,
    }
}

using System.Collections.Generic;

namespace GameManagement
{
    /// <summary>
    /// Classe responsable de la gestion des statistiques du jeu. 
    /// Pour l'instant, elle ne contient que les fruits attrapes.
    /// </summary>
    public sealed class GameStats
    {
        /// <summary>
        /// dictionnaire contenant les fruits attrapes et leur quantite.
        /// TKey: l'identifiant du type de fruit.
        /// TValue: la quantite de fruit attrape.
        /// </summary>
        private readonly Dictionary<string, uint> _fruitsCaught;

        /// <summary>
        /// Dictionnaire contenant les fruits attrapes et leur quantite.
        /// </summary>
        public Dictionary<string, uint> FruitsCaught => _fruitsCaught;

        /// <summary>
        /// Constructeur de la classe GameStats.
        /// </summary>
        public GameStats()
        {
            _fruitsCaught = new Dictionary<string, uint>();
        }
        
        /// <summary>
        /// Ajoute un fruit attrape
        /// </summary>
        /// <param name="fruitTypeId"></param>
        public void AddFruit(string fruitTypeId)
        {
            if (_fruitsCaught.ContainsKey(fruitTypeId))
            {
                _fruitsCaught[fruitTypeId]++;
            }
            else
            {
                _fruitsCaught.Add(fruitTypeId, 1);
            }
        }
    }
}
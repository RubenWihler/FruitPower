using System.Collections.Generic;

namespace GameManagement
{
    public sealed class GameStats
    {
        /// <summary>
        /// dictionnaire contenant les fruits attrapés et leur quantité.
        /// TKey: l'identifiant du type de fruit.
        /// TValue: la quantité de fruit attrapé.
        /// </summary>
        private Dictionary<string, uint> _fruitsCatched;

        /// <summary>
        /// Constructeur de la classe GameStats.
        /// </summary>
        public GameStats()
        {
            _fruitsCatched = new Dictionary<string, uint>();
        }

        /// <summary>
        /// Dictionnaire contenant les fruits attrapés et leur quantité.
        /// </summary>
        public Dictionary<string, uint> FruitsCatched => _fruitsCatched;

        /// <summary>
        /// Ajoute un fruit attrapé
        /// </summary>
        /// <param name="fruitTypeId"></param>
        public void AddFruit(string fruitTypeId)
        {
            if (_fruitsCatched.ContainsKey(fruitTypeId))
            {
                _fruitsCatched[fruitTypeId]++;
            }
            else
            {
                _fruitsCatched.Add(fruitTypeId, 1);
            }
        }
    }
}
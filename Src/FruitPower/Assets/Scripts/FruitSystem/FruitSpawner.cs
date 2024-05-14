/*
 TPI - 2024
 FruitPower - Fruit System
 Wihler Ruben
 */

using UnityEngine;

namespace FruitSystem
{
    public sealed class FruitSpawner : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Tooltip("The type of fruit to spawn.")]
        private string _fruitType;

        [Header("References")]
        [SerializeField, Tooltip("The spawner's spawn point.")]
        private Transform _spawnPoint;

        private bool _full;
        private Fruit _attachedFruit;

        public string FruitType => _fruitType;
        public bool IsFull => _full;

        public void SpawnFruit(Fruit fruit)
        {
            if (_full)
            {
                //meme si cela ne devrait pas arriver, mettre un warning pour le signaler nous assure qu'on ne rate pas un comportement inattendu
                Debug.LogWarning($"[!] Une tentative de spawn a ete effectuee sur un spawner plein: {name}");
                return;
            }

            _attachedFruit = fruit.Spawn().Attach(_spawnPoint.position, _spawnPoint.rotation);
            _attachedFruit.OnExitAttached += OnFruitDetached;
            _full = true;
        }
        private void OnFruitDetached()
        {
            _attachedFruit.OnExitAttached -= OnFruitDetached;
            _attachedFruit = null;
            _full = false;
        }
    }
}
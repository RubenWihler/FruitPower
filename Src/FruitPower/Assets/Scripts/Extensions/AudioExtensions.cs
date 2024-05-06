/*
 TPI - 2024
 FruitPower - Extensions pour les sons
 Wihler Ruben
 */


using UnityEngine;

/// <summary>
/// Classe d'extensions pour les sons
/// </summary>
public static class AudioExtensions
{
    /// <summary>
    /// Methode d'extension pour jouer un son aleatoire parmi un tableu de clips
    /// </summary>
    /// <param name="clips">tableau contenant les clips</param>
    /// <param name="source">la source audio sur laquelle jouer le son</param>
    public static void PlayRandom(this AudioClip[] clips, AudioSource source)
    {
        source.clip = clips[Random.Range(0, clips.Length)];
        source.Play();
    }
}

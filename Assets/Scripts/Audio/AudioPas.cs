/*
 * Code par Fernando Alexis Franco Murillo
 *Animation Event pour les sons des pas du personnages
 * Automne 2021
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioPas : MonoBehaviour
{
    [Tooltip("AudioClip pour le pas gauche")]
    [SerializeField] AudioClip pasGauche;

    [Tooltip("AudioClip pour le pas droite")]
    [SerializeField] AudioClip pasDroite;

    [Tooltip("AudioClip pour les cris")]
    [SerializeField] AudioClip crisAvant;

    private AudioSource audioSource;

    private void Update()
    {
        //Juste pour avoir acces au component enabled à l'inspecteur.
    }
    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Méthode qui déclenche le son du pas gauche
    /// </summary>
  public void SonPasGauchePersonnage()
    {
        audioSource.PlayOneShot(pasGauche, 1f);
    }

    /// <summary>
    /// Méthode qui déclenche le son du pas droite.
    /// </summary>
    public void SonPasDroitePersonnage()
    {
        audioSource.PlayOneShot(pasDroite, 1f);
    }
}

/*
 *Le code pour le déclenchement des sons des animaux est maintenant 
 *dans le script du mouvement.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrisAnimaux : MonoBehaviour
{
    #region Script Non Fonctionnel

    //[Header("Paramètres Sonore")]
    //[Tooltip("Est-ce que le son joue présentement")]
    //[SerializeField] bool _çaJoue;

    //[Tooltip("Délai avant que çaJoue est éagale à faux")]
    //[SerializeField] float _delaiBool = 3.0f;

    //[Tooltip("Délai avant le déclenchement du son")]
    //[SerializeField] float _delai = 9.0f;

    //[Header("Références Seulement")]
    //[Tooltip("Temps depuis le début du programme")]
    //[SerializeField] float _time;


    //private AudioSource audioSource;
    //private float _delaiInitial;
    //private float _delaiBoolInitial;

    //private void Awake()
    //{
    //    audioSource = GetComponent<AudioSource>();
    //}
    //private void Start()
    //{
    //    _delaiInitial = _delai;
    //    _delaiBoolInitial = _delaiBool;

    //    audioSource.Play();
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    _time = Mathf.Round(Time.time);

    //    if(_time >= _delai && !_çaJoue)
    //    {

    //        audioSource.Play();
    //        _delai += Time.time;
    //        _delaiBool += Time.time;
    //        _çaJoue = audioSource.isPlaying;

    //    }

    //    if(Time.time >= _delai)
    //    {
    //        _çaJoue = true;
    //        _delaiBool = _delaiBoolInitial;
    //        _delai = _delaiInitial;
    //    }
    //}

    #endregion
}

/*Code par Fernando Alexis Franco Murillo
 * Automne 2021
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ArretFilm : MonoBehaviour
{
    #region Fin du Film
    private const float DELAI = 74.0f;

    // Update is called once per frame
    void Update()
    {
        //Condition pour l'arrêt de l'animation.
        if(Time.time >= DELAI)
        {
            Arret(); //Methode qui arrête l'animation
        }
        
    }

    /// <summary>
    /// Methode qui déclenche l'arrêt du film en mode Editor et en mode Play.
    /// </summary>
    private void Arret()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif


    }

    #endregion
}

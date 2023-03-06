/*Code par Fernando Alexis Franco Murillo
 *
 * Automne 2021
 */

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ArretFilm : MonoBehaviour
{
    #region Fin du Film
    private const float DELAI = 74.0f;

    private void OnEnable()
    {
        GameEvents.EndOfFilm += Arret;
    }

    private void OnDisable()
    {
        GameEvents.EndOfFilm -= Arret;
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

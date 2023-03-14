/*Code par Fernando Alexis Franco Murillo
 *
 * Automne 2021
 */

using CoreDesign;
using UnityEngine;

namespace GamePlay.Controle
{
    /// <summary>
    /// Cette classe execue la fin du court metrage
    /// </summary>
    public class ArretFilm : MonoBehaviour
    {
        #region Fin du Film

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
}

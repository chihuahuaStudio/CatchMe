using CoreDesign;
using UnityEngine;

namespace GamePlay.Personnages
{
    public class DetruirePersonnage : MonoBehaviour
    {
        private void OnEnable()
        {
            GameEvents.NombreMaximumDeplacementAtteint += Detruire;
        }



        private void OnDisable()
        {
            GameEvents.NombreMaximumDeplacementAtteint -= Detruire;
        }
    
        private void Detruire()
        {
            // Destroy(gameObject);
            Debug.Log("ByBye "+name);
        }
    }
}

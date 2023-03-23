using UnityEngine;

namespace GamePlay.Personnages
{
    public class DetruirePersonnage : MonoBehaviour
    {
        private void Detruire()
        {
            Destroy(gameObject);
            Debug.Log("ByBye "+name);
        }
    }
}


using CoreDesign;
using UnityEngine;

namespace CatchMeIfYouCan.Audio
{
    /// <summary>
    /// Cette classe detecte la collision entre les personnages et le trigger du son
    /// </summary>
    public class CrisPersonnage : MonoBehaviour
    {
        [SerializeField] private AudioClip audioClip;
        private AudioSource monAs;
        
    
        public void Awake()
        {
            monAs = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            GameEvents.PersonnageTraverseCollider += DeclencheCrisPersonnage;
        }

        private void OnDisable()
        {
            GameEvents.PersonnageTraverseCollider -= DeclencheCrisPersonnage;
        }

        private void DeclencheCrisPersonnage()
        {
            monAs.PlayOneShot(audioClip, 1.0f);
        }

    }
}

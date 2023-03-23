
using CoreDesign;
using UnityEngine;
using UnityEngine.UI;

namespace CatchMeIfYouCan.UI
{
    
    /// <summary>
    /// Cette classe gère le comportement du speech box
    /// </summary>
    public class SpeechBox : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;

        private RectTransform speechTranform;
        private Image speechImage;
        

        private void Awake()
        {
            speechTranform = GetComponent<RectTransform>();
            speechImage = GetComponent<Image>();
        }

        private void OnEnable()
        {
            GameEvents.PersonnageTraverseColliderSon += ActivateSpeechBubble;
        }

        private void OnDisable()
        {
            GameEvents.PersonnageTraverseColliderSon -= ActivateSpeechBubble;
        }


        // Update is called once per frame
        void Update()
        {
            speechTranform.position = playerTransform.position;
        }

        private void ActivateSpeechBubble()
        {
            speechImage.color = new Color(speechImage.color.r, speechImage.color.g,
                speechImage.color.b,1.0f);
        }
    
    
    }
}

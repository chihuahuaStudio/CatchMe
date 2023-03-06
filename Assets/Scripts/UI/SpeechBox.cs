
using System;
using UnityEngine;
using UnityEngine.UI;

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
        GameEvents.PersonnageTraverseCollider += ActivateSpeechBubble;
    }

    private void OnDisable()
    {
        GameEvents.PersonnageTraverseCollider -= ActivateSpeechBubble;
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

using System;
using CoreDesign;
using UnityEngine;

namespace GamePlay.Personnages
{
    public class LimiteDeplacement : MonoBehaviour
    {

        [Header("Parametres du Deplacement")] 
        [SerializeField] private float limiteDeplacementX;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }


        // Update is called once per frame
        void Update()
        {
            if (_transform.position.x >= limiteDeplacementX)
            {
                GameEvents.RaisePersonageArriveLimiteDeplacement();
            }
        
        }
    }
}

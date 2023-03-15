
using CoreDesign;
using UnityEngine;

namespace GamePlay.Personnages
{
    public class CalculeDeplacement : MonoBehaviour
    {

        [Header("Parametres du Deplacement")] 
        [SerializeField] private float limiteDeplacementX;
        
        [SerializeField] private int nombreMaxDeplacement;
        public int NombreMaxDeplacement => nombreMaxDeplacement;

        [SerializeField] private int _nombreDeplacementEffectue;
        public int NombreDeplacementEffectue => _nombreDeplacementEffectue;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void OnEnable()
        {
            GameEvents.PersonnageArriveLimiteDeplacement += CalculeNombreDeplacement;
        }
        
        private void OnDisable()
        {
            GameEvents.PersonnageArriveLimiteDeplacement -= CalculeNombreDeplacement;
        }


    
        void Update()
        {
            if (_transform.position.x >= limiteDeplacementX)
            {
                GameEvents.RaisePersonageArriveLimiteDeplacement();
            }
        }

        private void CalculeNombreDeplacement()
        {
            _nombreDeplacementEffectue++;
        }
    }
}

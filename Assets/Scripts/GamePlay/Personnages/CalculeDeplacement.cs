
using UnityEngine;


namespace GamePlay.Personnages
{
    public class CalculeDeplacement : MonoBehaviour
    {

        [Header("Parametres du Deplacement")] 
        [SerializeField] private float limiteDeplacementX;
        [SerializeField] private int nombreMaxDeplacement;
        [SerializeField] private int nombreDeplacementEffectue;
        [SerializeField] private bool estEnArret;
        public bool EstEnArret
        {
            get => estEnArret;
            set => estEnArret = value;
        }


        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        void Update()
        {
            if (_transform.position.x >= limiteDeplacementX)
            {
                CalculeNombreDeplacement();
                estEnArret = true;
            }
            if (nombreDeplacementEffectue >= nombreMaxDeplacement)
                DesactivePersonnage();
        }

        private void CalculeNombreDeplacement()
        {
            nombreDeplacementEffectue++;
        }

        private void DesactivePersonnage() => gameObject.SetActive(false);

    }
}

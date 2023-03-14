/*
 * Code par Fernando Alexis Franco Murillo
 * Automne 2021
 * Modifiée Fév 2023:
 * Implémentation du Command Pattern et ajouts de méthode custom
 */

using CoreDesign;
using UnityEngine;

namespace GamePlay.NPC
{
    /// <summary>
    /// Cette class est resonsable d'implémenter le mouvement des nuages
    /// </summary>
    public class MouvementNuage : MonoBehaviour
    {
        #region Déclarations de Variables
    
        //Variables privée
        private float _vitesse;
        private const float LIMITE_X_GAUCHE = -20.0f;
        private const float LIMITE_X_DROITE = 15.0f;
        private const float ZERO = 0;
        private const float VITESSE_MIN_ABS = 0.5f;
        private const float VITESSE = 1.0f;
        private Transform transformNuages;
        private Vector2 posNuages;
    
        //Variables Command Pattern
        private Deplacement _deplacmenetNuages;

        #endregion

        #region Methodes Mono

        private void Awake()
        {
            _deplacmenetNuages = new Deplacement();
            transformNuages = gameObject.transform;
        }

        void Start()
        {
            PositionAleatoire();
            VitesseAleatoire();
            InvokeRepeating("DeplacementNuages", 
                0.0f, 0.05f);
        }


        void Update()
        {
            // DeplacementNuages();   
        }

        #endregion

        #region Methode Custom
    
        /// <summary>
        /// Calcule le déplacement ping-pong des nuages
        /// </summary>
        private void DeplacementNuages()
        {
            // transformNuages.Translate(Vector2.right * _vitesse * Time.deltaTime);
        
            _deplacmenetNuages.Execute(transformNuages, Vector3.right, _vitesse);
        
            MovementPingPong();
        }

        /// <summary>
        /// Cette methode assure un mouvement en boucle
        /// </summary>
        private void MovementPingPong()
        {
            if(transformNuages.position.x < LIMITE_X_GAUCHE || transformNuages.position.x > LIMITE_X_DROITE)
            {
                _vitesse = -_vitesse;
            }
        }
        /// <summary>
        /// Cette methode calcule une position aleatoire
        /// </summary>
        private void PositionAleatoire()
        {
            posNuages = new Vector2(Random.Range(LIMITE_X_GAUCHE, LIMITE_X_DROITE),
                transformNuages.position.y);
            transformNuages.position = posNuages;
        }

        /// <summary>
        /// Cette methode calcule un vitesse aléatoire
        /// </summary>
        private void VitesseAleatoire()
        {
            //Calcule une vitesse aléatoire.
            _vitesse = Random.Range(-VITESSE, VITESSE);

            //Assure une vitesse !=0.
            if(_vitesse == ZERO)
            {
                _vitesse = VITESSE_MIN_ABS;
            }
        }

        #endregion
    }
}

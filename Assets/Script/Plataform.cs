using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
   private Animator animator;
   [Header("Plataformas Azul")]
   [SerializeField]private GameObject[] blue = new GameObject[0];
   [Header("Plataformaas Vermelhas")]
   [SerializeField] private GameObject[] red = new GameObject[0];

   [Header("água blue")]
   [SerializeField] private GameObject[] waterBlue = new GameObject[0];
   [Header("água vermelha")]
   [SerializeField] private GameObject[] waterRed = new GameObject[0];

   [Header("Arvore vermelha")]
   [SerializeField] private GameObject[] TreenRed = new GameObject[0];
   [Header("Arvore azul")]
   [SerializeField] private GameObject[] TreenBlue = new GameObject[0];

   [Header("Foqueira")]
   [SerializeField] private GameObject[] fire = new GameObject[0];
   
   [Header("Camera")]
   public Player cameraDoGame;

  
   private bool controle;


    [SerializeField] private GameObject PontoA;
    [SerializeField] private GameObject PontoB;
  

    void Start() {
                // Plataformas Azuis
                blue[0].SetActive(true);

                // plataformas Vermelhas
                red[0].SetActive(false);

                // water blue
                waterBlue[0].SetActive(true);

                // water red
                waterRed[0].SetActive(false);

                // Arvores azuis
                TreenBlue[0].SetActive(true);

                //Arvore Vermelha
                TreenRed[0].SetActive(false);
                // Fire red 
                fire[0].SetActive(false);
                // fire blue 
                fire[1].SetActive(true);

               


                
               
   }

    void Update()
    {
     plataform(); 
     
    }

    void plataform(){

       

   
       }
      
       


        
}
}

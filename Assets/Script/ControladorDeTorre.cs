using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeTorre : MonoBehaviour
{

  [SerializeField] private GameObject[] Torres = new GameObject[0];
  [SerializeField] private GameObject [] cores = new GameObject[0];
  [SerializeField] private Collider2D[] collider6 = new Collider2D[0];

    
     void Start() {

       cores[0].SetActive(true);
       cores[1].SetActive(false);
      

    }
    private void OnTriggerEnter2D(Collider2D collider) {

      if(collider.gameObject.CompareTag("Player")){

        print("Funcionou");

      }
      
    }

}

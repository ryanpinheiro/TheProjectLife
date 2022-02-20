using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controle : MonoBehaviour
{
    [SerializeField] private bool movimento = true;
    [SerializeField] private float spd;
    [SerializeField] private Transform PontoA;
    [SerializeField] private Transform PontoB;
    
    void Update()
    {
        if(transform.position.x < PontoA.position.x){
            movimento = true;
        }
        if(transform.position.x > PontoB.position.x){
            movimento = false;
        }

        if(movimento){

            transform.position  = new Vector2(transform.position.x + spd * Time.deltaTime, transform.position.y );
        }else{
            transform.position  = new Vector2(transform.position.x - spd * Time.deltaTime, transform.position.y );
        }
        
    }


    
}

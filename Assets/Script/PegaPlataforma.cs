using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegaPlataforma : MonoBehaviour
{
   public void desligar(GameObject desligar){

        desligar.SetActive(false);
    }

   public void ligar(GameObject ligar){
        ligar.SetActive(true);
    }

    public void time(float tempo, float contar){
        contar = tempo;
        contar -= Time.deltaTime;

    }

   public void Idetifique(bool identificardor, Transform transform, float raio, LayerMask layer){ // identifica se o personagem está no chão
          
          identificardor = Physics2D.OverlapCircle(transform.position, raio, layer);
        }
}

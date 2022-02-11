using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destrir : MonoBehaviour
{
   
   [SerializeField] private float TempoDeDestruicao;
    void Update()
    {
        Destroy(gameObject,TempoDeDestruicao);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   [SerializeField] private string nomeDoLevelDoGame;


public void play(){

  SceneManager.LoadScene(nomeDoLevelDoGame);

}


public void exit(){
    
}

}

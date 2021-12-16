using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigame : MonoBehaviour
{
    void startGame(){
        print("suuu");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(checkScore.minigame){
            startGame();
        }
    }
}

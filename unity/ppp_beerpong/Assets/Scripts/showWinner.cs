using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showWinner : MonoBehaviour
{
    public Text text1;
    public void checkWinner(){
        if(checkScore.winner == 1){
            text1.text = "player 1 won";
        }else{

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        checkWinner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

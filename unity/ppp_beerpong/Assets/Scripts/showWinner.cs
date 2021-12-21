using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showWinner : MonoBehaviour
{
    public Text text1;

    public Text text2;
    public void checkWinner(){
        if(checkScore.winner == 1){
            text2.text = "VICTORY";
            text1.text = "LOSER";
        }else{
            text1.text = "VICTORY";
            text2.text = "LOSER";
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minigame : MonoBehaviour
{
    private float timeRemaining = 10;
    private int timerRounded;
    private int minigameStage = 3;
    private bool checkButtons;
    public Text minigame1;
    public Text minigame2;
    void startGame(){
        checkScore.minigame = false;
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
            // startGame();
            if (timeRemaining > 0){
                minigame1.text = Convert.ToString(minigameStage);
                minigame2.text = Convert.ToString(minigameStage);
                int randomTime = UnityEngine.Random.Range(timerRounded-60, timerRounded+60);
                if(randomTime == timerRounded){
                    if(minigameStage == 0){
                        checkButtons = true;
                    }else{
                        minigameStage--;
                    }
                    
                }
            timeRemaining -= Time.deltaTime;
            timerRounded = Convert.ToInt32(timeRemaining);
            // print((float)Math.Round(Time.deltaTime, 1));
            // print(timeRemaining);
            }
            // print(timeRemaining);
        }
        if(checkButtons){
            minigame1.text = "press now!";
            minigame2.text = "press now!";
            if(Input.GetKeyDown(KeyCode.Return)){
                minigame1.text = "VICTORY";
                minigame2.text = "SHOT!";
                checkScore.minigame = false;
                checkButtons = false;
            }else if (Input.GetKeyDown("space")){
                minigame2.text = "VICTORY";
                minigame1.text = "SHOT!";
                checkScore.minigame = false;
                checkButtons = false;
            }
        }
    }
}

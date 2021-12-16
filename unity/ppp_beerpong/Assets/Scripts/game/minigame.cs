using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minigame : MonoBehaviour
{
    private float timeRemaining = 10;
    private int timerRounded;
    private int minigameStage = 0;
    private bool checkButtons;
    public Text stage;
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
                stage.text = Convert.ToString(minigameStage);
                // print(checkScore.minigame);
                // print(timerRounded);
                int randomTime = UnityEngine.Random.Range(timerRounded-50, timerRounded+50);
                // print(randomTime);
                if(randomTime == timerRounded){
                    if(minigameStage == 3){
                        checkButtons = true;
                        
                    }else{
                        minigameStage++;
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
            stage.text = "press now!";
            if(Input.GetKeyDown(KeyCode.Return)){
                stage.text = "player 1 wins";
                checkScore.minigame = false;
                checkButtons = false;
            }else if (Input.GetKeyDown("space")){
                stage.text = "player 2 wins";
                print("player2 wins minigame");
                checkScore.minigame = false;
                checkButtons = false;
            }
        }
    }
}

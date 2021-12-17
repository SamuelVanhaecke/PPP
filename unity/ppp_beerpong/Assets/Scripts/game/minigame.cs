using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minigame : MonoBehaviour
{
    private float gameTime = 10;
    private float preparationTime = 10;
    private float finishTime = 10;
    private int timerRounded;
    private int minigameStage = 3;
    private bool checkButtons;
    private bool finishminigame = false;
    public Text minigame1;
    public Text minigame2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(checkScore.minigame && !finishminigame){
            minigame1.text = Convert.ToString("Get Ready");
            minigame2.text = Convert.ToString("Get Ready");
            if(preparationTime <= 0){
                if (gameTime > 0){
                    print(minigameStage);
                    minigame1.text = Convert.ToString(minigameStage);
                    minigame2.text = Convert.ToString(minigameStage);
                    int randomTime = UnityEngine.Random.Range(timerRounded-60, timerRounded+60);
                    if(randomTime == timerRounded){
                        if(minigameStage == 1){
                            checkButtons = true;
                        }else{
                            minigameStage--;
                        }
                        
                    }
                gameTime -= Time.deltaTime;
                timerRounded = Convert.ToInt32(gameTime);
                }
            }
            preparationTime -= Time.deltaTime;
        }
        if(checkButtons){
            minigame1.text = "press now!";
            minigame2.text = "press now!";
            if(Input.GetKeyDown(KeyCode.Return)){
                minigame1.text = "VICTORY";
                minigame2.text = "SHOT!";
                finishminigame = true;
            }else if (Input.GetKeyDown("space")){
                minigame2.text = "VICTORY";
                minigame1.text = "SHOT!";
                finishminigame = true;
            }
        }
        if(finishminigame){
            checkButtons = false;
            if(finishTime <= 0){
                minigame1.text = "";
                minigame2.text = "";
                checkScore.minigame = false;
                print("continue beerpong");

                finishminigame = false;
                finishTime = 10;
                preparationTime = 10;
                gameTime = 10;
            }else{
                finishTime -= Time.deltaTime;
            }
        }
        // if (checkScore.minigame){
        //     startminigame = true;
        // }
    }
}

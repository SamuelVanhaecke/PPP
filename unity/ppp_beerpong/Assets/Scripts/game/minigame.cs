using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minigame : MonoBehaviour
{
    AudioSource gameAudio;
    public AudioClip[] minigameSounds;
    private float gameTime = 1;
    private float preparationTime = 10;
    private float finishTime = 5;
    // private bool countdown = true;
    private int minigameStage = 3;
    private bool gameStage3 = true;
    private bool checkButtons;
    private bool finishminigame = false;
    public Text minigame1;
    public Text minigame2;

    void Start()
    {
        gameAudio = GameObject.Find("Canvas").GetComponent<AudioSource>();
    }

    void Update()
    {
        if(checkScore.minigame && !finishminigame){
            minigame1.text = Convert.ToString("Get Ready");
            minigame2.text = Convert.ToString("Get Ready");
            if(preparationTime >= 0){
                print(preparationTime);
            }
            if(preparationTime <= 0){
                print("preparation done");
                if (gameTime <= 0){
                    if(gameStage3){
                        gameAudio.PlayOneShot(minigameSounds[minigameStage]);
                        gameStage3 = false;
                    }
                    minigame1.text = Convert.ToString(minigameStage);
                    minigame2.text = Convert.ToString(minigameStage);
                    int randomNum = UnityEngine.Random.Range(0, 100);
                    if(randomNum == 69){
                        if(minigameStage == 1){
                            // countdown = false;
                            checkButtons = true;
                        }
                        minigameStage--;
                        gameAudio.PlayOneShot(minigameSounds[minigameStage]);
                    }
                }
                gameTime -= Time.deltaTime;
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
            minigameStage = 3;
            // countdown = true;
            if(finishTime <= 0){
                minigame1.text = "";
                minigame2.text = "";
                checkScore.minigame = false;
                print("continue beerpong");

                finishminigame = false;
                finishTime = 5;
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

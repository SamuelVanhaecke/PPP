using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class checkScore : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("/dev/cu.usbmodemHIDPC1", 9600);
    public Animator animator;
    public Animator animator2;
    private string[] cups1 = {"cup1.1", "cup1.2", "cup1.3", "cup1.4", "cup1.5", "cup1.6", "cup1.7", "cup1.8", "cup1.9", "cup1.10"};
    private string[] cups2 = {"cup2.1", "cup2.2", "cup2.3", "cup2.4", "cup2.5", "cup2.6", "cup2.7", "cup2.8", "cup2.9", "cup2.10"};
    private int xValue;
    private int yValue;

    public Text turnIndicator1;
    public Text turnIndicator2;
    public static bool minigame = false;
    private int player1Score = 0;
    private int player2Score = 0;
    public static int winner;

    private int cupRadius = 23;

    AudioSource gameAudio;
    public AudioClip[] sounds;

    private int [] positionsX = {10, 20, 30, 40, 50, 60, 70, 80, 90, 100};
    public bool playerTurn = true;

    void checkIfScore() {
        // Get coördinates of pingpongball from udpReceive script
        xValue = GameObject.Find("Canvas").GetComponent<udpReceive>().xValue;
        yValue = -(GameObject.Find("Canvas").GetComponent<udpReceive>().yValue);


        
        if(xValue != 0 && yValue != 0 && !minigame) {
            if (playerTurn) {
                for(int i = 0; i < 9; i++) {
                    positionsX[i] = positionsX[i+1];
                }
                positionsX[9] = xValue;

                if(positionsX[9] - positionsX[0] < 20) {
                    for(int i = 0; i < cups1.Length; i++) {
                        if(cups1[i]!=""){
                            string currentCup = GameObject.Find(cups1[i]).transform.position.ToString();
                            
                            var cupCoördinates = currentCup.Split(',');
                            int cupX = Int32.Parse(Regex.Match(cupCoördinates[0], @"\d+").Value)-482;
                            int cupY = Int32.Parse(Regex.Match(cupCoördinates[1], @"\d+").Value)-275;
                            // print("cup:" + cupX + "," + cupY);

                            if(xValue < cupX+cupRadius && xValue > cupX-cupRadius && yValue < cupY+cupRadius && yValue > cupY-cupRadius) {
                                print(cups1[i]);
                                playerTurn = false;
                                print("score");
                                playScoreAnimation();

                                print(cups1[i]);
                                GameObject.Find(cups1[i]).GetComponent<SpriteRenderer>().color = new Color (255f, 255f, 255f, 0f);

                                // empty cup from array
                                cups1[i] = "";

                                player1Score++;
                                print(player1Score);

                                playMinigame();

                                // send score to arduino
                                // data_stream.Write("s");
                                // data_stream.Write("o");
                                // print("sent to arduino");
                                
                            }
                        }
                    }
                    // playerTurn = false;
                    // print("noScore");
                }
            } else {
                for(int i = 0; i < 9; i++) {
                    positionsX[i] = positionsX[i+1];
                }
                positionsX[9] = xValue;

                if(positionsX[0] - positionsX[9] < 20) {
                    for(int i = 0; i < cups2.Length; i++) {
                        if(cups2[i]!=""){
                            string currentCup = GameObject.Find(cups2[i]).transform.position.ToString();
                            var cupCoördinates = currentCup.Split(',');
                            int cupX = Int32.Parse(Regex.Match(cupCoördinates[0], @"\d+").Value)-492;
                            int cupY = Int32.Parse(Regex.Match(cupCoördinates[1], @"\d+").Value)-275;
                            if(xValue < cupX+cupRadius && xValue > cupX-cupRadius && yValue < cupY+cupRadius && yValue > cupY-cupRadius) {
                                print(cups2[i]);
                                print("score");
                                GameObject.Find(cups2[i]).GetComponent<SpriteRenderer>().color = new Color (255f, 255f, 255f, 0f);
                                playerTurn = true;

                                playScoreAnimation();

                                cups2[i] = "";
                                player2Score++;

                                playMinigame();

                                // data_stream.Write("s");
                                // data_stream.Write("o");
                            }
                        }
                        
                    }
                    // print("noScore");
                    // playerTurn = true;
                }
            }
            xValue = 0;
            yValue = 0;
        }
        forceTurn();
        
    }

    public void playMinigame() {
        int random = UnityEngine.Random.Range(1, 20);
        print(random);
        if(random == 1){
            minigame = true;
        }
    }

    public void playScoreAnimation(){
        gameAudio.PlayOneShot(sounds[UnityEngine.Random.Range(0, sounds.Length)]);
        int animationNumber = UnityEngine.Random.Range(1, 4);
        print(animationNumber);
        animator.Play("score_"+animationNumber);
        animator2.Play("score_"+animationNumber);
    }

    public void forceTurn(){
        if(!minigame){
            if (Input.GetKeyDown(KeyCode.Return)){
                print("pressed enter");
                playerTurn = false;
                print(playerTurn);
            }
            if (Input.GetKeyDown("space")){
                print("pressed space");
                playerTurn = true;
                print(playerTurn);
            }
        }
    }

    // Connection to Arduino can be used for lighting effects
    public void OpenArduino(){
        if(data_stream != null){
            if(data_stream.IsOpen){
                data_stream.Close();
            }else {
                data_stream.Open();
                data_stream.ReadTimeout = 16;
                print("Arduino connected");
            }
        }else {
            if(data_stream.IsOpen){
                print("Arduino is already connected");
            }else{
                print("Port == null");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // OpenArduino();
        // data_stream.Write("o");

        gameAudio = GameObject.Find("Canvas").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player1Score < 10 && player2Score < 10){
            checkIfScore();
        }else if (player1Score == 10){
            winner = 1;
            SceneManager.LoadScene("Finished");
        }else if (player2Score == 10){
            winner = 2;
            SceneManager.LoadScene("Finished");
        }

        if(playerTurn){
            turnIndicator2.text = "Your Turn";
            turnIndicator1.text = "";
        }else{
            turnIndicator1.text = "Your Turn";
            turnIndicator2.text = "";
        }
    }
}

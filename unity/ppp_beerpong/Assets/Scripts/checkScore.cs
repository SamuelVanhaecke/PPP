using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using System.Timers;

public class checkScore : MonoBehaviour
{
    public string[] cups1 = {"cup1.1", "cup1.2", "cup1.3", "cup1.4", "cup1.5", "cup1.6", "cup1.7", "cup1.8", "cup1.9", "cup1.10"};
    public string[] cups2 = {"cup2.1", "cup2.2", "cup2.3", "cup2.4", "cup2.5", "cup2.6", "cup2.7", "cup2.8", "cup2.9", "cup2.10"};
    public int xValue;
    public int yValue;
    public bool playerTurn = true;
    

    void checkIfScore() {
        print("test1");
        xValue = GameObject.Find("Canvas").GetComponent<udpReceive>().xValue;
        yValue = GameObject.Find("Canvas").GetComponent<udpReceive>().yValue;
        // xValue = 283;
        // yValue = 29;
        print("test2");
        

        if(xValue != -640 && yValue != -360) {
            if (playerTurn) {
                print("test3");
                for(int i = 0; i < cups1.Length; i++) {
                    string currentCup = GameObject.Find(cups1[i]).transform.position.ToString();
                    var cupCoördinates = currentCup.Split(',');
                    int cupX = Int32.Parse(Regex.Match(cupCoördinates[0], @"\d+").Value)-482;
                    int cupY = Int32.Parse(Regex.Match(cupCoördinates[1], @"\d+").Value)-275;
                    //print(cupX +", "+cupY);
                    //print(xValue +", "+yValue);

                    if(xValue < cupX+23 && xValue > cupX-23 && yValue < cupY+23 && yValue > cupY-23) {
                        print("score");
                    }
                }
            } else {

            }
        }

        
    }
    // Start is called before the first frame update
    void Start()
    {
        System.Timers.Timer myTimer = new System.Timers.Timer();
        myTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
        myTimer.Interval = 1000; // 1000 ms is one second
        myTimer.Start();

        void DisplayTimeEvent(object source, ElapsedEventArgs e)
        {
            checkIfScore();
        }
        // Task.Factory.StartNew(() =>
        // {
        //     System.Threading.Thread.Sleep(1000);
        //     checkIfScore();
        // });
        // var cups = new List<Cup>();

        // for(int i = 0; i<10; i++) {
        //     cups.Add(new Cup{name = "side1."+i});
        // }

        // print(cups);
        // GameObject canvas = GameObject.Find("Canvas");
        // PlayerScript udpScript = canvas.GetComponent<udpReceive>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // checkIfScore();
        // xValue = GameObject.Find("Canvas").GetComponent<udpReceive>().xValue;
        // yValue = GameObject.Find("Canvas").GetComponent<udpReceive>().yValue;

        // Console.Write("["+xValue+","+yValue+"]");

        //print("["+xValue+","+yValue+"]");

        // if (xValue < 374+47 && xValue > 374-47 && yValue < 0+47 && yValue > 0-47) {
        //     print("Score");
        // }

        // if(xValue != 0 && yValue != 0) {
        //     checkIfScore();
        // }
        //checkIfScore();
        //checkIfScore(xValue, yValue)
    }
}

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

public class checkScore : MonoBehaviour
{
    // public class Cup{
    //     public string name {get; set;}
    //     public int x;
    //     public int y;
    //     public bool active = true;
    // }
    public int xValue;
    public int yValue;

    void checkIfScore() {

    }
    // Start is called before the first frame update
    void Start()
    {
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
        xValue = GameObject.Find("Canvas").GetComponent<udpReceive>().xValue;
        yValue = GameObject.Find("Canvas").GetComponent<udpReceive>().yValue;

        print("["+xValue+","+yValue+"]");

        if (xValue < 374+47 && xValue > 374-47 && yValue < 0+47 && yValue > 0-47) {
            print("Score");
        }

        //checkIfScore(xValue, yValue)
    }
}

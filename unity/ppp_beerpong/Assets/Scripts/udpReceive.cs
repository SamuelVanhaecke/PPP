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

public class udpReceive : MonoBehaviour
{
    // receiving Thread
    Thread receiveThread;
 
    // udpclient object
    UdpClient client;

    // public
    // public string IP = "127.0.0.1"; default local
    public int port; // define > init

    public Text scoring;
 
    // infos
    public string lastReceivedUDPPacket="";
    //public string allReceivedUDPPackets=""; // clean up this from time to time!
    
    public int xValue;
    public int yValue;

    // start from shell
    private static void Main()
    {
       udpReceive receiveObj=new udpReceive();
       receiveObj.init();
 
        string text="";
        do
        {
             text = Console.ReadLine();
        }
        while(!text.Equals("exit"));
    }

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // OnGUI
    void OnGUI()
    {
        Rect rectObj=new Rect(40,10,200,400);
            GUIStyle style = new GUIStyle();
                style.alignment = TextAnchor.UpperLeft;
        GUI.Box(rectObj,"# UDPReceive\n127.0.0.1 "+port+" #\n"
                    + "shell> nc -u 127.0.0.1 : "+port+" \n"
                    + "\nLast Packet: \n"+ lastReceivedUDPPacket
                    + "\n\nAll Messages:\n"//+allReceivedUDPPackets
                ,style);
    }

    // init
    private void init()
    {
        // Endpunkt definieren, von dem die Nachrichten gesendet werden.
        print("UDPSend.init()");
       
        // define port
        port = 11999;
 
        // status
        print("Sending to 127.0.0.1 : "+port);
        print("Test-Sending to this Port: nc -u 127.0.0.1  "+port+"");
 
   
        // ----------------------------
        // Abhören
        // ----------------------------
        // Lokalen Endpunkt definieren (wo Nachrichten empfangen werden).
        // Einen neuen Thread für den Empfang eingehender Nachrichten erstellen.
        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
 
    }

    // receive thread
    private  void ReceiveData()
    {
 
        client = new UdpClient(port);
        while (true)
        {
 
            try
            {
                // Bytes empfangen.
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);
 
                // Bytes mit der UTF8-Kodierung in das Textformat kodieren.
                string text = Encoding.UTF8.GetString(data);
 
                // Den abgerufenen Text anzeigen.
                //print(">> " + text);
               
                // latest UDPpacket
                lastReceivedUDPPacket=text;
               
                // ....
                //allReceivedUDPPackets=allReceivedUDPPackets+text;
               
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

    // getLatestUDPPacket
    // cleans up the rest
    public string getLatestUDPPacket()
    {
        //allReceivedUDPPackets="";
        return lastReceivedUDPPacket;
    }

    // Update is called once per frame
    void Update()
    {
        var result = lastReceivedUDPPacket.Split(',');

        Console.Write("result");

        xValue = Int32.Parse(Regex.Match(result[0], @"\d+").Value)-640;
        yValue = Int32.Parse(Regex.Match(result[1], @"\d+").Value)-360;

        // Console.Write(xValue.ToString());

        // if (yValue > 160 || yValue < -160) {
        //     xValue = 0;
        //     yValue = 0;
        // }

        //print(">> [" + xValue + "," + yValue + "]");



        // if(xValue < 320 && xValue > 300){
        //     scoring.text = "Score";
        // } else {
        //     scoring.text = "No score";
        // }
    }
}

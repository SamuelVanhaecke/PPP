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
    public static UdpClient client;

    // public
    // public string IP = "127.0.0.1"; default local
    public int port; // define > init

    // private bool clientExists;
 
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

    // init
    private void init()
    {
        // clientExists = false;
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
        // if(!clientExists){
            
        //     clientExists = true;
        // }

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

        if(result[0] != "") {
            xValue = Int32.Parse(Regex.Match(result[0], @"\d+").Value)-640;
            yValue = Int32.Parse(Regex.Match(result[1], @"\d+").Value)-360;
        };

        // if(checkScore.winner == 1 || checkScore.winner == 2){
        //     print("doing it");
        //     client.Close();
        // }
    }
}

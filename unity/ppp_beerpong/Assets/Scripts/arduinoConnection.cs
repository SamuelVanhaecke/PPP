using System.Collections;
using System.IO.Ports;
using System.Collections.Generic;
using UnityEngine;

public class arduinoConnection : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("/dev/cu.usbmodem1412201", 9600);
    public string receivedButtonPress;
    void Start()
    {
        data_stream.Open();
        data_stream.ReadTimeout = 1000;
    }
    void Update()
    {
        receivedButtonPress = data_stream.ReadLine();
        
        // if (Input.GetKeyDown("space")) {
        //     print("brunzyn");
            
        // }
    }
}

using System.Collections;
using System.Collections.Generic;
using System;

using System.Net;
using System.Net.Sockets;
using System.Text;

using UnityEngine;

public class StepperMotorBridge : MonoBehaviour
{
    private bool initialized = false;
    private string targetIp = "127.0.0.1";
    private UdpClient client;
    private IPEndPoint remoteEndPoint;

    public int udpPort;

    public void ResetSerial() {
        Debug.Log("ResetSerial, not implemented!");
    }

    public void InitUdp() {
        if(initialized) {
            return;
        }

        remoteEndPoint = new IPEndPoint(IPAddress.Parse(targetIp), udpPort);
        client = new UdpClient();

        initialized = true;
    }

    public void SendString(string message) {
        if (message.Length == 0) {
            return;
        }

        if (!initialized) {
            InitUdp();
        }

        
        try {
            byte[] data = Encoding.UTF8.GetBytes(message);

            client.Send(data, data.Length, remoteEndPoint);
        } catch(Exception err) {
            print(err.ToString());
        }
    }

}

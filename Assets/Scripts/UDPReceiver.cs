using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class UDPReceiver : MonoBehaviour
{
    private Thread receiveThread;
    private UdpClient client;
    private int port = 4243;
    public bool startReceiving = true;
    public bool printToConsole = false;
    public string data;

    public static bool hasData = false;
    
    void Start()
    {
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    private void ReceiveData()
    {
        client = new UdpClient(port);
        while (startReceiving)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataBytes = client.Receive(ref anyIP);
                data = Encoding.UTF8.GetString(dataBytes);

                if (printToConsole)
                {
                    print(data);
                }

                hasData = data != "-1";
            }
            catch (Exception e)
            {
                print(e.ToString());
            }
        }
    }
}

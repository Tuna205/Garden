using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject ball1;
    public GameObject ball2;

    private UDPReceiver receiver;
    private Vector2 scaleCameraToScreen;

    private Vector2 cameraResolution = new Vector2(1280, 720);
    
    // Start is called before the first frame update
    void Start()
    {
        ball1.SetActive(false);
        ball2.SetActive(false);
        
        receiver = this.GetComponent<UDPReceiver>();

        Vector2 unityScreenSpace = new Vector2(20, 12);

        scaleCameraToScreen = new Vector2(cameraResolution.x / unityScreenSpace.x, // 64
                                          cameraResolution.y / unityScreenSpace.y);// 60
    }

    // Update is called once per frame
    void Update()
    {
        if (!UDPReceiver.hasData) return;
        
        ball1.SetActive(true);
        ball2.SetActive(true);
        
        List<Vector2> ballPositions = ParseData(receiver.data);

        ball1.transform.position = ballPositions[0];
        ball2.transform.position = ballPositions[1];
    }

    private List<Vector2> ParseData(string receiverData)
    {
        //[778, 291, 412, 308]
        receiverData = receiverData.Remove(0, 1);
        receiverData = receiverData.Remove(receiverData.Length - 1, 1);
        List<Vector2> result = new List<Vector2>();
        string[] dataSplit = receiverData.Split(',');

        float x1 = (float.Parse(dataSplit[0]) - cameraResolution.x / 2) / scaleCameraToScreen.x;
        float y1 = (float.Parse(dataSplit[1]) - cameraResolution.y / 2) / scaleCameraToScreen.y;
        
        float x2 = (float.Parse(dataSplit[2]) - cameraResolution.x / 2) / scaleCameraToScreen.x;
        float y2 = (float.Parse(dataSplit[3]) - cameraResolution.y / 2) / scaleCameraToScreen.y;
        
        result.Add(new Vector2(x1, y1));
        result.Add(new Vector2(x2, y2));
        
        return result;
    }
}

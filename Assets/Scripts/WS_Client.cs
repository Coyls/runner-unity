using WebSocketSharp;
using UnityEngine;

public class WS_Client : MonoBehaviour
{
    WebSocket ws;
    void Start()
    {
        ws = new WebSocket("ws://192.168.1.97:3000");
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message received from " + e.Data);
        };
        ws.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        if (ws == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ws.Send("Hello");
        }

    }
}

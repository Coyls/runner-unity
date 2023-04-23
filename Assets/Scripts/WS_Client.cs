using WebSocketSharp;
using UnityEngine;
using System.Collections;


public class WS_Client : MonoBehaviour
{
    WebSocket ws;

    [SerializeField] Rigidbody rb;

    [SerializeField] float sidewaysForce = 300f;
    void Start()
    {
        ws = new WebSocket("ws://192.168.1.97:3000");

        ws.OnMessage += OnMessage;

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

    void OnMessage(object sender, MessageEventArgs e)
    {
        StartCoroutine(ApplyForce(e.Data));
    }

    IEnumerator ApplyForce(string direction)
    {
        yield return new WaitForFixedUpdate();

        if (direction == "RIGHT")
        {
            rb.AddForce(new Vector3(sidewaysForce * Time.deltaTime, 0, 0), ForceMode.VelocityChange);
        }
        if (direction == "LEFT")
        {
            rb.AddForce(new Vector3(-sidewaysForce * Time.deltaTime, 0, 0), ForceMode.VelocityChange);
        }
    }


}

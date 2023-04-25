using WebSocketSharp;
using UnityEngine;
using System.Collections;


public class WS_Client : MonoBehaviour
{
    WebSocket ws;

    [SerializeField] Rigidbody rb;

    [SerializeField] float sidewaysForce = 300f;

    string currentDirection = "MIDDLE";
    void Start()
    {
        // ws = new WebSocket("ws://192.168.1.97:3000");
        ws = new WebSocket("ws://localhost:3000");

        ws.OnMessage += OnMessage;

        ws.Connect();

        /* yield return StartCoroutine(ws.Connect());

        yield return 0; */
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

        Debug.Log("PLSSSSS");


        if (e.Data == "RIGHT")
        {
            currentDirection = "RIGHT";
        }
        if (e.Data == "LEFT")
        {
            currentDirection = "LEFT";
        }
        if (e.Data == "MIDDLE") {
            currentDirection = "MIDDLE";
        }
    }

    /* IEnumerator ApplyForce(string direction)
    {
        yield return new WaitForFixedUpdate();

        
    } */

    void FixedUpdate() {
        if (currentDirection == "MIDDLE") {

        }

        if (currentDirection == "RIGHT")
        {
            // Debug.Log("Right");
            rb.AddForce(new Vector3(sidewaysForce * Time.deltaTime, 0, 0), ForceMode.VelocityChange);
        }
        if (currentDirection == "LEFT")
        {
            // Debug.Log("Left");
            rb.AddForce(new Vector3(-sidewaysForce * Time.deltaTime, 0, 0), ForceMode.VelocityChange);
        }


    }

    private void OnDestroy()
    {
        if (ws != null && ws.IsAlive)
        {
            ws.Close();
        }
    }


}

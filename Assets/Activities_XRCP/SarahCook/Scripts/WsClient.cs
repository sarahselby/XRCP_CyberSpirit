using UnityEngine;
using WebSocketSharp;
public class WsClient : MonoBehaviour
{
    WebSocket ws;
    private void Start()
    {
        ws = new WebSocket("wss://dark-heathered-fuschia.glitch.me");
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data);

        };
    }
    private void Update()
    {
        if (ws == null)
        {
            return;
        }
           // ws.Send("hello");



    }

    public void SendRoomMessage(string messageValue)
    {
        ws.Send(messageValue);
    }
}
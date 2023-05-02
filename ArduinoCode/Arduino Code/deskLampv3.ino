/*
  Esp32 Websockets Client

  This sketch:
        1. Connects to a WiFi network
        2. Connects to a Websockets server
        3. Sends the websockets server a message ("Hello Server")
        4. Prints all incoming messages while the connection is open

  Hardware:
        For this sketch you only need an ESP32 board.

  Created 15/02/2019
  By Gil Maimon
  https://github.com/gilmaimon/ArduinoWebsockets

*/

#include <ArduinoWebsockets.h>
#include <WiFi.h>

// Define the pin numbers for the switch and the relay
const int switchPin = 4;
const int relayPin = 2;

int previousSwitchState = LOW;
int virtualSwitchState = LOW;


const char* ssid = "VM3224501booster"; //Enter SSID
const char* password = "vrkk6HpRsxyg"; //Enter Password

using namespace websockets;

WebsocketsClient client;
void setup() {
    Serial.begin(115200);

      // Set the switch pin to input mode and enable internal pull-up resistor
    pinMode(switchPin, INPUT_PULLUP);

  // Set the relay pin to output mode
  pinMode(relayPin, OUTPUT);

  // Turn off the relay initially
  digitalWrite(relayPin, LOW);

    
    // Connect to wifi
    WiFi.begin(ssid, password);

    // Wait some time to connect to wifi
    for(int i = 0; i < 10 && WiFi.status() != WL_CONNECTED; i++) {
        Serial.print(".");
        delay(1000);
    }

    // Check if connected to wifi
    if(WiFi.status() != WL_CONNECTED) {
        Serial.println("No Wifi!");
        return;
    }

    Serial.println("Connected to Wifi, Connecting to server.");
    // try to connect to Websockets server
   // client.addHeader("user-agent", "Mozilla");
    bool connected = client.connect("ws://192.168.0.147:8080");
    if(connected) {
        Serial.println("Connected!");
        client.send("Hello Server");
    } else {
        Serial.println("Not Connected!");
    }
    
    // run callback when messages are received
    client.onMessage([&](WebsocketsMessage message){
        Serial.print("Got Message: ");
        Serial.println(message.data());
        
        if (message.data() == "26") {
            activateLamp();
        }
        
    });
    
}

void loop() {
    // let the websockets client check for incoming messages
    if(client.available()) {
        client.poll();
    }
    delay(500);
      // Read the state of the switch
  int switchState = digitalRead(switchPin);

    if (switchState != previousSwitchState) {
    // Update the previous switch state variable
    previousSwitchState = switchState;

    // Do something here when the switch state changes
    digitalWrite(relayPin, switchState);
    Serial.println("change in switch state");
    // need to send to unity here
    client.send("lampstateswitch");
  }
}

void activateLamp() {
  Serial.println("light activated virtually");
  int newVirtualSwitchState = !virtualSwitchState;
  digitalWrite(relayPin, newVirtualSwitchState);
  virtualSwitchState = newVirtualSwitchState;
}

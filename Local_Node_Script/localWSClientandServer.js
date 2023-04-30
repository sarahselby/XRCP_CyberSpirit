const WebSocket = require('ws');

const serverAddress = 'ws://localhost:8080/';

// Create a WebSocket server
const wss = new WebSocket.Server({ port: 8080 });

// Handle new WebSocket connections
wss.on('connection', function connection(ws) {
  console.log('New WebSocket connection');

  // Handle incoming messages
  ws.on('message', function incoming(message) {
    console.log(`Received message from client: ${message}`);
  });

  // Send a message to the client
  ws.send('Hello, client!');
});

const serverAddress = 'wss://dark-heathered-fuschia.glitch.me/';

const ws = new WebSocket(serverAddress, {
	headers: {
		"user-agent": "Mozilla"
	}
}); // replace 'your-glitch-app' with your actual Glitch app name

ws.on('open', function open() {
  console.log('WebSocket client connected');
  
  ws.send('Hello, server!');
});

ws.on('message', function incoming(data) {
  console.log('Received message from server:', data.toString());
});

ws.on('close', function close() {
  console.log('WebSocket client disconnected');
});

ws.on('error', function error(error) {
  console.error('WebSocket error:', error);
});

const WebSocket = require('ws');

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

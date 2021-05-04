let socket = new WebSocket("ws://localhost:5000/ws")

socket.onopen = function (event) {
    console.log("Connected to chat!")
    socket.send("User connected to the room");
};

socket.onmessage = function (event) {
    console.log(event.data)
};
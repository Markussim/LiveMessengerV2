const urlParams = new URLSearchParams(window.location.search);
const id = urlParams.get('id');
const wsString = "ws://localhost:5001/" + id;
let socket = new WebSocket(wsString)

socket.onopen = function (event) {
    console.log("Connected to chat!")
    socket.send("User connected to the room");
};

socket.onmessage = function (event) {
    console.log(event.data)
};

function sendMessage(){
    let message = document.getElementById("message").value
    socket.send(message)
}
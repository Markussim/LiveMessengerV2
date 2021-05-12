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
    var message = `{
        "user" : ${getCookie("username")},
        "message" : ${document.getElementById("message").value},
        "Date" : "2021",
        }`;
    //let message = document.getElementById("message").value
    socket.send(message)
}


//FUNCTION STOLEN FROM https://stackoverflow.com/a/15724300
function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
  }
const urlParams = new URLSearchParams(window.location.search);
const id = urlParams.get('id');
const wsString = "ws://localhost:5001/" + id;
let socket = new WebSocket(wsString)

socket.onopen = function (event) {
    console.log("Connected to chat!")
};

socket.onmessage = function (event) {
    let messageContainer = document.getElementById("messages");
    let msgHtml = document.createElement("p");
    let message = JSON.parse(event.data);
    msgHtml.innerHTML = `<b>${escapeHtml(message.User)}: </b>${escapeHtml(message.Message)}`;
    let dateContainer = document.createElement("div");
    dateContainer.className = "timeago"
    dateContainer.setAttribute("datetime", escapeHtml(message.Date))
    messageContainer.appendChild(msgHtml);
    messageContainer.appendChild(dateContainer)
    renderTime()
};

function sendMessage(){
    var message = `{
        "user" : \"${getCookie("username").replace(/%20/g, " ")}\",
        "message" : \"${document.getElementById("message").value}\"
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

  function escapeHtml(unsafe) {
    return unsafe
         .replace(/&/g, "&amp;")
         .replace(/</g, "&lt;")
         .replace(/>/g, "&gt;")
         .replace(/"/g, "&quot;")
         .replace(/'/g, "&#039;");
 }
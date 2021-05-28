const urlParams = new URLSearchParams(window.location.search);
const id = urlParams.get("id");
const wsString = "ws://localhost:5001/" + id;
let socket = new WebSocket(wsString);
let messageContainer = document.getElementById("messages");
messageContainer.scrollTo(0,messageContainer.scrollHeight);
messageContainer.style.scrollBehavior = "smooth";
socket.onopen = function (event) {
	console.log("Connected to chat!");
};

socket.onmessage = function (event) {
    let messageItem = document.createElement("div")
    messageItem.className = "messageItem p-2"
	let msgHtml = document.createElement("p");
    msgHtml.className = "d-inline-block"
	let message = JSON.parse(event.data);
	msgHtml.innerHTML = `<b>${escapeHtml(message.User)}: </b>${escapeHtml(
		message.Message
	)}`;
	let dateContainer = document.createElement("div");
	dateContainer.className = "timeago d-inline-block float-right";
	dateContainer.setAttribute("datetime", escapeHtml(message.Date));
    dateContainer.setAttribute("data-toggle", "tooltip");
	dateContainer.setAttribute("data-placement", "top");
	dateContainer.setAttribute("title", escapeHtml(message.Date));
    messageItem.appendChild(msgHtml)
    messageItem.appendChild(dateContainer)
    messageContainer.appendChild(messageItem)
    messageContainer.scrollTo(0,messageContainer.scrollHeight);
	renderTime();
};

function sendMessage() {
	var message = `{
        "user" : \"${getCookie("username").replace(/%20/g, " ")}\",
        "message" : \"${document.getElementById("message").value}\"
        }`;
	document.getElementById("message").value = ""

	socket.send(message);
}

//FUNCTION STOLEN FROM https://stackoverflow.com/a/15724300
function getCookie(name) {
	const value = `; ${document.cookie}`;
	const parts = value.split(`; ${name}=`);
	if (parts.length === 2) return parts.pop().split(";").shift();
}

function escapeHtml(unsafe) {
	return unsafe
		.replace(/&/g, "&amp;")
		.replace(/</g, "&lt;")
		.replace(/>/g, "&gt;")
		.replace(/"/g, "&quot;")
		.replace(/'/g, "&#039;");
}

function privateRoom() {
	let privateRoom = document.getElementById("private");
	if (document.getElementById("privateRoomCheck").checked) {
		privateRoom.hidden = false;
	} else {
		privateRoom.hidden = true;
		document.getElementById("password").value = "";
	}
}

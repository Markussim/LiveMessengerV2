function renderTime() {
	let TimeAgo = document.querySelectorAll(".timeago");

	TimeAgo.forEach((element) => {
		element.innerHTML = moment(element.attributes[1].value).fromNow();
		element.setAttribute("title", moment(element.attributes[1].value).format("dddd, MMMM Do YYYY, h:mm"))
	});
}
renderTime()

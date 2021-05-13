function renderTime() {
	let TimeAgo = document.querySelectorAll(".timeago");

	TimeAgo.forEach((element) => {
		element.innerHTML = moment(element.attributes[1].value).fromNow();
	});
}
renderTime()
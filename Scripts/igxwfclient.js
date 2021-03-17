class TransistionManager {
	constructor(baseUrl) {
		this.baseUrl = baseUrl;
	}

	closeWindow(errorValue = "") {
		window.returnValue = errorValue;
		window.close();
	}

	async _doFetchPost(url, data) {
		return fetch(url, {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			redirect: 'follow',
			referrer: 'no-referrer',
			body: JSON.stringify(data)
		});
	}

	async POST(action, data) {
		var actionUrl = this.baseUrl + "apps/WorkflowDemo/WorkflowDemo/" + action;
		return this._doFetchPost(actionUrl, data).then(r => r.json());
	}
}
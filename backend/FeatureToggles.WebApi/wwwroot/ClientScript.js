function toggleMessage() {
    var messageElem = document.getElementById('message');
    if (messageElem.innerText) {
        messageElem.innerText = '';
    }
    else {
        messageElem.innerText = FeatureToggles.SecondFeatureVariant;
    }
}
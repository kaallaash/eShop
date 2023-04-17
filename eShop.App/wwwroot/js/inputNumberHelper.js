function replaceValue() {
    var inputField = document.getElementById("price");
    inputField.type = 'text';
    inputField.value = inputField.value.replace('.', ',');
}
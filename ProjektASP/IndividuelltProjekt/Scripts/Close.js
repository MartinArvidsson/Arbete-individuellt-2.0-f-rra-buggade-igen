window.onload = function () {
    var Info = document.getElementById('MessageBox')
    var Exit = document.getElementById("CloseButton")
}
Exit.onclick = function () {
    Info.parentNode.removeChild(Info);
}
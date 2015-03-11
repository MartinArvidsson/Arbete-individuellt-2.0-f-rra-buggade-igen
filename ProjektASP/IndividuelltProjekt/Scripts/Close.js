window.onload = function () {
    var Exit = document.getElementById("CloseButton")
    var Info = document.getElementById('MessageBox')
}
Exit.onclick = function () {
    Info.parentNode.removeChild(Info);
}
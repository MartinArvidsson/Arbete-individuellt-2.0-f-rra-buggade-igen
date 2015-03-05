window.onload = function () {
    var Exit = document.getElementById("CloseButton")
    var Info = document.getElementById('MessageBox')
}
    function confirmation() {
        if (confirm("Vill du ta bort kontakten? Det går inte att ångra sig"))
            return true;
        else return false;
    }

    Exit.onclick = function () {
        Info.parentNode.removeChild(Info);
    }



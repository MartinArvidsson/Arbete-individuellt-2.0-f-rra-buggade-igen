function confirmation() {
    if (confirm("Vill du ta bort Transaktionen? Det går inte att ångra sig"))
        return true;
    else return false;
}
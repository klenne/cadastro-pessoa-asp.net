
var Tempo = new Date();
var Horas, Minutos, Dias,Segundos, Mes, Ano;
function Inicia() {
    Relogio();
    setInterval('Relogio()', 100);
}

function Relogio() {
    Tempo = new Date();
    Horas = Tempo.getHours().toString();
    if (Horas.length == 1) {
        Horas = "0" + Horas;
    }
    Minutos = Tempo.getMinutes().toString();
    if (Minutos.length == 1) {
        Minutos = "0" + Minutos;
    }
    Segundos = Tempo.getSeconds().toString();
    if (Segundos.length == 1) {
        Segundos = "0" + Segundos;
    }
    Dias = Tempo.getDate().toString();
    if (Dias.length == 1) {
        Dias = "0" + Dias;
    }
    Mes = (parseInt(Tempo.getMonth()) + 1).toString();
    if (Mes.length == 1) {
        Mes = "0" + Mes;
    }
    Ano = Tempo.getFullYear().toString();
    if (Ano.length == 1) {
        Ano = "0" + Ano;
    }
    $("#relogioHora").html(Horas + ":" + Minutos + ":" + Segundos);
    $("#relogioData").html(Dias + "/" + Mes + "/" + Ano);
}


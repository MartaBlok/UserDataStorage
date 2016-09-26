var name = $('#Name').val();
var surname = $('#Surname').val();
var address = $('#Address').val();

var modelData = { 'Name': name, 'Surname': surname, 'Address' : address };

$("#log").click(function () {
    $.ajax({
        url: "/Home/LogData",
        datatype: "json",
        type: "POST",
        data: JSON.stringify({ personData: modelData }),
        contentType: "application/json; charset = utf-8"
    });
});
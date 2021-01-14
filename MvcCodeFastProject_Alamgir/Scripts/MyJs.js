$(document).ready(function () {
    loadData();
});

function ToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
}


function loadData() {
    $.ajax({
        url: "/IDoctor/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.InternDoctorID + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Address + '</td>';
                html += '<td>' + item.Email + '</td>';
                html += '<td>' + item.ContactNo + '</td>';
                html += '<td>' + ToJavaScriptDate(item.JoiningDate) + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.InternDoctorID + ')">Edit</a> | <a href="#" onclick="Delele(' + item.InternDoctorID + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        Id: $('#InternDoctorID').val(),
        Name: $('#Name').val(),
        Address: $('#Address').val(),
        Email: $('#Email').val(),
        ContactNo: $('#ContactNo').val(),
        JoiningDate: $('#JoiningDate').val()
    };
    $.ajax({
        url: "/IDoctor/Add",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function getbyID(InternDoctorID) {
    $('#Name').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#ContactNo').css('border-color', 'lightgrey');
    $('#JoiningDate').css('border-color', 'lightgrey');
    $.ajax({
        url: "/IDoctor/getbyID/" + InternDoctorID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#InternDoctorID').val(result.InternDoctorID);
            $('#Name').val(result.Name);
            $('#Address').val(result.Email);
            $('#Email').val(result.Address);
            $('#ContactNo').val(result.ContactNo);
            $('#JoiningDate').val(result.JoiningDate);
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        InternDoctorID: $('#InternDoctorID').val(),
        Name: $('#Name').val(),
        Email: $('#Address').val(),
        Address: $('#Email').val(),
        ContactNo: $('#ContactNo').val(),
        JoiningDate: $('#JoiningDate').val(),
    };
    $.ajax({
        url: "/IDoctor/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#InternDoctorID').val("");
            $('#Name').val("");
            $('#Address').val("");
            $('#Email').val("");
            $('#ContactNo').val("");
            $('#JoiningDate').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Delele(InternDoctorID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/IDoctor/Delete/" + InternDoctorID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
function clearTextBox() {
    $('#InternDoctorID').val("");
    $('#Name').val("");
    $('#Address').val("");
    $('#Email').val("");
    $('#ContactNo').val("");
    $('#JoiningDate').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#ContactNo').css('border-color', 'lightgrey');
    $('#JoiningDate').css('border-color', 'lightgrey');
}
function validate() {
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#Email').val().trim() == "") {
        $('#Email').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Email').css('border-color', 'lightgrey');
    }
    if ($('#Address').val().trim() == "") {
        $('#Address').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Address').css('border-color', 'lightgrey');
    }
    if ($('#ContactNo').val().trim() == "") {
        $('#ContactNo').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ContactNo').css('border-color', 'lightgrey');
    }
    return isValid;

    if ($('#JoiningDate').val().trim() == "") {
        $('#JoiningDate').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#JoiningDate').css('border-color', 'lightgrey');
    }
    return isValid;
}
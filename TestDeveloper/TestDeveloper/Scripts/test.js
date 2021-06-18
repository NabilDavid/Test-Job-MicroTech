

$(document).ready(function () {



    $.ajax({

        url: "https://localhost:44353/api/values",
        type: 'GET',
        dataType: 'json',
        success: function (result) {

            for (var i = 0; i < result.length; i++) {

                $("myTable").append('<table><tr><td>' + result[i].top_Level_Account + '</td> <td>' + result[i].Top_Balance + '</td></tr> </table>')

            }



        },
        error: function () {

        }
    });






});

var data="";
$(document).ready(function (){

   
  

    $.ajax({

        url: 'https://localhost:44353/api/values',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            
          
            for (var i = 0; i < result.length; i++) {

                $("#myTable").append('<tr><td>' + result[i].top_Level_Account + '</td> <td>' + result[i].top_balance + '</td> <td><button class="btnSelect">View</button></td></tr>')

            }



        },
        error: function () {

        }
    });
    $("#myTable").on('click', '.btnSelect', function () {
        // get the current row
        var currentRow = $(this).closest("tr");

        var id = currentRow.find("td:eq(0)").text(); // get current row 1st TD value
      
 


   



        $.ajax({

            url: 'https://localhost:44353/api/values/' + id,
            type: 'GET',
            dataType: 'json',
            success: function (result) {

                for (var i = 0; i < result.length; i++) {
                    debugger
                   
                    data = data + "Accounts   " + result[i].acc_number +" --> "+ result[i].balance+"\n\n" ;
                    swal("Details \n\n"+data);
                 

          

                }
                   data = "";



            },
            error: function () {

            }
        }); // end of ajax with id 
 



        // end of on click
    });



    //end of ready 
    });
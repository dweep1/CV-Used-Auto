/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


function DBAccess() {

    this.CheckLogin = function (username, password) {
        $.ajax({
            type: 'POST',//change to post when post method created
            url: 'CVUsedAutoService/CheckUser',//+username, //set post url
            dataType: 'json', //request dataType
            data: { 'username': username, 'password': password },
            success: function (response, textStatus, xhr) {

                if (response.auth_token != "" && response.auth_token != undefined && response.auth_token != null) {
                    localStorage.setItem('_token', username);
                    window.location = "index.html";
                } else {
                    localStorage.removeItem('_token');
                    //window.location = "login.html";
                    $('#LoginErrorMessage').text('Invalid Username and/or Password!');
                }
            },
            error: function () {
                $('#LoginErrorMessage').text('The network is currently experiencing issues!');
            }

        });
    };

    this.CreateLogin = function (username, password, address, city, state, zipcode) {
        $.ajax({
            type: 'POST',
            url: 'CVUsedAutoService/CreateUser',
            dataType: 'json',
            data: { 'username': username, 'password': password, 'address': address, 'city': city, 'state': state, 'zipcode': zipcode },
            success: function (response, textStatus, xhr) {

                if (response.success) {


                    window.location = "Login.html";
                } else {

                    //window.location = "login.html";
                    $('#LoginErrorMessage').text('Cannot Create User');
                }
            },
            error: function () {
                $('#LoginErrorMessage').text('The network is currently experiencing issues!');
            }

        }

        );
    }

    this.SendContact = function (firstname, lastname, emailaddress, message) {
        $.ajax({
            type: 'POST',//change to post when post method created
            url: 'CVUsedAutoService/StoreContact',//+username, //set post url
            dataType: 'json', //request dataType
            data: { 'FirstName': firstname, 'LastName': lastname, 'EmailAddress': emailaddress, 'Message': message },
            success: function (response, textStatus, xhr) {

                if (response.success) {
                    
                    window.location = "index.html";
                } else {
                    
                }
            },
            error: function () {
                $('#LoginErrorMessage').text('The network is currently experiencing issues!');
            }

        });
    }

    this.GetInventory = function () {
        $.ajax({
            type: 'GET',
            url: 'CVUsedAutoService/GetInventory?format=json',
            datatype: 'json',
            data: {'something':''},
            success: function (response, textStatus, xhr) {
                
                response = JSON.parse(response);
                if (response.success) {
                    var tableContent = response.table;
                    var tableElement = document.getElementById('inventoryTable');
                    
                    for (var i = 0; i < response.table.length; i++) {
                        var rowElement = response.table[i];
                        var tdElements =
                               '<tr><td>' + rowElement.make + '</td>' +
                               '<td>' + rowElement.model + '</td>' +
                               '<td>' + rowElement.color + '</td>' +
                               '<td>' + rowElement.trans + '</td>' +
                               '<td>' + rowElement.drive + '</td>' +
                               '<td>' + rowElement.miles + '</td>' +
                               '<td>' + rowElement.price + '</td>' +
                               '<td>' + rowElement.car_year + '</td>' +
                               '<td>' + rowElement.vin + '</td>' + '</tr>';
                        tableElement.innerHTML += tdElements;
                    }

                } else {

                }
            }, error: function () {
                $('#Error')
            }

        });
    }

        this.SearchInventory = function (make, model) {
            $.ajax({
                type: 'GET',
                url: 'CVUsedAutoService/GetInventory?format=json',
                datatype: 'json',
                data: { 'something': '' },
                success: function (response, textStatus, xhr) {

                    response = JSON.parse(response);
                    if (response.success) {
                        var tableContent = '<table id="inventoryTable" style="width:80%"><tr id="firstRow"><td>make</td><td>model</td><td>color</td><td>trans</td><td>drive</td><td>miles</td><td>price</td><td>car year</td><td>vin</td></tr>';
                        var tableElement = document.getElementById('inventoryTable');

                        for (var i = 0; i < response.table.length; i++) {
                            var rowElement = response.table[i];
                            var tdElements =

                                   '<tr><td>' + rowElement.make + '</td>' +
                                   '<td>' + rowElement.model + '</td>' +
                                   '<td>' + rowElement.color + '</td>' +
                                   '<td>' + rowElement.trans + '</td>' +
                                   '<td>' + rowElement.drive + '</td>' +
                                   '<td>' + rowElement.miles + '</td>' +
                                   '<td>' + rowElement.price + '</td>' +
                                   '<td>' + rowElement.car_year + '</td>' +
                                   '<td>' + rowElement.vin + '</td>' + '</tr>';
                            console.log(make, model);
                            console.log(rowElement.make, rowElement.model);
                            if (rowElement.model.indexOf(model) >= 0 && rowElement.make.indexOf(make) >= 0) {
                                tableContent += tdElements;
                            }
                        }

                        tableContent += "</table>";
                        $("#inventoryResults")[0].innerHTML = tableContent;

                    } else {

                    }
                }, error: function () {

                }

            });
        }
    
}

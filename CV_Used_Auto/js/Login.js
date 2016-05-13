/* global database */

var isDebugging = true;

function ValidateLogin(){
    
    //Some comments
    // #username finds the id with value 'username'
    // .contacts finds all class with value 'contacts'
    // [name="username"] find all atttributes called 'name' with value 'username'
    
    var username = $('#username').val();
    var password = $('#password').val();
    var loginCredentials = { "username" : username, 
                             "password" : password};
     /*var triesLogin  = 3;// Variable for the number of tries
       tries --; //reducing number of tries by one
       username.disabled = true;
       password.disabled = true;
       return false;*/
    
    if(isDebugging){
        if(username !== "" && password !== ""){
            var DBaccess = new DBAccess();
            DBaccess.CheckLogin(username,password);
            //localStorage.setItem('_token', username);
            //database.setItem('_token', '123456789');
            //window.location = "index.html";
        }
        
    }
    return false;
    
}
function CreateLogin() {
    var username = $('#username').val();
    var password = $('#password').val();
    var address  = $('#address').val();
    var city     = $('#city').val();
    var state    = $('#state').val();
    var zipcode = $('#zipcode').val();
    var DBaccess = new DBAccess();
    DBaccess.CreateLogin(username, password, address, city, state, zipcode);
    return false;
}
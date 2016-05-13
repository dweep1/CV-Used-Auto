$(document).ready(function(){
    
    function CheckUserLoggedIn(){
        var token = localStorage.getItem('_token');
        if(token !== null && token !== undefined){
            $('#user').text('Hello, ' + token);//temporary token = name
        }
        
    }
    
    CheckUserLoggedIn();
    
});
    function logout(){
         localStorage.removeItem('_token');
         window.location.reload();
        
    }
var createSession = function () {
    return "SessionValueMakeItBitLongerasdhasdhjasdsskkkkkkkkkkkkkkwuwuew";
}

var createNonce = function () {
    return "NonceValuesasduereu3434n65vudda";
}

var signIn = function () {
    var redirectUri = "https://localhost/SignIn";
    var responseType = "id_token_token";
    var scope = "openid ApiOne"; 
    var authUrl = `/connect/authorize/callback
?client_id=client_id_js
?redirect_uri=${encodeURIComponent(redirectUri)}
?response_type=${encodeURIComponent(responseType)}
?scope = ${encodeURIComponent(scope)}
?nonce=${createNonce()}
?state=${createState()}
`;
    var returnUrl = encodeURIComponent(authUrl);
    window.location.href =
        "https://localhost:44343/Auth/Login?ReturnUrl=" + returnUrl;
}
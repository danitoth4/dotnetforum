import {SERVER} from "./serverUrl";

const SERVER_URL = `${SERVER}/connect/token`

class TokenApi
{
    static async getToken(username, pw)
    {
        let headers = new Headers();
        headers.append("Content-Type", "application/x-www-form-urlencoded"); 

        const body = `grant_type=password&username=${username}&password=${pw}&client_id=ccl&client_secret=sec&scope=api1`;
        const options = 
        {
            headers: headers,
            body: body,
            method: "post"
        }
        return fetch(SERVER_URL, options).then(response => response.json().then( (token) => { sessionStorage.setItem('token', token.access_token); sessionStorage.setItem('my-id', this.parseJwt(token.access_token).sub); } ));
    }

    static parseJwt(token)
    {
        var base64Url = token.split('.')[1];
        var base64 = decodeURIComponent(atob(base64Url).split('').map(function(c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join(''));
    
        return JSON.parse(base64);
    }
}

export default TokenApi;

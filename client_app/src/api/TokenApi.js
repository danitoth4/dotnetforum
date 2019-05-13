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
        return fetch(SERVER_URL, options).then(response => response.json() );
    }
}

export default TokenApi;

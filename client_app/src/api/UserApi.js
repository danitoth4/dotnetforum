import {SERVER} from "./serverUrl";

const SERVER_URL = `${SERVER}/api/user`

class UserApi
{
    static async getUser(id)
    {
        const options = 
        {
            method: "get"
        };

        return fetch(`${SERVER_URL}/${id}`, options).then(response => response.json());
    }
    
}

export default UserApi;
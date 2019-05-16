import {SERVER} from "./serverUrl";

const SERVER_URL = `${SERVER}/api/comment`

class CommentApi
{
    static async sendComment(comment)
    {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        let auth = `Bearer ${sessionStorage.getItem('token')}`;
        headers.append('Authorization', auth);
        const options = 
        {
            headers: headers,
            method: "post",
            body: JSON.stringify(comment)
        };
        return fetch(SERVER_URL, options).then(response => response.json());
    }

    static async deleteComment(id)
    {
        let headers = new Headers();
        let auth = `Bearer ${sessionStorage.getItem('token')}`;
        headers.append('Authorization', auth);
        const options = 
        {
            headers: headers,
            method: "delete",
        };
        return fetch(`${SERVER_URL}/${id}`, options).then(response => response.ok);
    }
}
export default CommentApi;
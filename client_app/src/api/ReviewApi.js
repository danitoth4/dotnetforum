import {SERVER} from "./serverUrl";

const SERVER_URL = `${SERVER}/api/review`

console.log("HOST:", SERVER_URL);

class ReviewApi
{
    static async getAllReviews()
    {
        const options = 
        {
            method: "get"
        };

        return fetch(SERVER_URL, options).then(response => response.json());
    }

    static async getReview(id)
    {
        const options = 
        {
            method: "get"
        };

        return fetch(`${SERVER_URL}/${id}`, options).then(response => response.json());
        
    }

    static async saveReview(review)
    {
        let headers = new Headers;
        headers.append('Content-Type', 'application/json');
        const options =
            {
                headers: headers,
                body: JSON.stringify(review)
            };
        let url = SERVER_URL; 
        if(review.id && review.id != 0)
        {
            options.method = "put";
            url = `${url}/${review.id}`;
        }
        else
        {
            options.method = "post";           
        }
        return fetch(url, options).then(response => response.json());
    }

    static async deleteReview(id)
    {
        const options = 
        {
            method: "delete",
        }
        return fetch(`${SERVER_URL}/${id}`, options);
    }
}
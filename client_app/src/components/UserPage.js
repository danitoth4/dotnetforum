import React from 'react';
import UserApi from '../api/UserApi';
import { Link } from 'react-router-dom';

class UserPage extends React.Component
{
    constructor(props)
    {
        super(props);
        this.state =
        {
            id: props.match.params.userId
        };
    }

    componentDidMount()
    {
        if(this.props.location.user)
        {
            this.setState(
                {
                    user: this.props.location.user
                }
           );
       }
       else
       {
           UserApi.getUser(this.state.id).then(data => this.setState({user: data}));
       }
        
    }

    render()
    {
        if(this.state.user)
        {
            const reviews = this.state.user.reviews.map(
                review => 
                {
                    return (
                        <div> <Link to = {{ pathname: `/review/${review.id}` }}>  <h3> {review.id} </h3>  </Link> </div> 
                    ); 
                } 
            );
            return(
                <div>
                    <h1>{this.state.user.userName}</h1>
                    <h2> Reviews </h2>
                    {reviews}
                </div>
            );
        }
        else
        {
            return(
                <div />
            );
        }
    }
}

export default UserPage;
import React from 'react';
import UserApi from '../api/UserApi';

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
            console.log(this.state.user)
            return(
                <div>
                    {this.state.user.userName}
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
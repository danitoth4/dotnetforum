import React from 'react';
import {Button} from 'grommet';
import {Link} from 'react-router-dom';

class Comment extends React.Component
{
    render()
    {
        
        console.log(this.props.comment);
        return(
            <div>
                <p>
                    {this.props.comment.content}
                </p>
                <div>{`at ${this.props.comment.writenAt.slice(0,16).replace("T", " ")} by ` } 
                <Link to = 
                    {{
                        pathname: `/user/${this.props.comment.user.id}`
                    }}
                >
                {this.props.comment.user.userName}
                </Link>
                </div>
                {
                    this.props.canEdit ?
                    <Button color="accent-3" label="Delete" onClick = {() => this.props.handleDelete(this.props.comment.id)}  /> : <div />
                }
               
                <hr/>
            </div>
        );
    }
}

export default Comment;
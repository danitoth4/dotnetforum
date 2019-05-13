import React from 'react';
import { Button } from 'grommet';
import {Link} from 'react-router-dom';

class ListItem extends React.Component
{
    render()
    {
        return (
            <div>
                <h1>{this.props.title}</h1>
                {this.props.created}
                <p>
                    {this.props.content.length < 800 ? this.props.content : this.props.content.slice(0,797).concat("...") }
                </p>
                <div > {this.props.commentNo} comments </div>
                <Link to = 
                    {{
                        pathname: `review/${this.props.id}`,
                        review: this.props.review
                    }}
                >
                    <Button color="accent-3" label="read"/>
                </Link>             
                <hr />
            </div>
        );
    }
}

export default ListItem;
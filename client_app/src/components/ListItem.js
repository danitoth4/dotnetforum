import React from 'react';

class ListItem extends React.Component
{

    moreButtonClicked()
    {
        console.log('more button clicked');
    }

    render()
    {
        return (
            <div>
                <h1>{this.props.title}</h1>
                <text>{this.props.created}</text>
                <p>
                    {this.props.content.length < 800 ? this.props.content : this.props.content.slice(0,797).concat("...") }
                </p>
                <div > {this.props.commentNo} comments <button onClick={this.moreButtonClicked.bind(this)}>More...</button> </div>
            </div>
        );
    }
}

export default ListItem;
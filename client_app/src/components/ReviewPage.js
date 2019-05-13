import React from 'react';
import ReviewApi from '../api/ReviewApi';

class ReviewPage extends React.Component
{

    constructor(props)
    {
        super(props);
        this.state =
        {
            id: props.match.params.reviewId
        };       
    }

    componentDidMount()
    {
        if(this.props.location.review)
        {
            this.setState(
                 {
                     review: this.props.location.review
                 }
            );
        }
        else
        {
            ReviewApi.getReview(this.state.id).then(data => this.setState({review: data}));
        }
    }

    render()
    {
        if(this.state.review)
        {
            return(
                <div>
                <h1>{this.state.review.creation.title}</h1>
                {this.state.review.content}
                <ul>
                    {this.state.review.comments.map((comment) => <li>{comment.content}</li>)}
                </ul>
                </div>
            );
        }
        else
        {
            return <div />
        }
    }
}

export default ReviewPage;
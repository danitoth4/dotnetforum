import React from 'react';
import ReviewApi from '../api/ReviewApi';
import Comment from './Comment';
import { TextArea, Button } from 'grommet';
import CommentApi from '../api/CommentApi';

class ReviewPage extends React.Component
{

    constructor(props)
    {
        super(props);
        this.state =
        {
            id: props.match.params.reviewId,
            createNew: false,
            refresh: false
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
            this.forceRefresh();
        }
    }

    newCommentButtonClicked(e)
    {
        this.setState(
            { createNew: true }
        );
    }

    forceRefresh()
    {
        ReviewApi.getReview(this.state.id).then(data => this.setState({review: data}));
    }

    deleteCommentButtonClicked(id)
    {
        CommentApi.deleteComment(id).then( ok => { console.log(ok); this.forceRefresh() } );
    }

    sendButtonClicked(e)
    {
        var tf = this.refs.textfield;
        const comment = 
        {
            reviewId: this.state.id,
            content: tf.value,
            
        };
        CommentApi.sendComment(comment).then( d => this.forceRefresh() );
        this.setState(
            {createNew: false}
        );
    }

    render()
    {
        if(this.state.review)
        {
            const comments = this.state.review.comments.map(
                (comment) =>  { return (
                    <Comment key =  {comment.id} canEdit = { this.state.id === sessionStorage.getItem('my-id') || comment.id === sessionStorage.getItem('my-id') } comment = {comment} handleDelete={this.deleteCommentButtonClicked.bind(this)}></Comment>
                    ); 
            });
            return(
                <div>
                <h1>{this.state.review.creation.title}</h1>
                {this.state.review.content}
                <h1>Comments</h1>      
                    {comments}
                {this.state.createNew ? <div> <TextArea id="textfield" ref = "textfield"></TextArea> <Button label="Send" onClick={this.sendButtonClicked.bind(this)}/>  </div> : <Button label = "New" onClick={this.newCommentButtonClicked.bind(this)} />}
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
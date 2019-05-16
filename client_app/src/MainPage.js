import React from 'react';
import { Grid, Box, Heading, Button } from 'grommet';
import ListItem from './components/ListItem';
import ReviewApi from './api/ReviewApi';
import TokenApi from './api/TokenApi';

class MainPage extends React.Component
{
    constructor(props)
    {
        super(props);
        this.state =
        {
            list: []
        }; 
        ReviewApi.getAllReviews().then(
            data => this.setState(
                {
                    list: data
                }
            )
        );
        TokenApi.getToken("asd", "Security_Microsoft4");
    }

    render()
    {
        const items = this.state.list.map(
            item =>
            {
                return (
                    <ListItem key={item.id} id={item.id} title = {item.creation.title} commentNo = {item.comments.length} created = {item.writenAt.slice(0,16).replace("T", " ")} content = {item.content} review = {item}  />
                );
            }
        );
        return(
            <Grid fill={true}
                rows={['xsmall', 'auto']}
                columns={['90%', 'flex']}

                areas={[
                    { name: 'header', start: [0, 0], end: [1, 0] },

                    { name: 'main', start: [0, 1], end: [0, 1] },
                    { name: 'side', start: [1, 0], end: [1, 1] },
                ]}>
                <Box gridArea='header' direction="row"
                    align="center"
                    pad="medium"
                    justify="between"
                    background='white'>
                    <Heading level='2'>Reviews</Heading>
                    <Box direction="row" pad={{ horizontal: "small", }} gap="small" >
                        <Button label="New" style={{ color: "white" }} primary={true} onClick={() => {console.log("clicked")}}/>
                    </Box>
                </Box>
                <Box gridArea='main' background='white' pad="medium" fill="vertical">
                    {items}
                </Box>
            </Grid>
        );
    }
}

export default MainPage;
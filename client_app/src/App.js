import React from 'react';
import {Route, BrowserRouter as Router} from 'react-router-dom';
import MainPage from './MainPage';
import ReviewPage from './components/ReviewPage'
import UserPage from './components/UserPage';

function App() {
  return (
    <Router>      
      <Route exact={true} path="/" component = {MainPage}/>
      <Route path="/review/:reviewId" render = {(props) => <ReviewPage {...props}/> }/>
      <Route path="/user/:userId" render = { (props) => <UserPage {...props} /> }/>     
    </Router>
  );
}

export default App;

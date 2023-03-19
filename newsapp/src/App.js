import React from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import NewsPage from './pages/NewsPage';

function App() {
    return (
        <Router>
            <Route path="/news" component={NewsPage} />
        </Router>
    );
}

export default App;

import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import NewsPage from './pages/NewsPage';
import SearchPage from './pages/SearchPage';

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<NewsPage />} />
                <Route exact path="/search" element={<SearchPage />} />
            </Routes>
        </Router>
    );
}

export default App;

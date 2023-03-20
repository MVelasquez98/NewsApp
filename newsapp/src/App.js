import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import NewsPage from './pages/NewsPage';

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/news" element={<NewsPage />} />
            </Routes>
        </Router>
    );
}

export default App;

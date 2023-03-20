import React, { useState, useEffect } from 'react';
import NewsList from '../components/NewsList';

function NewsPage() {
    const [news, setNews] = useState([]);

    useEffect(() => {
        fetch('https://newsapi.org/v2/top-headlines?country=us&apiKey=9e8a123eec974a9e9228d32c40439452')
            .then(response => response.json())
            .then(data => setNews(data.articles));
    }, []);

    return (
        <div className="news-page">
            <h1>Latest News</h1>
            <NewsList news={news} />
        </div>
    );
}

export default NewsPage;

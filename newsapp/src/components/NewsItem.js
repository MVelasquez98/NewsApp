import React from 'react';

const NewsItem = ({ article }) => {
    return (
        <div className="news-item">
            <img src={article.urlToImage} alt={article.title} />
            <div className="news-details">
                <h2>{article.title}</h2>
                <p>{article.description}</p>
                <a href={article.url} target="_blank" rel="noopener noreferrer">Read more</a>
            </div>
        </div>
    );
};

export default NewsItem;

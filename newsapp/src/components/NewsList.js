import React from 'react';
import { Grid } from '@material-ui/core';
import NewsItem from './NewsItem';

const NewsList = ({ news }) => {
    return (
        <Grid container spacing={3}>
            {news.map((article, index) => (
                <Grid key={index} item xs={12} sm={6} md={4}>
                    <NewsItem article={article} />
                </Grid>
            ))}
        </Grid>
    );
};

export default NewsList;

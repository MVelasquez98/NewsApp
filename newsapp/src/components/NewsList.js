import React from 'react';
import NewsItem from './NewsItem';
import { makeStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';

const useStyles = makeStyles((theme) => ({
  newsList: {
    display: 'flex',
    justifyContent: 'center',
    padding: theme.spacing(2),
  },
  gridContainer: {
    width: '100%',
    maxWidth: '1000px',
  },
}));

const NewsList = ({ news }) => {
  const classes = useStyles();

  return (
    <div className={classes.newsList}>
      <Grid container spacing={2} className={classes.gridContainer}>
        {news.map((article, index) => (
          <Grid item xs={12} key={index}>
            <NewsItem article={article} />
          </Grid>
        ))}
      </Grid>
    </div>
  );
};

export default NewsList;

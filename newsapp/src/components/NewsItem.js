import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';

const useStyles = makeStyles((theme) => ({
  newsItem: {
    marginBottom: theme.spacing(2),
    padding: theme.spacing(2),
    boxShadow: '0px 2px 6px rgba(0, 0, 0, 0.1)',
    borderRadius: '4px',
  },
  imageContainer: {
    display: 'flex',
    justifyContent: 'center',
    alignItems: 'center',
    '& img': {
      width: '100%',
      maxWidth: '100%',
      height: 'auto',
      borderRadius: '4px',
    },
  },
  detailsContainer: {
    paddingLeft: theme.spacing(2),
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'space-between',
  },
  title: {
    fontSize: '24px',
    fontWeight: 'bold',
    marginBottom: theme.spacing(1),
  },
  description: {
    fontSize: '16px',
    marginBottom: theme.spacing(1),
  },
  readMore: {
    marginTop: 'auto',
  },
}));

const NewsItem = ({ article }) => {
  const classes = useStyles();

  return (
    <div className={classes.newsItem}>
      <Grid container spacing={2}>
        <Grid item xs={12} sm={6} className={classes.imageContainer}>
          <img src={article.urlToImage} alt={article.title} />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.detailsContainer}>
          <div>
            <h2 className={classes.title}>{article.title}</h2>
            <p className={classes.description}>{article.description}</p>
          </div>
          <div className={classes.readMore}>
            <a href={article.url} target="_blank" rel="noopener noreferrer">
              Read more
            </a>
            <p>{article.publishedAt}</p>
          </div>
        </Grid>
      </Grid>
    </div>
  );
};

export default NewsItem;

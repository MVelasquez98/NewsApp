import React from 'react';
import NewsItem from './NewsItem';
import { makeStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';

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
  error: {
    padding: theme.spacing(2),
    color: theme.palette.error.dark,
    fontWeight: 'bold',
  },
}));

const NewsList = ({ news }) => {
  const classes = useStyles();

  if (news.length === 0) {
    return (
      <Typography variant="h5" align="center" className={classes.error}>
        No se encontraron resultados para su búsqueda.
      </Typography>
    );
  }

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

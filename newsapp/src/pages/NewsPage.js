import React, { useState, useEffect } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { Grid, Paper, Select, MenuItem, Typography, InputLabel } from '@material-ui/core';
import { Link } from 'react-router-dom';
import NewsList from '../components/NewsList';
import Pagination from '@material-ui/lab/Pagination';

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    padding: theme.spacing(2),
  },
  paper: {
    padding: theme.spacing(2),
    textAlign: 'center',
    color: theme.palette.text.secondary,
    display: 'flex',
    alignItems: 'center',
  },
  formControl: {
    margin: theme.spacing(1),
    minWidth: 120,
  },
  selectEmpty: {
    marginTop: theme.spacing(2),
  },
  pagination: {
    display: 'flex',
    justifyContent: 'center',
    margin: theme.spacing(3),
  },
}));

function NewsPage() {
  const classes = useStyles();
  const [country, setCountry] = useState('us');
  const [news, setNews] = useState([]);
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);

  useEffect(() => {
    fetch(
      `https://newsapi.org/v2/top-headlines?country=${country}&pageSize=${pageSize}&page=${page}&apiKey=9e8a123eec974a9e9228d32c40439452`
    )
      .then((response) => response.json())
      .then((data) => setNews(data.articles));
  }, [country, pageSize, page]);

  const handleChangeCountry = (event) => {
    setCountry(event.target.value);
    setPage(1); // Reset page to 1 when country is changed
  };

  const handleChangePage = (event, value) => {
    setPage(value);
  };

  const handleChangePageSize = (event) => {
    setPageSize(event.target.value);
    setPage(1); // Reset page to 1 when page size is changed
  };

  return (
    <div className={classes.root}>
      <Grid container spacing={3}>
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <Typography variant="h4" component="h1" align="center">
              Ultimas Noticias
            </Typography>
            <div className={classes.navbar}>
              <InputLabel id="select-pais-label">País:</InputLabel>
              <Select
                labelId="select-pais-label"
                value={country}
                onChange={handleChangeCountry}
                className={classes.selectEmpty}
              >
                <MenuItem value={'us'}>US</MenuItem>
                <MenuItem value={'ar'}>Argentina</MenuItem>
              </Select>
              <Link to="/search">
                <button>Buscar</button>
              </Link>
            </div>
          </Paper>
        </Grid>
        <Grid item xs={12}>
          <NewsList news={news} />
        </Grid>
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <InputLabel id="select-results-label">Mostrar resultados:</InputLabel>
            <Select
              labelId="select-results-label"
              value={pageSize}
              onChange={handleChangePageSize}
              className={classes.selectEmpty}
            >
              <MenuItem value={5}>5</MenuItem>
              <MenuItem value={10}>10</MenuItem>
              <MenuItem value={15}>15</MenuItem>
              <MenuItem value={20}>20</MenuItem>
            </Select>
            <Pagination
              className={classes.pagination}
              count={Math.ceil(100 / pageSize)}
              page={page}
              onChange={handleChangePage}
              variant="outlined"
              shape="rounded"
            />
          </Paper>
        </Grid>
      </Grid>
    </div>
  );
}

export default NewsPage;

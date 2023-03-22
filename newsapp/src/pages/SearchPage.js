import React, { useState, useEffect } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { Grid, Paper, TextField, InputLabel, Select, MenuItem, Button } from '@material-ui/core';
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

function SearchPage() {
  const classes = useStyles();
  const [fromDate, setFromDate] = useState('');
  const [toDate, setToDate] = useState('');
  const [query, setQuery] = useState('');
  const [news, setNews] = useState([]);
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10);
  const [totalResults, setTotalResults] = useState(0);

  useEffect(() => {
    const url= `https://localhost:5001/api/news/search?dateFrom=${fromDate}&dateTo=${toDate}&keywords=${query}&page=${page}&pageSize=${pageSize}`;  
    fetch(url)
      .then((response) => response.json())
      .then((data) => {
        if (data) {
          setNews(data);
          setTotalResults(data.length);
        } else {
          setNews([]);
          setTotalResults(0);
        }
      })
      .catch((error) => console.error(error));
  }, [query, fromDate, toDate, pageSize, page]);

  const handleChangePage = (event, value) => {
    setPage(value);
  };

  const handleChangePageSize = (event) => {
    setPageSize(event.target.value);
    setPage(1);
  };

  const handleFromDateChange = (event) => {
    setFromDate(event.target.value);
  };

  const handleToDateChange = (event) => {
    setToDate(event.target.value);
  };

  const handleQueryChange = (event) => {
    setQuery(event.target.value);
  };

  const handleSearchSubmit = (event) => {
    event.preventDefault();
    setPage(1);
  };

  return (
    <div className={classes.root}>
      <Grid container spacing={3}>
        <Grid item xs={12}>
          <Paper className={classes.paper}>
            <form onSubmit={handleSearchSubmit}>
              <TextField
                type="date"
                label="Desde"
                value={fromDate}
                onChange={handleFromDateChange}
                className={classes.textField}
                InputLabelProps={{
                  shrink: true,
                }}
              />
              <TextField
                type="date"
                label="Hasta"
                value={toDate}
                onChange={handleToDateChange}
                className={classes.textField}
                InputLabelProps={{
                  shrink: true,
                }}
              />
              <TextField
                label="Palabras clave"
                value={query}
                onChange={handleQueryChange}
                className={classes.textField}
              />
              <Button type="submit" variant="contained" color="primary">
                Buscar
              </Button>
            </form>
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
              count={Math.ceil(totalResults / pageSize)}
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

export default SearchPage;


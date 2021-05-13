import React from "react";
import type { FC } from "react";
import { makeStyles } from "@material-ui/core";

import Page from "../../components/Page";
import Hero from "./Hero";
import Features from "./Features";
import FAQs from "./FAQs";

const useStyles = makeStyles(() => ({
  root: {},
}));

const Home: FC = () => {
  const classes = useStyles();

  return (
    <Page className={classes.root} title="Home">
      <Hero />
      <Features />
      <FAQs />
    </Page>
  );
};

export default Home;

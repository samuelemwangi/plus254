import React from "react";
import type { FC } from "react";

// Material
import { makeStyles, experimentalStyled as styled } from "@material-ui/core";

// Components
import Page from "../../components/Page";
import Hero from "./Hero";
import Diversity from "./Diversity";
import Summary from "./Summary";
import Footer from "./Footer";

// Styles
const useStyles = makeStyles(() => ({
  root: {},
}));

const ContentStyle = styled("div")(({ theme }) => ({
  overflow: "hidden",
  position: "relative",
  backgroundColor: theme.palette.background.default,
}));

// Main component
const Home: FC = () => {
  const classes = useStyles();

  return (
    <Page className={classes.root} title="Home">
      <Hero />
      <ContentStyle>
        <Diversity />
        <Summary />
        <Footer />
      </ContentStyle>
    </Page>
  );
};

export default Home;

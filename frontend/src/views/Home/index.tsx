import React from "react";
import type { FC } from "react";

// Material
import { experimentalStyled as styled } from "@material-ui/core";

// Components
import Page from "../../components/Page";
import Hero from "./Hero";
import Diversity from "./Diversity";
import Summary from "./Summary";

// Styles
const PageStyle = styled(Page)(() => ({}));

const ContentStyle = styled("div")(({ theme }) => ({
  overflow: "hidden",
  position: "relative",
  backgroundColor: theme.palette.background.default,
}));

// Main component
const Home: FC = () => {
  return (
    <PageStyle title="Home">
      <Hero />
      <ContentStyle>
        <Diversity />
        <Summary />
      </ContentStyle>
    </PageStyle>
  );
};

export default Home;

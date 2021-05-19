/* eslint-disable react/no-unescaped-entities */
import React, { FC } from "react";
import { motion } from "framer-motion";
import { Link as RouterLink } from "react-router-dom";

// material
import { experimentalStyled as styled } from "@material-ui/core/styles";
import { Button, Box, Container, Typography } from "@material-ui/core";
// routes

//
import {
  varFadeIn,
  varWrapEnter,
  varFadeInUp,
  varFadeInRight,
} from "../../../components/Animate";

// interfaces
interface IHeroProps {
  className?: string;
}

// styles
const RootStyle = styled(motion.div)(({ theme }) => ({
  position: "relative",
  backgroundColor: "#F2F3F5",
  [theme.breakpoints.up("md")]: {
    top: 0,
    left: 0,
    width: "100%",
    height: "100vh",
    display: "flex",
    position: "fixed",
    alignItems: "center",
  },
}));

const ContentStyle = styled("div")(({ theme }) => ({
  zIndex: 10,
  maxWidth: 520,
  margin: "auto",
  textAlign: "center",
  position: "relative",
  paddingTop: theme.spacing(15),
  paddingBottom: theme.spacing(15),
  [theme.breakpoints.up("md")]: {
    margin: "unset",
    textAlign: "left",
  },
}));

const HeroOverlayStyle = styled(motion.img)({
  zIndex: 9,
  width: "100%",
  height: "100%",
  objectFit: "cover",
  position: "absolute",
});

const HeroImgStyle = styled(motion.img)(({ theme }) => ({
  top: 0,
  right: 0,
  bottom: 0,
  zIndex: 8,
  width: "100%",
  margin: "auto",
  position: "absolute",
  [theme.breakpoints.up("lg")]: {
    right: "15%",
    width: "auto",
    height: "72vh",
  },
}));

// main component
const Hero: FC<IHeroProps> = () => {
  return (
    <>
      <RootStyle initial="initial" animate="animate" variants={varWrapEnter}>
        <HeroOverlayStyle
          alt="overlay"
          src="/static/home/overlay.svg"
          variants={varFadeIn}
        />

        <HeroImgStyle
          alt="hero"
          src="/static/home/kenya.png"
          variants={varFadeInUp}
        />

        <Container maxWidth="lg">
          <ContentStyle>
            <motion.div variants={varFadeInRight}>
              <Typography variant="h1" sx={{ color: "common.white" }}>
                Welcome to
                <br />
                <Typography
                  component="span"
                  variant="h1"
                  sx={{ color: "primary.main" }}
                >
                  plus254
                </Typography>
              </Typography>
            </motion.div>

            <motion.div variants={varFadeInRight}>
              <Typography sx={{ py: 5, color: "common.white" }}>
                A country in East Africa with coastline on the Indian Ocean. It
                encompasses savannah, lakelands, the dramatic Great Rift Valley
                and mountain highlands. It's also home to wildlife like lions,
                elephants and rhinos. From Nairobi, the capital, safaris visit
                the Maasai Mara Reserve, known for its annual wildebeest
                migrations, and Amboseli National Park, offering views of
                Tanzania's 5,895m Mt. Kilimanjaro. ― Google
              </Typography>
            </motion.div>

            <motion.div variants={varFadeInRight}>
              <Button
                size="large"
                variant="contained"
                component={RouterLink}
                to="/"
              >
                Explore
              </Button>
            </motion.div>

            <Box
              sx={{
                mt: 5,
                display: "flex",
                justifyContent: { xs: "center", md: "flex-start" },
                "& > :not(:last-of-type)": { mr: 1.5 },
              }}
            >
              <motion.img
                variants={varFadeInRight}
                src="/static/home/icons/forest.png"
              />
              <motion.img
                variants={varFadeInRight}
                src="/static/home/icons/lake.png"
              />
              <motion.img
                variants={varFadeInRight}
                src="/static/home/icons/culture.png"
              />
              <motion.img
                variants={varFadeInRight}
                src="/static/home/icons/lion.png"
              />
              <motion.img
                variants={varFadeInRight}
                src="/static/home/icons/running.png"
              />
            </Box>
          </ContentStyle>
        </Container>
      </RootStyle>
      <Box sx={{ height: { md: "100vh" } }} />
    </>
  );
};

export default Hero;

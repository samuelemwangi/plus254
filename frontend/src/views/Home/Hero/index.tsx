import React from "react";
import type { FC } from "react";
import PropTypes from "prop-types";
import clsx from "clsx";
import { Link as RouterLink } from "react-router-dom";
import { Box, Container, Grid, Typography, Button } from "@material-ui/core";
import {
  WebOutlined,
  PhoneAndroidOutlined,
  GradeOutlined,
  LinkOutlined,
} from "@material-ui/icons";
// Styles
import heroStyles from "./HeroStyles";

interface IHeroProps {
  className?: string;
}

const Hero: FC<IHeroProps> = ({ className, ...rest }) => {
  const classes = heroStyles();

  return (
    <div className={clsx(classes.root, className)} {...rest}>
      <Container maxWidth="lg">
        <Grid container spacing={3}>
          <Grid item xs={12} md={5}>
            <Box
              display="flex"
              flexDirection="column"
              justifyContent="center"
              height="100%"
            >
              <Typography variant="h1" color="textPrimary">
                Upfik
              </Typography>
              <Box mt={3}>
                <Typography variant="body1" color="textSecondary">
                  A technology consulting company providing solutions to SMEs
                  and Corporations.
                </Typography>
              </Box>
              <Box mt={3}>
                <Grid container spacing={3}>
                  <Grid item>
                    <Typography variant="h1" color="secondary">
                      <WebOutlined fontSize="large" />
                    </Typography>
                    <Typography variant="overline" color="textSecondary">
                      Web
                    </Typography>
                  </Grid>
                  <Grid item>
                    <Typography variant="h1" color="secondary">
                      <PhoneAndroidOutlined fontSize="large" />
                    </Typography>
                    <Typography variant="overline" color="textSecondary">
                      Mobile
                    </Typography>
                  </Grid>
                  <Grid item>
                    <Typography variant="h1" color="secondary">
                      <GradeOutlined fontSize="large" />
                    </Typography>
                    <Typography variant="overline" color="textSecondary">
                      Quality
                    </Typography>
                  </Grid>
                  <Grid item>
                    <Typography variant="h1" color="secondary">
                      <LinkOutlined fontSize="large" />
                    </Typography>
                    <Typography variant="overline" color="textSecondary">
                      Integration
                    </Typography>
                  </Grid>
                </Grid>
              </Box>
              <Box mt={3}>
                <Button
                  component={RouterLink}
                  to="/contact-us"
                  variant="outlined"
                  size="large"
                  color="secondary"
                >
                  Hire us
                </Button>
              </Box>
            </Box>
          </Grid>
          <Grid item xs={12} md={7}>
            <Box position="relative">
              <div className={classes.image}>
                <img alt="Presentation" src="/static/home/content_team.svg" />
              </div>
            </Box>
          </Grid>
        </Grid>
      </Container>
    </div>
  );
};

Hero.propTypes = {
  className: PropTypes.string,
};

export default Hero;

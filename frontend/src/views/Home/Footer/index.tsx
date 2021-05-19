import React from "react";
import type { FC } from "react";
import clsx from "clsx";

// Material
import {
  Box,
  Container,
  Grid,
  Typography,
  List,
  ListItem,
  ListItemText,
} from "@material-ui/core";
import { Instagram, Twitter, Facebook } from "@material-ui/icons";
import { makeStyles } from "@material-ui/styles";
import { Theme } from "../../../theme";

// interfaces
interface IFooterProps {
  className?: string;
}

// Styles
const useStyles = makeStyles((theme: Theme) => ({
  root: {
    backgroundColor: theme.palette.background.dark,
    paddingTop: theme.spacing(6),
    paddingBottom: theme.spacing(6),
    "& dt": {
      marginTop: theme.spacing(2),
    },
  },
  services: {
    paddingTop: "20px",
    "& li": {
      padding: "2px 0px 2px 0px",
    },
  },
  socialLinks: {
    paddingTop: "10px",
    textDecoration: "none",
    "& *": {
      color: theme.palette.text.secondary,
    },
    "& a": {
      textDecoration: "none",
      paddingRight: "10px",
    },
  },
}));

// Main Component
const Footer: FC<IFooterProps> = ({ className, ...rest }) => {
  const classes = useStyles();

  return (
    <div className={clsx(classes.root, className)} {...rest}>
      <Container maxWidth="lg">
        <Grid container spacing={3} component="dl">
          <Grid item xs={12} md={4}>
            <Box mt={6}>
              <dt>
                <Typography variant="h4" color="textPrimary">
                  Who we are
                </Typography>
              </dt>
              <dd>
                <Typography variant="body1" color="textSecondary">
                  We are plus254
                </Typography>
              </dd>
            </Box>
          </Grid>
          <Grid item xs={12} md={4}>
            <Box mt={6}>
              <dt>
                <Typography variant="h4" color="textPrimary">
                  What we offer
                </Typography>
              </dt>
              <dd>
                <List disablePadding className={classes.services}>
                  <ListItem disableGutters>
                    <ListItemText primary="-  Information" />
                  </ListItem>
                  <ListItem disableGutters>
                    <ListItemText primary="-  Information" />
                  </ListItem>
                </List>
              </dd>
            </Box>
          </Grid>
          <Grid item xs={12} md={4}>
            <Box mt={6}>
              <dt>
                <Typography variant="h6" color="textPrimary">
                  Phone
                </Typography>
              </dt>
              <dd>
                <address>(+254)111-</address>
              </dd>
              <dt>
                <Typography variant="h6" color="textPrimary">
                  Email Address
                </Typography>
              </dt>
              <dd>
                <address>dummy@plus54.com</address>
              </dd>
              <dt>
                <Typography variant="h6" color="textPrimary">
                  Social Links
                </Typography>
              </dt>
              <dd>
                <div className={classes.socialLinks}>
                  <a
                    href="https://www.instagram.com"
                    target="_blank"
                    rel="noreferrer"
                  >
                    <Instagram />
                  </a>
                  <a
                    href="https://twitter.com"
                    target="_blank"
                    rel="noreferrer"
                  >
                    <Twitter />
                  </a>
                  <a
                    href="https://www.facebook.com"
                    target="_blank"
                    rel="noreferrer"
                  >
                    <Facebook />
                  </a>
                </div>
              </dd>
            </Box>
          </Grid>
        </Grid>
      </Container>
    </div>
  );
};

export default Footer;

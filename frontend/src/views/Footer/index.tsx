import React from "react";
import type { FC } from "react";

// Material
import {
  Box,
  Container,
  Grid,
  Typography,
  List,
  ListItem,
  ListItemText,
  experimentalStyled as styled,
  alpha,
  useTheme,
} from "@material-ui/core";
import { Instagram, Twitter, Facebook } from "@material-ui/icons";

// Theme
import { Theme } from "../../theme";

// Styles
const RowStyle = styled("div")(() => {
  const appTheme: Theme = useTheme();

  return {
    backgroundColor: appTheme.palette.background.dark,
    paddingTop: appTheme.spacing(6),
    paddingBottom: appTheme.spacing(6),
    "& dt": {
      marginTop: appTheme.spacing(2),
    },
    backgroundImage:
      appTheme.palette.mode === "light"
        ? `linear-gradient(180deg, ${alpha(
            appTheme.palette.grey[400],
            0
          )} 0%, ${appTheme.palette.grey[400]} 100%)`
        : "none",
  };
});

const SocialLinksStyle = styled("div")(() => {
  const appTheme: Theme = useTheme();

  return {
    paddingTop: "10px",
    textDecoration: "none",
    "& *": {
      color: appTheme.palette.text.secondary,
    },
    "& a": {
      textDecoration: "none",
      paddingRight: "10px",
    },
  };
});

// interfaces
interface IFooterProps {
  className?: string;
}

// Main Component
const Footer: FC<IFooterProps> = ({ ...rest }) => {
  return (
    <RowStyle {...rest}>
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
                <List
                  disablePadding
                  sx={{
                    paddingTop: "20px",
                    "& li": {
                      padding: "2px 0px 2px 0px",
                    },
                  }}
                >
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
                <SocialLinksStyle>
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
                </SocialLinksStyle>
              </dd>
            </Box>
          </Grid>
        </Grid>
      </Container>
    </RowStyle>
  );
};

export default Footer;

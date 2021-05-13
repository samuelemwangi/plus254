import React from "react";
import type { FC } from "react";
import { Link as RouterLink } from "react-router-dom";
import {
  Box,
  Button,
  Container,
  Typography,
  useTheme,
  useMediaQuery,
} from "@material-ui/core";
import clsx from "clsx";

import Page from "../../../components/Page";

// Styles
import useStyles from "./NotFoundViewStyles";

interface INotFoundViewProps {
  className?: string;
}

const NotFoundView: FC<INotFoundViewProps> = ({ className }) => {
  const classes = useStyles();
  const theme = useTheme();
  const mobileDevice = useMediaQuery(theme.breakpoints.down("sm"));

  return (
    <Page className={clsx(classes.root, className)}>
      <Container maxWidth="lg">
        <Typography
          align="center"
          variant={mobileDevice ? "h4" : "h1"}
          color="textPrimary"
        >
          404: Page not found
        </Typography>
        <Typography align="center" variant="subtitle2" color="textSecondary">
          This page is not available. Sorry about that.
        </Typography>
        <Box mt={6} display="flex" justifyContent="center">
          <img
            alt="Page not found"
            className={classes.image}
            src="/static/not_found.svg"
          />
        </Box>
        <Box mt={6} display="flex" justifyContent="center">
          <Button
            color="secondary"
            component={RouterLink}
            to="/"
            variant="outlined"
          >
            Back to home
          </Button>
        </Box>
      </Container>
    </Page>
  );
};

export default NotFoundView;

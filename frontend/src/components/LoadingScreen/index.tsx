import React, { useEffect } from "react";
import type { FC } from "react";
import NProgress from "nprogress";
import { Box, LinearProgress } from "@material-ui/core";

// Styles
import loadingScreenStyles from "./LoadingScreenStyles";

const LoadingScreen: FC = () => {
  const classes = loadingScreenStyles();

  useEffect(() => {
    NProgress.start();

    return () => {
      NProgress.done();
    };
  }, []);

  return (
    <div className={classes.root}>
      <Box width={400}>
        <LinearProgress />
      </Box>
    </div>
  );
};

export default LoadingScreen;

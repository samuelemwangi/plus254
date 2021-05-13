import React from "react";
import type { FC } from "react";
import PropTypes from "prop-types";
import clsx from "clsx";
import {
  Avatar,
  Box,
  Container,
  Grid,
  Typography,
  Card,
  CardContent,
} from "@material-ui/core";

// Icons
import {
  WebOutlined,
  PhoneAndroidOutlined,
  GradeOutlined,
  LinkOutlined,
} from "@material-ui/icons";

// Stles
import featuresStyles from "./FeaturesStyles";

interface IFeaturesProps {
  className?: string;
}

const Features: FC<IFeaturesProps> = ({ className, ...rest }) => {
  const classes = featuresStyles();

  return (
    <div className={clsx(classes.root, className)} {...rest}>
      <Container maxWidth="lg">
        <Typography variant="h1" align="center" color="textPrimary">
          Our Speciality
        </Typography>
        <Box mt={8}>
          <Grid container spacing={3}>
            <Grid item md={6} sm={6} xs={12}>
              <Card className={classes.card} variant="outlined">
                <CardContent>
                  <Box display="flex">
                    <Avatar className={classes.avatar}>
                      <WebOutlined />
                    </Avatar>
                    <Box ml={2}>
                      <Typography variant="h4" gutterBottom color="textPrimary">
                        Web
                      </Typography>
                      <Typography variant="body1" color="textPrimary">
                        We develop beautify,secure and stable web applications
                        to support your day to day needs.
                      </Typography>
                    </Box>
                  </Box>
                </CardContent>
              </Card>
            </Grid>
            <Grid item md={6} sm={6} xs={12}>
              <Card className={classes.card} variant="outlined">
                <CardContent>
                  <Box display="flex">
                    <Avatar className={classes.avatar}>
                      <PhoneAndroidOutlined />
                    </Avatar>
                    <Box ml={2}>
                      <Typography variant="h4" gutterBottom color="textPrimary">
                        Mobile Apps
                      </Typography>
                      <Typography variant="body1" color="textPrimary">
                        Get a mobile application for your business: Android and
                        IoS mobile apps.
                      </Typography>
                    </Box>
                  </Box>
                </CardContent>
              </Card>
            </Grid>
            <Grid item md={6} sm={6} xs={12}>
              <Card className={classes.card} variant="outlined">
                <CardContent>
                  <Box display="flex">
                    <Avatar className={classes.avatar}>
                      <GradeOutlined />
                    </Avatar>
                    <Box ml={2}>
                      <Typography variant="h4" gutterBottom color="textPrimary">
                        Quality Assurance
                      </Typography>
                      <Typography
                        variant="body1"
                        color="textPrimary"
                        gutterBottom
                      >
                        Quality Software gives you a peace of mind. We will help
                        you with Quality Assuarance while leveraging on test
                        automation.
                      </Typography>
                    </Box>
                  </Box>
                </CardContent>
              </Card>
            </Grid>
            <Grid item md={6} sm={6} xs={12}>
              <Card className={classes.card} variant="outlined">
                <CardContent>
                  <Box display="flex">
                    <Avatar className={classes.avatar}>
                      <LinkOutlined />
                    </Avatar>
                    <Box ml={2}>
                      <Typography variant="h4" gutterBottom color="textPrimary">
                        Systems Integration
                      </Typography>
                      <Typography
                        variant="body1"
                        color="textPrimary"
                        gutterBottom
                      >
                        We will help you with your integration needs - APIs,
                        Software Systems
                      </Typography>
                    </Box>
                  </Box>
                </CardContent>
              </Card>
            </Grid>
          </Grid>
        </Box>
      </Container>
    </div>
  );
};

Features.propTypes = {
  className: PropTypes.string,
};

export default Features;

import React, { useEffect } from "react";
import type { FC } from "react";
import { Link } from "react-router-dom";

// Material
import {
  Container,
  Grid,
  Typography,
  useMediaQuery,
  useTheme,
  Button,
  Box,
  experimentalStyled as styled,
} from "@material-ui/core";

// Hook form
import { useForm, SubmitHandler } from "react-hook-form";

// yup
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";

// Custom Components
import Page from "../../../components/Page";
import FormInputBox from "../../../components/Form/FormInputBox";

import { Theme } from "../../../theme";

import { PATHS } from "../../../routes/paths";

// contracts
import { ILoginPayload } from "../../../contracts/Auth";

// Styles
const PageStyled = styled(Page)(() => {
  const appTheme: Theme = useTheme();

  return {
    backgroundColor: appTheme.palette.background.default,
    paddingTop: 250,
    paddingBottom: 270,
    [appTheme.breakpoints.down("md")]: {
      paddingTop: 160,
      paddingBottom: 180,
    },
  };
});

const ContainerStyled = styled(Container)(() => {
  return {};
});

const TypographyMainLinkStyled = styled(Typography)(() => {
  const appTheme: Theme = useTheme();

  return {
    textAlign: "center",
    textDecoration: "none",
    paddingBottom: 30,
    "& a": {
      color: appTheme.palette.primary.main,
    },
  };
});

const FormDivStyled = styled("div")(() => {
  return {
    paddingTop: 10,
  };
});

const NavigateToRegisterDivStyled = styled("div")(() => {
  const appTheme: Theme = useTheme();
  return {
    "& a": {
      textDecoration: "none",
      paddingRight: 5,
      color: appTheme.palette.primary.main,
    },
  };
});

// Interfaces
interface ILoginProps {
  className?: string;
}

interface IFormInput extends ILoginPayload {}

const Login: FC<ILoginProps> = () => {
  const appTheme: Theme = useTheme();
  const isMobileDevice = useMediaQuery(appTheme.breakpoints.down("sm"));

  // Initialize form
  const FormFields = {
    defaultValues: {
      email: "",
      password: "",
    },
    resolver: yupResolver(
      yup.object().shape({
        email: yup
          .string()
          .email("Must be a valid email")
          .max(255, "Email can not exceed 255 characters")
          .required("Email is required"),
        password: yup.string().required("Password is required"),
      })
    ),
  };
  // use React hook form
  const { control, handleSubmit } = useForm<IFormInput>({
    ...FormFields,
    ...{ mode: "all" },
  });

  // Handle form submit
  const onSubmit: SubmitHandler<IFormInput> = (values: IFormInput) => {
    // eslint-disable-next-line no-console
    console.log(values);
  };

  return (
    <PageStyled title="Login">
      <ContainerStyled maxWidth="lg" disableGutters>
        <Grid
          container
          spacing={3}
          direction="row"
          justifyContent="center"
          alignItems="center"
        >
          <Grid item md={6} sm={8} xs={10}>
            <TypographyMainLinkStyled variant="h3">
              <Link to="/"> plus254</Link>
            </TypographyMainLinkStyled>
            <Typography
              variant={isMobileDevice ? "h6" : "h5"}
              align="left"
              color="textPrimary"
            >
              Welcome Back
            </Typography>

            <FormDivStyled>
              <form onSubmit={handleSubmit(onSubmit)}>
                <FormInputBox
                  control={control}
                  name="email"
                  label="Your Email Address"
                  margin="normal"
                  type="email"
                  fullWidth
                />

                <FormInputBox
                  control={control}
                  name="password"
                  label="Your Secret Password"
                  margin="normal"
                  type="password"
                  fullWidth
                />

                <Box mt={2}>
                  <Grid
                    container
                    direction="row"
                    justifyContent="flex-start"
                    alignItems="flex-end"
                  >
                    <Grid item xs={6}>
                      <Button
                        color="secondary"
                        size="large"
                        type="submit"
                        variant="contained"
                      >
                        Login
                      </Button>
                    </Grid>
                    <Grid item xs={6}>
                      <Grid
                        container
                        direction="row"
                        justifyContent="flex-end"
                        alignItems="flex-end"
                      >
                        <NavigateToRegisterDivStyled>
                          <Typography
                            component={Link}
                            to={PATHS.REGISTER}
                            variant="h6"
                          >
                            Not registered yet?
                          </Typography>
                        </NavigateToRegisterDivStyled>
                      </Grid>
                    </Grid>
                  </Grid>
                </Box>
              </form>
            </FormDivStyled>
          </Grid>
        </Grid>
      </ContainerStyled>
    </PageStyled>
  );
};

export default Login;

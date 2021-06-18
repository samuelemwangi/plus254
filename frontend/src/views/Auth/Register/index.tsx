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
import { IRegisterPayload } from "../../../contracts/Auth";

// Styles
const PageStyled = styled(Page)(() => {
  const appTheme: Theme = useTheme();

  return {
    backgroundColor: appTheme.palette.background.default,
    paddingTop: 200,
    paddingBottom: 160,
    [appTheme.breakpoints.down("md")]: {
      paddingTop: 100,
      paddingBottom: 100,
    },
  };
});

const ContainerStyled = styled(Container)(() => {
  return {};
});

const FormDivStyled = styled("div")(() => {
  return {
    paddingTop: 40,
  };
});

const NavigateToLoginDivStyled = styled("div")(() => {
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
interface IRegisterProps {
  className?: string;
}

interface IFormInput extends IRegisterPayload {}

const Register: FC<IRegisterProps> = () => {
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
    <PageStyled title="Register">
      <ContainerStyled maxWidth="lg" disableGutters>
        <Grid
          container
          spacing={3}
          direction="row"
          justifyContent="center"
          alignItems="center"
        >
          <Grid item md={6} sm={8} xs={10}>
            <Typography
              variant={isMobileDevice ? "h5" : "h4"}
              align="left"
              color="textPrimary"
            >
              Welcome to plus254
            </Typography>

            <FormDivStyled>
              <form onSubmit={handleSubmit(onSubmit)}>
                <FormInputBox
                  control={control}
                  name="fullName"
                  label="Full Name"
                  margin="normal"
                  type="text"
                  fullWidth
                />

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

                <FormInputBox
                  control={control}
                  name="confirmPassword"
                  label="Confirm Secret Password"
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
                        Submit
                      </Button>
                    </Grid>
                    <Grid item xs={6}>
                      <Grid
                        container
                        direction="row"
                        justifyContent="flex-end"
                        alignItems="flex-end"
                      >
                        <NavigateToLoginDivStyled>
                          <Typography
                            component={Link}
                            to={PATHS.LOGIN}
                            variant="h6"
                          >
                            Already registered?
                          </Typography>
                        </NavigateToLoginDivStyled>
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

export default Register;

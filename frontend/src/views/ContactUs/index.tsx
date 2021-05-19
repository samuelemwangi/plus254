import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { useForm, SubmitHandler } from "react-hook-form";
import type { FC } from "react";
import {
  Box,
  Container,
  Grid,
  Typography,
  FormHelperText,
  Button,
} from "@material-ui/core";

import clsx from "clsx";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";

// Components
import Page from "../../components/Page";
import Footer from "../Home/Footer";
import FormInputBox from "../../components/Form/FormInputBox";

// Actions & Store
import { IContactUsPayload } from "../../contracts/ContactUs";
import { clearContactUs, contactUsUpdate } from "../../actions/ContactUs";
import { AppState } from "../../reducers";

// styles
import useStyles from "./ContactUsStyles";

// Interfaces
interface IContactUsProps {
  className?: string;
}
interface IFormInput extends IContactUsPayload {}

const ContactUs: FC<IContactUsProps> = ({ className }) => {
  const classes = useStyles();

  // Connect to redux
  const dispatch = useDispatch();
  const contactUsState: any = useSelector(
    (state: AppState) => state.contactUsState
  );

  useEffect(() => {
    return () => {
      dispatch(clearContactUs());
    };
  }, []);

  // Initialize form
  const FormFields = {
    defaultValues: {
      name: "",
      email: "",
      mobile: "",
      desc: "",
    },
    resolver: yupResolver(
      yup.object().shape({
        email: yup
          .string()
          .email("Must be a valid email")
          .max(255, "Email can not exceed 255 characters")
          .required("Email is required"),
        name: yup
          .string()
          .min(2, "Name should be longer than 2 characters")
          .max(50, "Name can not exceed 255 characters")
          .required("Name is required"),
        desc: yup
          .string()
          .min(10, "Description should be longer than 10 characters")
          .max(255, "Description can not exceed 255 characters")
          .required("Description is required"),
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
    dispatch(contactUsUpdate(values));
  };

  const resetForm = () => {
    // eslint-disable-next-line no-console
    console.log("Hello");
  };

  // Expect props to be returned
  const updateSuccessful = contactUsState && contactUsState.data;
  const formSubmitting = contactUsState && contactUsState.loading;

  // Decide whether to show error
  const formHelperProps = {
    className: classes.formHelperResult,
    error: updateSuccessful ? false : true,
  };

  const classNames = clsx({
    [classes.buttonProgress]: formSubmitting,
  });

  return (
    <Page className={clsx(classes.root, className)} title="Hire Us">
      <Container maxWidth="lg" className={classes.contactUsWrapper}>
        <Box mt={8}>
          <Grid container spacing={3}>
            <Grid item md={8} sm={8} xs={10}>
              <Typography variant="h2" align="left" color="textPrimary">
                Hire Us
              </Typography>
            </Grid>
            <Grid item md={8} sm={8} xs={10} className={classes.formWrapper}>
              <form onSubmit={handleSubmit(onSubmit)}>
                <FormInputBox
                  control={control}
                  name="name"
                  label="Your Name"
                  margin="normal"
                  type="text"
                  fullWidth
                />
                <FormInputBox
                  control={control}
                  name="email"
                  label="Email Address"
                  margin="normal"
                  type="email"
                  fullWidth
                />

                <FormInputBox
                  control={control}
                  label="Mobile Number"
                  margin="normal"
                  name="mobile"
                  type="text"
                  fullWidth
                />

                <FormInputBox
                  control={control}
                  label="How can we help you?"
                  margin="normal"
                  name="desc"
                  type="text"
                  fullWidth
                  multiline
                  rows={4}
                />

                <Box mt={3}>
                  <FormHelperText
                    {...formHelperProps}
                    onLoad={() => resetForm()}
                  >
                    {updateSuccessful
                      ? contactUsState.data
                      : contactUsState.error}
                  </FormHelperText>
                </Box>
                <Box mt={2}>
                  <Button
                    color="secondary"
                    disabled={formSubmitting}
                    size="large"
                    type="submit"
                    variant="outlined"
                    className={classNames}
                  >
                    Submit
                  </Button>
                </Box>
              </form>
            </Grid>
          </Grid>
        </Box>
      </Container>
      <Footer />
    </Page>
  );
};

export default ContactUs;

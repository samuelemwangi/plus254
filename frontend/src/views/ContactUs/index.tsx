import React, { useEffect } from "react";
import type { FC } from "react";

// Redux
import { useSelector, useDispatch } from "react-redux";

// Material
import {
  Box,
  Container,
  Grid,
  Typography,
  FormHelperText,
  experimentalStyled as styled,
  useTheme,
} from "@material-ui/core";
import { LoadingButton } from "@material-ui/lab";

// React Hook Form
import { useForm, SubmitHandler } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";

// Components
import Page from "../../components/Page";
import FormInputBox from "../../components/Form/FormInputBox";
import { varFadeInUp, MotionInView } from "../../components/Animate";

// Actions & Store
import { IContactUsPayload } from "../../contracts/ContactUs";
import { clearContactUs, contactUsUpdate } from "../../actions/ContactUs";
import { AppState } from "../../reducers";

// Theme
import { Theme } from "../../theme";

//Styles
const PageStyle = styled(Page)(() => {
  const appTheme: Theme = useTheme();

  return {
    backgroundColor: appTheme.palette.background.default,
    paddingTop: 155,
    paddingBottom: 155,
    paddingLeft: 10,
    [appTheme.breakpoints.down("md")]: {
      paddingTop: 80,
      paddingBottom: 60,
      paddingLeft: 5,
    },
  };
});

const FormWrapperStyle = styled("div")(() => ({
  "& form": {
    paddingLeft: 0,
    paddingRight: 5,
  },
}));

const ContactUsImageStyle = styled("div")(() => ({
  perspectiveOrigin: "left center",
  transformStyle: "preserve-3d",
  perspective: 1500,
  "& > img": {
    maxWidth: "100%",
    height: "auto",
    padding: 20,
    transform: "rotateY(-35deg) rotateX(15deg)",
    backfaceVisibility: "hidden",
  },
}));

// Interfaces
interface IContactUsProps {
  className?: string;
}

interface IFormInput extends IContactUsPayload {}

const ContactUs: FC<IContactUsProps> = () => {
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
    error: updateSuccessful ? false : true,
  };

  return (
    <>
      <PageStyle title="Contact Us">
        <Container maxWidth="lg">
          <Grid container spacing={3}>
            <Grid item xs={12} md={7}>
              <Typography variant="h3" align="left" color="primary">
                Contact Us
              </Typography>
              <FormWrapperStyle>
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
                    <LoadingButton
                      color="secondary"
                      disabled={formSubmitting}
                      loading={formSubmitting}
                      size="large"
                      type="submit"
                      variant="outlined"
                    >
                      Submit
                    </LoadingButton>
                  </Box>
                </form>
              </FormWrapperStyle>
            </Grid>
            <Grid item xs={12} md={5}>
              <Box position="relative">
                <ContactUsImageStyle>
                  <MotionInView variants={varFadeInUp}>
                    <Box
                      component="img"
                      alt="Contact us"
                      src="/static/contact-us/contact-us.svg"
                      sx={{ m: "auto" }}
                    />
                  </MotionInView>
                </ContactUsImageStyle>
              </Box>
            </Grid>
          </Grid>
        </Container>
      </PageStyle>
    </>
  );
};

export default ContactUs;

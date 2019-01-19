import React from "react";
import { Field } from "redux-form";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import CardContent from "@material-ui/core/CardContent";
import Grid from "@material-ui/core/Grid";
import InputAdornment from "@material-ui/core/InputAdornment";
import withStyles from "@material-ui/core/styles/withStyles";
import Email from "@material-ui/icons/Email";
import Link from "react-router-dom/Link";

// Custom Components
import SubHeader from "../General/SubHeader";
import GridContainer from "../General/GridContainer";
import FormCheckBox from "../General/Form/FormCheckBox";
import FormInputBox from "../General/Form/FormInputBox";

import { required } from "../General/Form/Helpers";

// Style
import { authStyle } from "./AuthStyle";

const SignUp = ({ ...signUpProps }) => {
  const { classes, handleFormSubmit } = signUpProps;

  return (
    <React.Fragment>
      <SubHeader className={classes.authSubHeaderWrapper}>
        <div />
      </SubHeader>
      <GridContainer>
        <Grid item md={6} xs={12} sm={12}>
          <Card>
            <CardHeader title="Sign Up" className={classes.authCardHeader} />
            <CardContent className={classes.authCardContent}>
              <form onSubmit={handleFormSubmit}>
                <div className={classes.authFormGroup}>
                  <span className={classes.authHouseCheckBox}>
                    <Field name="readTerms" component={FormCheckBox} label="" />
                  </span>
                  <span className={classes.authCheckboxLabel}>
                    I have read and understood the{" "}
                    <Link to="/"> terms and conditions </Link>
                  </span>
                </div>
                <div className={classes.authFormGroup}>
                  <Field
                    name="email_address"
                    type="email"
                    component={FormInputBox}
                    label="Email Address"
                    InputProps={{
                      startAdornment: (
                        <InputAdornment position="start">
                          <Email />
                        </InputAdornment>
                      )
                    }}
                    validate={[required]}
                  />
                </div>
              </form>
            </CardContent>
          </Card>
        </Grid>
      </GridContainer>
    </React.Fragment>
  );
};

export default withStyles(authStyle)(SignUp);

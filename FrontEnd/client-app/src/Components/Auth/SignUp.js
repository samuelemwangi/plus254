import React from "react";
import { Field } from "redux-form";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import CardContent from "@material-ui/core/CardContent";
import Grid from "@material-ui/core/Grid";
import InputAdornment from "@material-ui/core/InputAdornment";
import withStyles from "@material-ui/core/styles/withStyles";
import Email from "@material-ui/icons/Email";
import FormControl from "@material-ui/core/FormControl";
import FormLabel from "@material-ui/core/FormLabel";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import Radio from "@material-ui/core/Radio";
import Button from "@material-ui/core/Button";
import Link from "react-router-dom/Link";

// Custom Components
import SubHeader from "../General/SubHeader";
import GridContainer from "../General/GridContainer";
import FormCheckBox from "../General/Form/FormCheckBox";
import FormInputBox from "../General/Form/FormInputBox";
import FormRadioGroup from "../General/Form/FormRadioGroup";

import { required } from "../General/Form/Helpers";

// Style
import { authStyle } from "./AuthStyle";

const countries = [
  {
    value: "",
    label: ""
  },
  {
    value: "1",
    label: "Kenya"
  },
  {
    value: "2",
    label: "Uganda"
  },
  {
    value: "3",
    label: "Tanzania"
  }
];

const SignUp = ({ ...signUpProps }) => {
  const {
    classes,
    pristine,
    invalid,
    submitting,
    handleFormSubmit,
    formIsDirty
  } = signUpProps;

  const selectOptions = countries.map(option => (
    <option key={option.value} value={option.value}>
      {option.label}
    </option>
  ));

  return (
    <React.Fragment>
      <SubHeader className={classes.authSubHeaderWrapper}>
        <div />
      </SubHeader>
      <GridContainer>
        <Grid item md={6} xs={12} sm={12}>
          <Card className={classes.authCard}>
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
                  <FormControl component="fieldset">
                    <Field
                      name="email_address"
                      type="email"
                      component={FormInputBox}
                      label="Email Address *"
                      InputProps={{
                        endAdornment: (
                          <InputAdornment position="end">
                            <Email />
                          </InputAdornment>
                        )
                      }}
                      validate={[required]}
                    />
                  </FormControl>
                </div>
                <div className={classes.authFormGroup}>
                  <FormControl component="fieldset">
                    <Field
                      name="countries"
                      select
                      component={FormInputBox}
                      value=""
                      label="Select Countries *"
                      SelectProps={{
                        native: true,
                        MenuProps: {
                          className: classes.menu
                        }
                      }}
                      selectOptions={selectOptions}
                      margin="normal"
                      validate={[required]}
                    />
                  </FormControl>
                </div>
                <div className={classes.authFormGroup}>
                  <FormControl component="fieldset">
                    <FormLabel component="legend">Gender *</FormLabel>
                    <Field
                      name="sex"
                      component={FormRadioGroup}
                      row
                      className={classes.radioGroup}
                      validate={[required]}
                      formIsDirty={formIsDirty}
                    >
                      <FormControlLabel
                        value="female"
                        control={<Radio color="primary" />}
                        label="Female"
                        labelPlacement="end"
                      />
                      <FormControlLabel
                        value="male"
                        control={<Radio color="primary" />}
                        label="Male"
                        labelPlacement="end"
                      />
                      <FormControlLabel
                        value="other"
                        control={<Radio color="primary" />}
                        label="Other"
                        labelPlacement="end"
                      />
                    </Field>
                  </FormControl>
                </div>
                <div className={classes.authFormGroup}>
                  <FormControl component="fieldset">
                    <Field
                      name="describe_yourself"
                      type="text"
                      multiline
                      rows={4}
                      component={FormInputBox}
                      label="Describe Youself *"
                      validate={[required]}
                    />
                  </FormControl>
                </div>
                <div className={classes.authFormGroup}>
                  <Button
                    variant="outlined"
                    size="large"
                    color="primary"
                    disabled={pristine || submitting || invalid}
                    type="submit"
                    className={classes.margin}
                  >
                    Submit
                  </Button>
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

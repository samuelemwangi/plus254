import React from "react";
import FormHelperText from "@material-ui/core/FormHelperText";
import RadioGroup from "@material-ui/core/RadioGroup";
import withStyles from "@material-ui/core/styles/withStyles";

// Style
import { formRadioGroupStyle } from "./FormRadioGroupStyle";

const FormRadioGroup = ({ ...formRadioGroupProps }) => {
  const {
    classes,
    input,
    meta: { error },
    formIsDirty,
    className,
    ...rest
  } = formRadioGroupProps;

  return (
    <React.Fragment>
      <RadioGroup
        {...input}
        {...rest}
        className={`${className} ${formIsDirty && error && classes.error}`}
      />
      {formIsDirty && error && (
        <FormHelperText className={classes.helperTextError}>
          {error}
        </FormHelperText>
      )}
    </React.Fragment>
  );
};

export default withStyles(formRadioGroupStyle)(FormRadioGroup);

import React from "react";
import classNames from "classnames";
import TextField from "@material-ui/core/TextField";
import withStyles from "@material-ui/core/styles/withStyles";

// Style
import { formInputBoxStyle } from "./FormInputBoxStyle";

const FormInputBox = ({ ...formInputBoxProps }) => {
  const {
    input,
    label,
    meta: { touched, error },
    classes,
    selectOptions,
    ...custom
  } = formInputBoxProps;

  return (
    <TextField
      error={touched && error !== undefined}
      variant="outlined"
      helperText={touched && error}
      label={label}
      className={classNames(classes.margin, classes.textField)}
      {...input}
      {...custom}
    >
      {selectOptions !== undefined && selectOptions}
    </TextField>
  );
};

export default withStyles(formInputBoxStyle)(FormInputBox);

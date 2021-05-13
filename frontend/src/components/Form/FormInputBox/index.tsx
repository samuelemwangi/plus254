import React from "react";
import type { FC } from "react";
import { TextField } from "@material-ui/core";
import { useController } from "react-hook-form";

// Styles
import useStyles from "./FormInputBoxStyles";

interface IFormInputBoxProps {
  [key: string]: any;
}

const FormInputBox: FC<IFormInputBoxProps> = ({
  control,
  name,
  rules,
  defaultValue,
  label,
  ...rest
}) => {
  const classes = useStyles();
  const {
    field: { ref, ...inputProps },
    fieldState: { isTouched, error },
  } = useController({
    name,
    control,
    rules,
    defaultValue,
  });

  return (
    <TextField
      error={isTouched && error !== undefined}
      helperText={isTouched && error?.message}
      className={classes.textField}
      variant="outlined"
      label={label}
      {...rules}
      {...inputProps}
      {...rest}
      inputRef={ref}
    />
  );
};

export default FormInputBox;

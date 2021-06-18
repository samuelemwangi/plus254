import React from "react";
import type { FC } from "react";

// Material
import {
  TextField,
  experimentalStyled as styled,
  useTheme,
} from "@material-ui/core";

// React hook form
import { useController } from "react-hook-form";

// Theme

import { Theme } from "../../../theme";

// Interfaces
interface IFormInputBoxProps {
  [key: string]: any;
}

// Styles
const TextFieldStyle = styled(TextField)(() => {
  const appTheme: Theme = useTheme();

  return {
    "& label.Mui-focused": {
      color: appTheme.palette.text.secondary,
    },

    // input
    "& input:valid + fieldset": {
      borderColor: appTheme.palette.mode === "dark" ? "#ffffff1f" : "#0000003b",
    },
    "& input:invalid + fieldset": {},
    "& input:valid:focus + fieldset": {
      borderColor: appTheme.palette.text.secondary,
    },

    // textarea
    "& textarea:valid + fieldset": {
      borderColor: appTheme.palette.mode === "dark" ? "#ffffff1f" : "#0000003b",
    },
    "& textarea:invalid + fieldset": {},
    "& textarea:valid:focus + fieldset": {
      borderColor: appTheme.palette.text.secondary,
    },
  };
});

// Main component
const FormInputBox: FC<IFormInputBoxProps> = ({
  control,
  name,
  rules,
  defaultValue,
  label,
  ...rest
}) => {
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
    <TextFieldStyle
      error={isTouched && error !== undefined}
      helperText={isTouched && error && error.message}
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

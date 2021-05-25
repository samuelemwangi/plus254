import React from "react";
import type { FC } from "react";

// Material
import { TextField, experimentalStyled as styled } from "@material-ui/core";

// React hook form
import { useController } from "react-hook-form";

// Interfaces
interface IFormInputBoxProps {
  [key: string]: any;
}

// Styles
const TextFieldStyle = styled(TextField)(() => ({}));

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

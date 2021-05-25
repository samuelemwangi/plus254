/* eslint-disable no-undef */
// Define Validation  rules
type formValueType = string | undefined;
type returnValueType = string | undefined;
interface formValuesType {
  [key: string]: formValueType;
}
interface formFileType {
  [key: string]: any;
}

export const required = (value: formValueType): returnValueType =>
  value ? undefined : "Required";

export const minLength =
  (min: Number) =>
  (value: formValueType): returnValueType =>
    value && value.length < min
      ? `Must be ${min} characters or more`
      : undefined;

export const maxLength =
  (max: Number) =>
  (value: formValueType): returnValueType =>
    value && value.length > max
      ? `Must be ${max} characters or less`
      : undefined;

export const alphaNumeric = (value: formValueType): returnValueType =>
  value && !/^[A-Z0-9 ]+$/i.test(value) ? "Alphanumeric required" : undefined;

export const passwordsMatch = (
  value: formValueType,
  allValues: formValuesType
): returnValueType =>
  value !== allValues.userPassWord ? "Passwords don't match" : undefined;

export const resetPasswordsMatch = (
  value: formValueType,
  allValues: formValuesType
): returnValueType =>
  value !== allValues.newpassWord ? "Passwords don't match" : undefined;

// These might use the above functions
export const maxLength25 = maxLength(25);
export const maxLength250 = maxLength(250);
export const maxLength80 = maxLength(80);
export const minLength5 = minLength(5);

// Valid Phone
export const validPhoneNumber = (value: formValueType) =>
  value && !/^[+]?[0-9]+$/i.test(value)
    ? "A valid telephone number has at most one + character  followed by any number of digits"
    : undefined;

// Valid Email
export const validEmail = (value: formValueType): returnValueType =>
  value && !/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(value)
    ? "Should  be a valid Email e.g. someone@example.com"
    : undefined;

// Validate XSS
export const validateXSS = (value: string): returnValueType => {
  const div = document.createElement("div");
  div.innerHTML = value;
  const scripts = div.getElementsByTagName("script");
  return scripts.length > 0 ? "Script tags are not allowed" : undefined;
};

// Validate Date Input
export const validateDateInput = (value: string): returnValueType =>
  value.toString().includes("NaN") ? "Should be a valid date" : undefined;

// Validate Date Input
export const validateInteger = (value: formValueType): returnValueType =>
  value && !/^[0-9]+$/i.test(value) ? "Should be an Integer" : undefined;

// File
export const fileRequired = (value: formValueType): returnValueType => {
  return value ? undefined : "alskdsk";
};

// Select
export const selectRequired = (value: formValueType | null | []) => {
  return value === undefined || value === [] || value === null
    ? "Required"
    : undefined;
};

// File type
export const validateFileType = (
  file: formFileType,
  targetFile: formFileType
): returnValueType =>
  file.type === "" ||
  file.type === undefined ||
  (file && !targetFile.type.includes(file.type))
    ? targetFile.errorMessage
    : undefined;
// File Size
export const validateFileSize = (
  file: formFileType,
  targetMBFileSize: Number
): returnValueType =>
  file && file.size / 1024 / 1024 > targetMBFileSize
    ? `Must be ${targetMBFileSize} Mbs or less`
    : undefined;

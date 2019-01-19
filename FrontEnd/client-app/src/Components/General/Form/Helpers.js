// Define Validation  rules
export const required = value => (value ? undefined : "Required");
export const minLength = min => value =>
  value && value.length < min ? `Must be ${min} characters or more` : undefined;
export const maxLength = max => value =>
  value && value.length > max ? `Must be ${max} characters or less` : undefined;
export const alphaNumeric = value =>
  value && !/^[A-Z0-9 ]+$/i.test(value) ? "Alphanumeric required" : undefined;

// These might use the above functions
export const maxLength25 = maxLength(25);
export const maxLength250 = maxLength(250);
export const maxLength80 = maxLength(80);
export const minLength5 = minLength(5);

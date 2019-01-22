export const formInputBoxStyle = {
  root: {
    display: "flex",
    flexWrap: "wrap"
  },
  textField: {
    flexBasis: "auto",
    width: "100%",
    "& div fieldset": {
      borderWidth: "1px",
      borderRadius: "4px"
    },
    "& input": {
      paddingTop: "15px",
      paddingBottom: "15px"
    }
  }
};

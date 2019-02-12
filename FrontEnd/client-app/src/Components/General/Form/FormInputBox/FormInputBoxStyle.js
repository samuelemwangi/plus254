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
    "& label": {
      transform: "translate(14px, 18px) scale(1)",
      fontSize: "14px"
    },
    "& input": {
      paddingTop: "15px",
      paddingBottom: "15px",
      height: "18px",
      fontSize: "14px"
    },
    "& select": {
      paddingTop: "15px",
      paddingBottom: "15px",
      height: "18px",
      fontSize: "14px"
    },
    "& textarea": {
      fontSize: "14px"
    }
  }
};

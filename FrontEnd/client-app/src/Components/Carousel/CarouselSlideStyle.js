export const carouselSlideStyle = {
  slides: {
    maxWidth: "400px",
    margin: "0 auto 30px",

    position: "relative",
    "&:before": {
      display: "block",
      content: "",
      width: "100%",
      paddingTop: "(1 / 1) * 100%"
    },

    "& li": {
      padding: "0px",
      width: "100%",
      height: "100%",
      position: "absolute",
      top: "0",
      opacity: "0",
      transform: "scale(.98)",
      transition: "all 1s",
      listStyleType: "none",
      "&.is-active": {
        borderColor: "#999999",
        opacity: "1",
        transform: "scale(1)",
        transition: "all 1s"
      }
    }
  }
};

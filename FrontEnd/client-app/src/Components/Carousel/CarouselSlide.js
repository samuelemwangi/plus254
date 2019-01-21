import React from "react";
import withStyles from "@material-ui/core/styles/withStyles";

// Styles
import { carouselSlideStyle } from "./CarouselSlideStyle";

const CarouselSlide = ({ ...carouselSlideProps }) => {
  const { classes, images, isActiveSlide } = carouselSlideProps;

  const imageList = images.map(image => (
    <li
      key={`${image.id}slider`}
      className={`${isActiveSlide(image.id) && "is-active"}`}
    >
      <img src={image.url} alt={`${image.id}slider`} width="200px" />
    </li>
  ));

  return <ul className={classes.slides}>{imageList}</ul>;
};

export default withStyles(carouselSlideStyle)(CarouselSlide);

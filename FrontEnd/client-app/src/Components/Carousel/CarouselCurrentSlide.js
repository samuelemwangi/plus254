import React from "react";
import Magnifier from "react-magnifier";
import withStyles from "@material-ui/core/styles/withStyles";

// Styles
import { carouselCurrentSlideStyle } from "./CarouselCurrentSlideStyle";

const CarouselCurrentSlide = ({ ...carouselSlideProps }) => {
  const { classes, image } = carouselSlideProps;

  const currentImage = image && image.id !== undefined && (
    <div key={`${image.id}slider`}>
      <Magnifier src={image.url} width="100%" mgShowOverflow={false} />
    </div>
  );

  return <div className={classes.slides}>{currentImage}</div>;
};

export default withStyles(carouselCurrentSlideStyle)(CarouselCurrentSlide);

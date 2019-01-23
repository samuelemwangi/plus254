import React from "react";
import withStyles from "@material-ui/core/styles/withStyles";

// style
import { carouselControlStyle } from "./CarouselControlStyle";

const CarouselControl = ({ ...carouselControlProps }) => {
  const {
    classes,
    isLeftDisabled,
    isRightDisabled,
    slidePrev,
    slideNext,
    controlWidth,
    controlOffset,
    images,
    isActiveSlide,
    slideChange
  } = carouselControlProps;

  const style = {
    width: controlWidth,
    transform: `translateX(${controlOffset}px)`,
    WebkitTransition: "transform .25s ease-in-out"
  };

  const sliderimages = images.map(imageElement => (
    <li
      key={`slide-${imageElement.id}`}
      className={`${isActiveSlide(imageElement.id) && classes.isActive}`}
    >
      <button onClick={e => slideChange(imageElement.id, e)} type="button">
        <img
          src={imageElement.url}
          alt={`${imageElement.id}slide`}
          width="100%"
          height="100%"
        />
      </button>
    </li>
  ));

  return (
    <div className={classes.slideControl}>
      {images.length > 1 && (
        <button
          className={`${classes.btn} ${isLeftDisabled && classes.btnDisabled}`}
          onClick={() => slidePrev()}
          disabled={isLeftDisabled}
          type="button"
        >
          ‹
        </button>
      )}

      <div className={classes.controlsWrapper}>
        <ul className={classes.controls} style={style}>
          {sliderimages}
        </ul>
      </div>
      {images.length > 1 && (
        <button
          className={`${classes.btn} ${isRightDisabled && classes.btnDisabled}`}
          onClick={() => slideNext()}
          disabled={isRightDisabled}
          type="button"
        >
          ›
        </button>
      )}
    </div>
  );
};

export default withStyles(carouselControlStyle)(CarouselControl);

import React, { Component } from "react";
import PropTypes from "prop-types";

// Custom Componets
import CarouselSlide from "../../Components/Carousel/CarouselSlide";

class CarouselSlideContainer extends Component {
  constructor() {
    super();
    this.isActiveSlide = this.isActiveSlide.bind(this);
  }

  isActiveSlide = index => {
    const { currentSlide } = this.props;

    return index === currentSlide;
  };

  render() {
    const { images } = this.props;
    return <CarouselSlide images={images} isActiveSlide={this.isActiveSlide} />;
  }
}

CarouselSlideContainer.propTypes = {
  images: PropTypes.array.isRequired,
  currentSlide: PropTypes.number.isRequired
};

export default CarouselSlideContainer;

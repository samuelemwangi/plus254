import React, { Component } from "react";
import PropTypes from "prop-types";

// Custom Components

import CarouselControlContainer from "./CarouselControlContainer";

import CarouselCurrentSlide from "../../Components/Carousel/CarouselCurrentSlide";

class CarouselContainer extends Component {
  constructor() {
    super();

    this.state = {
      currentSlide: 0,
      isLeftDisabled: true,
      isRightDisabled: false
    };
    this.slideChange = this.slideChange.bind(this);
  }

  componentDidMount() {}

  slideChange = newCurrentSlide => {
    const { images } = this.props;
    const isLeftDisabled = newCurrentSlide === 0;
    const isRightDisabled = newCurrentSlide === images.length - 1;
    this.setState({
      isLeftDisabled,
      isRightDisabled,
      currentSlide: newCurrentSlide
    });
  };

  render() {
    const { images } = this.props;

    const { currentSlide, isLeftDisabled, isRightDisabled } = this.state;

    return (
      <React.Fragment>
        <CarouselCurrentSlide image={images[currentSlide]} />
        <CarouselControlContainer
          handleSlideChange={this.slideChange}
          images={images}
          totalSlides={images.length}
          currentSlide={currentSlide}
          isLeftDisabled={isLeftDisabled}
          isRightDisabled={isRightDisabled}
        />
      </React.Fragment>
    );
  }
}
CarouselContainer.propTypes = {
  images: PropTypes.array.isRequired
};

export default CarouselContainer;

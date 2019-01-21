import React, { Component } from "react";
import PropTypes from "prop-types";

// Custom Components
import CarouselSlideContainer from "./CarouselSlideContainer";
import CarouselControlContainer from "./CarouselControlContainer";

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
      <div style={{ paddingTop: "10%", textAlign: "center" }}>
        <CarouselSlideContainer currentSlide={currentSlide} images={images} />
        <CarouselControlContainer
          handleSlideChange={this.slideChange}
          images={images}
          totalSlides={images.length}
          currentSlide={currentSlide}
          isLeftDisabled={isLeftDisabled}
          isRightDisabled={isRightDisabled}
        />
      </div>
    );
  }
}
CarouselContainer.propTypes = {
  images: PropTypes.array
};

CarouselContainer.defaultProps = {
  images: [
    {
      id: 0,
      url: "http://react-compare-app.surge.sh/images/Cherry.png"
    },
    {
      id: 1,
      url: "http://react-compare-app.surge.sh/images/Nuts.png"
    },
    {
      id: 2,
      url: "http://react-compare-app.surge.sh/images/Orange.png"
    },
    {
      id: 3,
      url: "http://react-compare-app.surge.sh/images/Strawberry.png"
    },
    {
      id: 4,
      url: "http://react-compare-app.surge.sh/images/Orange.png"
    }
  ]
};
export default CarouselContainer;

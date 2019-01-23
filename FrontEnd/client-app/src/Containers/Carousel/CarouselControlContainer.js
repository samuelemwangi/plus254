import React, { Component } from "react";
import PropTypes from "prop-types";

// Custom Components
import CarouselControl from "../../Components/Carousel/CarouselControl";

class CarouselControlContainer extends Component {
  constructor() {
    super();
    this.state = {
      controlWidth: "",
      controlOffset: 0
    };

    this.thumbWidth = this.thumbWidth.bind(this);
    this.getControlOffset = this.getControlOffset.bind(this);
    this.isActiveSlide = this.isActiveSlide.bind(this);
    this.slideChange = this.slideChange.bind(this);
    this.slideNext = this.slideNext.bind(this);
    this.slidePrev = this.slidePrev.bind(this);
  }

  thumbWidth = () => 90;

  componentDidUpdate = nextProps => {
    const { currentSlide } = this.props;

    const width = nextProps.totalSlides * this.thumbWidth();

    if (nextProps.currentSlide !== currentSlide) {
      this.setState({
        controlWidth: width
      });
    }
  };

  getControlOffset = index => {
    const { totalSlides } = this.props;
    const thumbWidth = this.thumbWidth();
    const offset = -(index * thumbWidth);
    const isSecondToFirst = index === -1;
    const isSecondToLast = index === totalSlides - 2;

    if (isSecondToFirst || isSecondToLast) {
      return false;
    }

    return offset;
  };

  isActiveSlide = index => {
    const { currentSlide } = this.props;
    return index === currentSlide;
  };

  slideNext = () => {
    const { currentSlide } = this.props;

    this.slideChange(currentSlide + 1);
  };

  slidePrev = () => {
    const { currentSlide } = this.props;

    this.slideChange(currentSlide - 1);
  };

  slideChange = index => {
    const { handleSlideChange } = this.props;

    handleSlideChange(index);

    this.setState({
      controlOffset: this.getControlOffset(index - 1)
    });
  };

  render() {
    const { controlOffset, controlWidth } = this.state;
    const { images, isLeftDisabled, isRightDisabled } = this.props;

    return (
      <CarouselControl
        isLeftDisabled={isLeftDisabled}
        isRightDisabled={isRightDisabled}
        slidePrev={this.slidePrev}
        slideNext={this.slideNext}
        controlWidth={controlWidth}
        controlOffset={controlOffset}
        images={images}
        isActiveSlide={this.isActiveSlide}
        slideChange={this.slideChange}
      />
    );
  }
}

CarouselControlContainer.propTypes = {
  currentSlide: PropTypes.number.isRequired,
  handleSlideChange: PropTypes.func.isRequired,
  totalSlides: PropTypes.number.isRequired,
  images: PropTypes.array.isRequired,
  isLeftDisabled: PropTypes.bool.isRequired,
  isRightDisabled: PropTypes.bool.isRequired
};

export default CarouselControlContainer;

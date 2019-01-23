import React, { Component } from "react";
import PropTypes from "prop-types";

// Custom Component
import CarouselControlContainer from "../Carousel";
import ProductDetail from "../../Components/Product";

// images
const image1 = require("../../Media/images/1.png");
const image2 = require("../../Media/images/2.png");
const image3 = require("../../Media/images/3.png");
const image4 = require("../../Media/images/4.png");

class ProductContainer extends Component {
  componentDidMount = () => {};

  render() {
    const { productImages } = this.props;

    const productImageComponent = (
      <CarouselControlContainer images={productImages} />
    );

    return <ProductDetail productImageComponent={productImageComponent} />;
  }
}

ProductContainer.propTypes = {
  productImages: PropTypes.array
};

ProductContainer.defaultProps = {
  productImages: [
    {
      id: 0,
      url: image1
    },
    {
      id: 1,
      url: image2
    },
    {
      id: 2,
      url: image3
    },
    {
      id: 3,
      url: image4
    }
  ]
};

export default ProductContainer;

import React, { Component } from "react";

// Custom Components
import ProductList from "../../Components/Product/ProductList";

class ProductListContainer extends Component {
  componentDidMount = () => {};

  render() {
    return <ProductList />;
  }
}

ProductListContainer.propTypes = {};

export default ProductListContainer;

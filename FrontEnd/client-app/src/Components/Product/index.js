import React from "react";
import Grid from "@material-ui/core/Grid";
import withStyles from "@material-ui/core/styles/withStyles";

// Custom Components
import { Typography } from "@material-ui/core";
import SubHeader from "../General/SubHeader";
import GridContainer from "../General/GridContainer";
import ProductSpecs from "./ProductSpecs";
import ProductItem from "./ProductItem";

// Custom Styles
import { productDetailStyle } from "./ProductDetailStyle";

const ProductDetail = ({ ...productDetailProps }) => {
  const { classes, productImageComponent } = productDetailProps;

  const productItems = [];

  for (let countItems = 0; countItems < 5; countItems++) {
    productItems.push(
      <Grid
        item
        md={3}
        sm={4}
        xs={6}
        key={countItems}
        className={classes.productItemWrapper}
      >
        <ProductItem />
      </Grid>
    );
  }

  return (
    <React.Fragment>
      <SubHeader>
        <div />
      </SubHeader>
      <GridContainer
        justify="flex-start"
        alignItems="flex-start"
        className={classes.productDetailwrapper}
      >
        <Grid
          item
          md={6}
          sm={6}
          xs={12}
          className={classes.productImageWrapper}
        >
          {productImageComponent}
        </Grid>
        <Grid item md={6} sm={6} xs={12}>
          <ProductSpecs />
        </Grid>
      </GridContainer>
      <GridContainer
        justify="flex-start"
        alignItems="flex-start"
        className={classes.productDetailwrapper}
      >
        <Typography variant="h5" className={classes.relatedProductsHeader}>
          Related Products
        </Typography>
        {productItems}
      </GridContainer>
    </React.Fragment>
  );
};

export default withStyles(productDetailStyle)(ProductDetail);

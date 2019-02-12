import React from "react";
import Grid from "@material-ui/core/Grid";
import withStyles from "@material-ui/core/styles/withStyles";

// Custom Components
import SubHeader from "../General/SubHeader";
import GridContainer from "../General/GridContainer";
import ProductItem from "./ProductItem";

// Styles
import { productListStyle } from "./ProductListStyle";

const ProductList = ({ ...productListProps }) => {
  const { classes } = productListProps;

  const productList = [];

  for (let itemscount = 0; itemscount < 10; itemscount++) {
    productList.push(
      <Grid
        item
        md={3}
        sm={2}
        xs={2}
        key={itemscount}
        className={classes.productListItemWrapper}
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
        className={classes.productListWrapper}
      >
        {productList}
      </GridContainer>
    </React.Fragment>
  );
};

export default withStyles(productListStyle)(ProductList);

import React from "react";
import Link from "react-router-dom/Link";
import Card from "@material-ui/core/Card";
import CardMedia from "@material-ui/core/CardMedia";
import CardContent from "@material-ui/core/CardContent";
import CardActions from "@material-ui/core/CardActions";
import Typography from "@material-ui/core/Typography";
import Star from "@material-ui/icons/Star";
import StarHalf from "@material-ui/icons/StarHalf";
import StarBorder from "@material-ui/icons/StarBorder";
import IconButton from "@material-ui/core/IconButton";
import ShareIcon from "@material-ui/icons/Share";
import withStyles from "@material-ui/core/styles/withStyles";

// CUstom Components
import { convertNumberToRating } from "../../Helpers/General";

// Styles
import { productItemStyle } from "./ProductItemStyle";

const productImage = require("../../Media/images/3.png");

const ProductItem = ({ ...productItemProps }) => {
  const { classes, productDetail, contentOptions } = productItemProps;

  const productRating = convertNumberToRating(productDetail.rating, {
    starFull: Star,
    starHalf: StarHalf,
    starEmpty: StarBorder
  });

  let productDescription =
    productDetail.descriptionMini !== undefined
      ? productDetail.descriptionMini.substring(
          1,
          contentOptions.descriptionLength
        )
      : "";

  productDescription =
    `${productDetail.descriptionMini}`.length > contentOptions.descriptionLength
      ? `${productDescription}....`
      : productDescription;

  return (
    <Card>
      <CardMedia
        component="img"
        title="Contemplative Reptile"
        image={productDetail.backgroundImages[0]}
        className={classes.detailImage}
      />
      <CardContent className={classes.detailBody}>
        <Typography
          component="h6"
          gutterBottom
          align="left"
          className={classes.productName}
        >
          <Link to="/product">{productDetail.name}</Link>
        </Typography>
        <Typography variant="caption" className={classes.detailDescription}>
          <Link to="/product">{productDescription}</Link>
        </Typography>
      </CardContent>
      <CardActions className={classes.cardActions}>
        <div className={classes.ratingWrapper}>
          {productRating}
          {contentOptions.showReviews && <span>{productDetail.reviews}</span>}
        </div>
        <IconButton
          aria-label="Share"
          className={classes.cardActionsFarLeftIcons}
        >
          <ShareIcon />
        </IconButton>
      </CardActions>
    </Card>
  );
};

ProductItem.defaultProps = {
  productDetail: {
    name: "Product A",
    reviews: "(3 Reviews)",
    descriptionMini:
      'If your using textarea or input there is a max length (maxlength="50" this is in' +
      " the HTML) property for them or you would have to use Javascript.",
    descriptionFull:
      'If your using textarea or input there is a max length (maxlength="50" this is in' +
      " the HTML) property for them or you would have to use Javascript.",
    rating: "2.4",
    backgroundImages: [productImage]
  },
  contentOptions: {
    descriptionLength: 100,
    selected: false,
    addedToCompare: false,
    showReviews: true
  }
};

export default withStyles(productItemStyle)(ProductItem);

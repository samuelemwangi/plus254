import React from "react";
import PropTypes from "prop-types";
import { withStyles } from "@material-ui/core/styles";
import ExpansionPanel from "@material-ui/core/ExpansionPanel";
import ExpansionPanelDetails from "@material-ui/core/ExpansionPanelDetails";
import ExpansionPanelSummary from "@material-ui/core/ExpansionPanelSummary";
import Typography from "@material-ui/core/Typography";
import ExpandMoreIcon from "@material-ui/icons/ExpandMore";
import CardActions from "@material-ui/core/CardActions";
import ShareIcon from "@material-ui/icons/Share";
import IconButton from "@material-ui/core/IconButton";
import Star from "@material-ui/icons/Star";
import StarHalf from "@material-ui/icons/StarHalf";
import StarBorder from "@material-ui/icons/StarBorder";

// CUstom Components
import { convertNumberToRating } from "../../Helpers/General";

// Styles
import { productSpecsStyle } from "./ProductSpecsStyle";

class ProductSpecs extends React.Component {
  state = {
    expanded: "panel1"
  };

  handleChange = panel => (event, expanded) => {
    this.setState({
      expanded: expanded ? panel : false
    });
  };

  render() {
    const { classes } = this.props;
    const { expanded } = this.state;

    const profileRating = convertNumberToRating(3.4, {
      starFull: Star,
      starHalf: StarHalf,
      starEmpty: StarBorder
    });

    return (
      <div className={classes.root}>
        <div className={classes.productHeader}>
          <Typography variant="h4" className={classes.productName}>
            Product Name
          </Typography>
          <Typography variant="caption" className={classes.productCaption}>
            Best in the show
          </Typography>
        </div>
        <div>
          <ExpansionPanel
            expanded={expanded === "panel1"}
            onChange={this.handleChange("panel1")}
            className={classes.expansionPanel}
          >
            <ExpansionPanelSummary
              expandIcon={<ExpandMoreIcon />}
              className={`${expanded === "panel1" && classes.isActivePanel}`}
            >
              <Typography className={classes.heading}>Description</Typography>
            </ExpansionPanelSummary>
            <ExpansionPanelDetails>
              <Typography>
                Nulla facilisi. Phasellus sollicitudin nulla et quam mattis
                feugiat. Aliquam eget maximus est, id dignissim quam.
              </Typography>
            </ExpansionPanelDetails>
          </ExpansionPanel>

          <ExpansionPanel
            expanded={expanded === "panel2"}
            onChange={this.handleChange("panel2")}
            className={classes.expansionPanel}
          >
            <ExpansionPanelSummary
              expandIcon={<ExpandMoreIcon />}
              className={`${expanded === "panel2" && classes.isActivePanel}`}
            >
              <Typography className={classes.heading}>
                Availability Details
              </Typography>
            </ExpansionPanelSummary>
            <ExpansionPanelDetails>
              <Typography>
                Donec placerat, lectus sed mattis semper, neque lectus feugiat
                lectus, varius pulvinar diam eros in elit. Pellentesque
                convallis laoreet laoreet.
              </Typography>
            </ExpansionPanelDetails>
          </ExpansionPanel>
          <ExpansionPanel
            expanded={expanded === "panel3"}
            onChange={this.handleChange("panel3")}
            className={classes.expansionPanel}
          >
            <ExpansionPanelSummary
              expandIcon={<ExpandMoreIcon />}
              className={`${expanded === "panel3" && classes.isActivePanel}`}
            >
              <Typography className={classes.heading}>
                Product Specification
              </Typography>
            </ExpansionPanelSummary>
            <ExpansionPanelDetails>
              <Typography>
                Nunc vitae orci ultricies, auctor nunc in, volutpat nisl.
                Integer sit amet egestas eros, vitae egestas augue. Duis vel est
                augue.
              </Typography>
            </ExpansionPanelDetails>
          </ExpansionPanel>
        </div>
        <div>
          <CardActions className={classes.cardActions}>
            <div>{profileRating}</div>
            <IconButton
              aria-label="Share"
              className={classes.cardActionsFarLeftIcons}
            >
              <ShareIcon />
            </IconButton>
          </CardActions>
        </div>
      </div>
    );
  }
}

ProductSpecs.propTypes = {
  classes: PropTypes.object.isRequired
};

export default withStyles(productSpecsStyle)(ProductSpecs);

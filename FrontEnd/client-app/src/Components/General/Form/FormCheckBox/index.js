import React, { Component } from "react";
import PropTypes from "prop-types";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import Checkbox from "@material-ui/core/Checkbox";
import withStyles from "@material-ui/core/styles/withStyles";
import Check from "@material-ui/icons/Check";

// Custom Components
import { formCheckBoxStyle } from "./FormCheckBoxStyle";

class FormCheckBox extends Component {
  constructor(props) {
    super(props);
    this.state = {
      checkedA: false
    };
  }

  handleChange = name => event => {
    this.setState({ [name]: event.target.checked });
  };

  render() {
    const { classes, label } = this.props;
    const checkIconComponent = <Check className={classes.checkedIcon} />;
    const unCheckIconComponent = <Check className={classes.uncheckedIcon} />;

    const { checkedA } = this.state;

    const checkBoxControl = (
      <Checkbox
        checked={checkedA}
        onChange={this.handleChange("checkedA")}
        checkedIcon={checkIconComponent}
        icon={unCheckIconComponent}
        classes={{ checked: classes.checked, root: classes.root }}
        value="checkedA"
        color="primary"
      />
    );

    return (
      <React.Fragment>
        <FormControlLabel
          control={checkBoxControl}
          classes={{ label: classes.label }}
          label={label}
          className={classes.formControl}
        />
      </React.Fragment>
    );
  }
}

FormCheckBox.propTypes = {
  classes: PropTypes.object.isRequired,
  label: PropTypes.string.isRequired
};

export default withStyles(formCheckBoxStyle)(FormCheckBox);

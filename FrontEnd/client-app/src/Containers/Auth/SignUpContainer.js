import React, { Component } from "react";
import PropTypes from "prop-types";
import { reduxForm } from "redux-form";
import { connect } from "react-redux";

// Custom Components
import SignUp from "../../Components/Auth/SignUp";

class SignUpContainer extends Component {
  constructor() {
    super();
    this.handleFormSubmit = this.handleFormSubmit.bind(this);
  }

  componentDidMount() {}

  handleFormSubmit(values) {
    console.log(values);
    console.log(this.props);
  }

  render() {
    const { handleSubmit, pristine, invalid, dirty, submitting } = this.props;

    return (
      <SignUp
        pristine={pristine}
        submitting={submitting}
        invalid={invalid}
        formIsDirty={dirty}
        handleFormSubmit={handleSubmit(this.handleFormSubmit)}
      />
    );
  }
}

SignUpContainer.propTypes = {
  handleSubmit: PropTypes.func.isRequired,
  pristine: PropTypes.bool.isRequired,
  submitting: PropTypes.bool.isRequired,
  invalid: PropTypes.bool.isRequired,
  dirty: PropTypes.bool.isRequired
};

const mapStateToProps = () => ({});

// Compose to redux form
const SignUpFormed = reduxForm({ form: "sign-in" })(SignUpContainer);

export default connect(mapStateToProps)(SignUpFormed);

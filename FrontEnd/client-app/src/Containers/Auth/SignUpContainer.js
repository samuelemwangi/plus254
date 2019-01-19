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

  handleFormSubmit() {
    console.log(this.props);
  }

  render() {
    const { handleSubmit } = this.props;

    return <SignUp handleFormSubmit={handleSubmit(this.handleFormSubmit)} />;
  }
}

SignUpContainer.propTypes = {
  handleSubmit: PropTypes.func.isRequired
};

const mapStateToProps = () => ({});

// Compose to redux form
const SignUpFormed = reduxForm({ form: "sign-in" })(SignUpContainer);

export default connect(mapStateToProps)(SignUpFormed);

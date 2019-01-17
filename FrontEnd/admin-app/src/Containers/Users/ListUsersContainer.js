import React, { Component } from "react";
// import PropTypes from "prop-types";

// Custom Components
import ListUsers from "../../Components/Users/ListUsers";

class ListUsersContainer extends Component {
  componentDidMount() {}

  render() {
    return (
      <div>
        <ListUsers />
      </div>
    );
  }
}

ListUsersContainer.propTypes = {};

export default ListUsersContainer;

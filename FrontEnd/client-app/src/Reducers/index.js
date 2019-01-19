import { combineReducers } from "redux";
import { reducer as form } from "redux-form";

// Custom Components

// Combines all reducers to a single reducer function
const rootReducer = combineReducers({
  form
});

export default rootReducer;

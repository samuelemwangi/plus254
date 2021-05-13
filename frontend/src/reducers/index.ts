import { combineReducers } from "redux";
import { contactUsReducer } from "./ContactUsReducer";

const rootReducer = combineReducers({
  contactUsState: contactUsReducer,
});

export type AppState = ReturnType<typeof rootReducer>;

export default rootReducer;

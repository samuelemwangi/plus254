import {
  CLEAR_CONTACT_US,
  CONTACT_US_UPDATE_FAILURE,
  CONTACT_US_UPDATE_SUCCESS,
  LOADING,
} from "../actions/ContactUs";

import { IContactUsResponseAction } from "../contracts/ContactUs";

export const contactUsReducer = (
  state = {},
  action: IContactUsResponseAction
) => {
  switch (action.type) {
    case CONTACT_US_UPDATE_FAILURE:
      return { ...action.payload };

    case CONTACT_US_UPDATE_SUCCESS:
      return { ...action.payload };

    case LOADING:
      return { ...action.payload };

    case CLEAR_CONTACT_US:
      return {};

    default:
      return state;
  }
};

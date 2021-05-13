import {
  IContactUsPayload,
  IContactUsPayloadAction,
} from "../contracts/ContactUs";

export const CONTACT_US_UPDATE = "CONTACT_US_UPDATE";
export const CONTACT_US_UPDATE_SUCCESS = "CONTACT_US_UPDATE_SUCCESS";
export const CONTACT_US_UPDATE_FAILURE = "CONTACT_US_UPDATE_FAILURE";
export const LOADING = "LOADING";
export const CLEAR_CONTACT_US = "CLEAR_CONTACT_US";

export const contactUsUpdate = (
  payload: IContactUsPayload
): IContactUsPayloadAction => {
  return {
    type: CONTACT_US_UPDATE,
    payload,
  };
};

export const clearContactUs = () => ({ type: CLEAR_CONTACT_US });

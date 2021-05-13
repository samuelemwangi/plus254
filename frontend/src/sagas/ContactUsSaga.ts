import { put, call, takeLatest } from "redux-saga/effects";

import {
  CONTACT_US_UPDATE,
  CONTACT_US_UPDATE_FAILURE,
  CONTACT_US_UPDATE_SUCCESS,
  LOADING,
} from "../actions/ContactUs";
import {
  IContactUsPayloadAction,
  IContactUsResponse,
} from "../contracts/ContactUs";

import { updateContactUs } from "../apiclient/ContactUs";

export function* wathContactUs() {
  yield takeLatest([CONTACT_US_UPDATE], handleContactUs);
}

export function* handleContactUs(payload: IContactUsPayloadAction) {
  switch (payload.type) {
    case CONTACT_US_UPDATE:
      // Notify store we are loading
      yield put({
        type: LOADING,
        payload: { loading: true },
      });

      const hireusUpdateRes: IContactUsResponse = yield call(
        updateContactUs,
        payload.payload
      );

      yield put({
        type:
          hireusUpdateRes && hireusUpdateRes.error
            ? CONTACT_US_UPDATE_FAILURE
            : CONTACT_US_UPDATE_SUCCESS,
        payload: hireusUpdateRes,
      });
      break;

    default:
      break;
  }
}

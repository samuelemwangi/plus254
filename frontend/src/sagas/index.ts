import { all, fork } from "redux-saga/effects";
import { wathContactUs } from "./ContactUsSaga";

export default function* rootSaga() {
  yield all([fork(wathContactUs)]);
}

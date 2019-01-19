import { all } from "redux-saga/effects";

// Custom Components

// Here, we register our watcher saga(s) and export as a single generator
export default function* appSagas() {
  yield all([
    // fork(AnotherSaga)
  ]);
}

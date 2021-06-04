import { createStore, applyMiddleware } from "redux";
import createSagaMiddleware from "redux-saga";
import { composeWithDevTools } from "redux-devtools-extension";

import rootReducer from "../reducers";
import rootSaga from "../sagas";

const sagaMiddleware = createSagaMiddleware();

const middleWare =
  process.env.NODE_ENV !== "production"
    ? composeWithDevTools(applyMiddleware(sagaMiddleware))
    : applyMiddleware(sagaMiddleware);

const configureStore = () => {
  const store = createStore(rootReducer, middleWare);
  sagaMiddleware.run(rootSaga);
  return store;
};

export default configureStore;

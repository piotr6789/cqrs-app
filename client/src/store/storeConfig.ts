import {
  applyMiddleware, combineReducers, createStore, compose
} from 'redux';
import thunk from 'redux-thunk';

import postReducer from './reducers/posts';
import languageReducer from './reducers/language';

declare global {
  interface Window {
    __REDUX_DEVTOOLS_EXTENSION_COMPOSE__?: typeof compose;
  }
}

const configureStore = () => {
  const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
  const rootReducer = combineReducers({
    data: postReducer,
    language: languageReducer,
  });
  const store = createStore(
    rootReducer,
    composeEnhancers(applyMiddleware(thunk)),
  );

  return store;
};

export default configureStore;

import * as actionTypes from '../actions/actionTypes';

const initialState = {
  language: 0
};

const changeLanguage = (state: any, action: any) =>
({
  ...state,
  language: action.language
});

const checkLanguage = (state: any, action: any) =>
({
  ...state,
  language: action.language
});

const reducer = (state = initialState, action: any) => {
  switch (action.type) {
    case actionTypes.CHANGE_LANGUAGE:
      return changeLanguage(state, action);
    case actionTypes.CHECK_LANGUAGE:
      return checkLanguage(state, action);
    default:
      return state;
  }
};

export default reducer;

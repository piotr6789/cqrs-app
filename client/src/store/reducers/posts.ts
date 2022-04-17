import * as actionTypes from '../actions/actionTypes';

const initialState = {
  posts: []
};

const getPosts = (action: any) =>
({
  posts: [...action.posts]
});

const reducer = (state = initialState, action: any) => {
  switch (action.type) {
    case actionTypes.GET_POSTS_SUCCESS:
      return getPosts(action);
    case actionTypes.GET_POSTS_FAIL:
      return getPosts(action);
    default:
      return state;
  }
};

export default reducer;

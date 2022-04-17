import { NavigateFunction } from 'react-router-dom';
import { AnyAction, Dispatch } from 'redux';

import * as actionTypes from './actionTypes';

import axios from '../../axiosConfig';

import { MENU_ROUTES } from '../../constants/routes/routes';

export const getPostsSuccess = (posts:
  [{ id: string, content: string, date: Date, author: { name: string, age: number } }]) =>
({
  type: actionTypes.GET_POSTS_SUCCESS,
  posts
});

export const getPostsFail = () =>
({
  type: actionTypes.GET_POSTS_FAIL,
  posts: []
});

export const addPostSuccess = (post:
  { id: string, content: string, date: Date, author: { name: string, age: number } }) =>
({
  type: actionTypes.ADD_POSTS_SUCCESS,
  post
});

export const addPostFail = () =>
({
  type: actionTypes.ADD_POSTS_FAIL,
  posts: []
});

export const getPosts = (): any =>
  (dispatch: Dispatch<AnyAction>) => {
    axios
      .get('Post/posts')
      .then((response) => {
        dispatch(getPostsSuccess(response.data));
      })
      .catch(() => {
        dispatch(getPostsFail());
      });
  };

export const addPost = (post: {
  id: string, content: string, date: Date, author:
    { name: string, age: number }
}, route: NavigateFunction): any =>
  (dispatch: Dispatch<AnyAction>) => {
    axios
      .post('Post/add', post)
      .then((response) => {
        dispatch(addPostSuccess(response.data));
        route(MENU_ROUTES.POSTS);
      })
      .catch(() => {
        dispatch(addPostFail());
      });
  };

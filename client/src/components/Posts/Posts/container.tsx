import React, { Dispatch, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { AnyAction } from 'redux';

import Grid from '@material-ui/core/Grid';
import PostBody from '../PostBody';

import * as postActions from '../../../store/actions';

import * as LANGUAGE_HELPER from '../../../constants/languageHelper/languageHelper.json';
import { checkLanguage } from '../../../constants/languageHelper/checkLanguageHelper';

import useStyles from './styles';

export const useContainer = () => {
  const classes = useStyles();
  const dispatch: Dispatch<AnyAction> = useDispatch();

  const posts = useSelector((state:
    { data: any, language: { language: number } }) => state.data.posts);
  const language = useSelector((state:
    { data: any, language: { language: number } }) => state.language.language);

  useEffect(() => {
    dispatch(postActions.getPosts());
  }, []);

  const languageHelper = checkLanguage(language, LANGUAGE_HELPER);

  const content = posts.length ? (
    <Grid container spacing={4}>
      {posts.map((post: any) => (
        <Grid item xs {...{ key: post.id }}>
          <PostBody
            {...{ author: post.author.name, content: post.content }}
          />
        </Grid>
      ))}
    </Grid>
  ) : (
    <div {...{ className: classes.container }}>
      <h1 {...{ className: classes.text }}>{languageHelper.NO_POST}</h1>
    </div>
  );

  return { content };
};

import { Dispatch, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { AnyAction } from 'redux';
import { NavigateFunction, useNavigate } from 'react-router-dom';

import { ClassNameMap } from '@material-ui/core/styles/withStyles';

import * as componentActions from '../../store/actions/index';
import * as LANGUAGE_HELPER from '../../constants/languageHelper/languageHelper.json';

import generateUUID from './utils';

import useStyles from './styles';

import { checkLanguage } from '../../constants/languageHelper/checkLanguageHelper';

export const useService = () => {
  const classes: ClassNameMap<'root'> = useStyles();
  const navigate: NavigateFunction = useNavigate();

  const [author, setAuthor] = useState<string>('');
  const [content, setContent] = useState<string>('');
  const [age, setAge] = useState<number>(0);

  const dispatch: Dispatch<AnyAction> = useDispatch();
  const language = useSelector((state:
    { data: any, language: { language: number } }) => state.language.language);

  const setAuthorHandler = (value: string): void => setAuthor(value);
  const setContentHandler = (value: string): void => setContent(value);
  const setAgeHandler = (value: number): void => setAge(value);

  const addPostHandler = (): void => {
    const newPost = {
      id: generateUUID(),
      content,
      date: new Date(),
      author: {
        id: generateUUID(),
        name: author,
        age
      }
    };
    dispatch(componentActions.addPost(newPost, navigate));
  };

  const languageHelper = checkLanguage(language, LANGUAGE_HELPER);

  return {
    classes, addPostHandler, languageHelper, setAuthorHandler, setContentHandler, setAgeHandler
  };
};

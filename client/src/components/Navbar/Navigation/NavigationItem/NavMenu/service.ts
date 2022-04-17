import React, { MouseEventHandler, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { AnyAction, Dispatch } from 'redux';

import { ClassNameMap } from '@material-ui/core/styles/withStyles';

import useStyles from './styles';

import * as LANGUAGE_HELPER from '../../../../../constants/languageHelper/languageHelper.json';
import { checkLanguage } from '../../../../../constants/languageHelper/checkLanguageHelper';
import * as languageActions from '../../../../../store/actions/index';

export const useService = () => {
  const classes: ClassNameMap<'root'> = useStyles();

  const language = useSelector((state:
    { data: any, language: { language: number } }) => state.language.language);
  const dispatch: Dispatch<AnyAction> = useDispatch();

  const [anchorEl, setAnchorEl] = useState<Element | null>(null);
  const open = Boolean(anchorEl);

  const clickBtnHandler = (event: any): void => setAnchorEl(event.currentTarget);

  const clickLanguageHandler = (languageId: any): void => {
    setAnchorEl(null);
    dispatch(languageActions.changeLanguage(languageId));
  };

  const cancelLanguageHandler = (): void => setAnchorEl(null);

  const languageHelper: any = checkLanguage(language, LANGUAGE_HELPER);

  return {
    classes, open, clickBtnHandler, clickLanguageHandler, cancelLanguageHandler,
    languageHelper, anchorEl, language
  };
};
